using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    //public GameObject player;
    //public Vector2 projectileSpeed = new Vector2 (10f, 10f);
    //public bool objectHit;
    //public float pXPosition;
    //public float pYPosition;

    public Transform target;
    public float ProjectileSpeed = 20;
    public bool newP = true;
    private Transform myTransform;
    private float followTime = 1.0f;
    public float timer = 0.0f;
    public GameObject coin;
    public int coinDropChance;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        // rotate the projectile to aim the target:
        myTransform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        //if(newP)
        //{
        timer += Time.deltaTime;
        if(timer > followTime)
        {
            myTransform.LookAt(target);
            timer = timer - followTime;
        }
            //newP = false;
        //}
        // distance moved since last frame:
 
        float amtToMove = ProjectileSpeed * Time.deltaTime;
        // translate projectile in its forward direction:
        myTransform.Translate(Vector3.forward * amtToMove);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            coinDropChance = Random.Range(0, 4);
            if(coinDropChance == 3)
            {
                Instantiate(coin, transform.position, coin.transform.rotation);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trunk")
        {
            Destroy(gameObject);
        }
    }
}
