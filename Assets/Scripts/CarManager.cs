using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using CandyCoded;
using CandyCoded.HapticFeedback;
using DG.Tweening;

[ExecuteInEditMode]
public class CarManager : PathFollower
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    private Vector3 initialPos = new Vector3(0, 0, 0);
    private Quaternion initialRotation = new Quaternion();
    protected override void Start()
    {
        base.Start();
        AddComponents();
    }

    void Awake()
    {
        initialPos = transform.position;
        initialRotation = transform.rotation;
    }

    private void AddComponents()
    {
        if(!GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

        if(!GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>().size = new Vector3(2f,2f,4f);
            GetComponent<BoxCollider>().center = Vector3.up; // this is basically new Vactor3(0f,1f,0f)
            GetComponent<BoxCollider>().isTrigger = true;
        }

        gameObject.tag = "Car";
        endOfPathInstruction = EndOfPathInstruction.Stop;

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        HapticFeedback.MediumFeedback();
        if(other.CompareTag("Car"))
        {
            moveCar = false;
            //lockTouch = false;
            //Cursor.lockState = CursorLockMode.Locked;
            GameManager.gameManagerInstance.loseBool = true;
            GameManager.gameManagerInstance.Lose();

            _rigidbody.isKinematic = _collider.isTrigger = false;
            other.GetComponent<Rigidbody>().AddForceAtPosition(other.transform.position * 27f, other.transform.position);
            Invoke("Rollback", 1f);     
        }
    }

    private void Rollback()
    {
        gameObject.transform.DORotateQuaternion(initialRotation, 1f).SetDelay(0.5f).SetEase(Ease.InOutSine);
        gameObject.transform.DOJump(initialPos, 2f, 1, 1f).SetDelay(0.5f).SetEase(Ease.InOutSine);
        Invoke("delayStart", 2f); 
        //_rigidbody.isKinematic = _collider.isTrigger = true;
    }

    private void delayStart()
    {
        GameManager.gameManagerInstance.restartLevel();
    }

}
