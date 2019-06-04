using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closedDoor;
    public GameObject openedDoorMessage;
    public int coinCount = 0;
    //public GameObject coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        openDoor.SetActive(false);
        closedDoor.SetActive(true);
        openedDoorMessage.SetActive(false);
        //coinAmount.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(coinCount >= 10)
        {
            openDoor.SetActive(true);
            closedDoor.SetActive(false);
            openedDoorMessage.SetActive(true);
        }
    }

}
