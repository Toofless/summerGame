using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedDoor : MonoBehaviour
{
    public GameObject closedDoorMessage;
    // Start is called before the first frame update
    void Start()
    {
        closedDoorMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        closedDoorMessage.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        closedDoorMessage.SetActive(false);
    }
}
