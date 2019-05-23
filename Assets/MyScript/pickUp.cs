using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public bool collected = false;
    public GameObject Player;
    public Inventory itemAmount;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        itemAmount = Player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //itemAmount.coinAmount = itemAmount.coinAmount + 1;
            Destroy(gameObject);
        }
    }
}
