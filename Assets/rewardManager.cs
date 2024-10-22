using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rewardManager : MonoBehaviour
{
    public static rewardManager rewardManagerInstance;

    //public GameObject container;
    public GameObject holderParkSpace;
    [SerializeField] private Vector3[] initialPos;
    [SerializeField] private Quaternion[] initialRotation;

    [SerializeField] private int noOfPARKspace;
    private int aPPostion = 0;

    public GameObject outOfSlotSxreen;


    public Ease aniType;
    
    void Start()
    {
        if(rewardManagerInstance == null)
        {
            rewardManagerInstance = this;
        }

        // initialPos = new Vector3[noOfPARKspace];
        // initialRotation = new Quaternion[noOfPARKspace];

        // for(int i = 0; i< holderParkSpace.transform.childCount; i++)
        // {
        //     initialPos[i] = holderParkSpace.transform.GetChild(i).position;
        //     initialRotation[i] = holderParkSpace.transform.GetChild(i).rotation;
        // }
        //container.transform.DOMove(parkSpace.transform.position, 2f).SetDelay(1f).SetEase(aniType);
        //container.transform.DORotateQuaternion(parkSpace.transform.rotation, 2f).SetDelay(1f).SetEase(aniType);
        //container.transform.DOJump(parkSpace.transform.position, 2f, 1, 2f).SetDelay(1f).SetEase(aniType); 
        //@@@@@@@@@@animation 
    }

    // Update is called once per frame
    void Update()
    {
        // if(aPPostion>=noOfPARKspace)
        // {
        //     Debug.Log("SpacesFilled");
        //     outOfSlotSxreen.SetActive(true); 
        // }
        //for(int i = 0; i< holderParkSpace.transform.childCount; i++)
        {
            //if(holderParkSpace.transform.GetChild(i))
            //container.transform.DORotateQuaternion(holderParkSpace.transform.GetChild(i).rotation, 2f).SetDelay(1f).SetEase(aniType);
        }

    }

    public void ContainShifter(GameObject container)
    {
        container.transform.DORotateQuaternion(holderParkSpace.transform.GetChild(aPPostion).rotation, 2f).SetDelay(1f).SetEase(aniType);
        container.transform.DOJump(holderParkSpace.transform.GetChild(aPPostion).position, 2f, 1, 2f).SetDelay(1f).SetEase(aniType);  
        aPPostion++;
    }


}
