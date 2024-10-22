using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject assingedCar;
    public GameObject assingedPath;
    public GameObject confetta;

    void Awake()
        {
            FindMyPaths();
        }

    // Update is called once per frame
    void Update()
    {
        if(assingedCar.GetComponent<CarManager>().reverseIt == true)
        {
            Instantiate(confetta, transform.position + new Vector3(0,4f,0), Quaternion.Euler(-90f, 0f, 0f));
            //confetta.Play();
            Debug.Log("CarSent");
            rewardManager.rewardManagerInstance.ContainShifter(this.gameObject);
            assingedCar.GetComponent<CarManager>().reverseIt = false;
            assingedCar.SetActive(false);
            assingedPath.SetActive(false);
        } 
    }

    private void FindMyPaths()
        {
            var pathsForContainer = GameObject.FindGameObjectsWithTag("Path");

            string pathName = "Path_" + assingedCar.name;

            foreach(var path in pathsForContainer)
            {
                if (path.name.Equals(pathName))
                {
                    assingedPath = path;
                    return;
                }
            }
        }
}
