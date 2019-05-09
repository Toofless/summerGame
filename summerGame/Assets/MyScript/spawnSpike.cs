using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSpike : MonoBehaviour
{
    public GameObject spike;
    public float timer;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;
    public micInput mic;
    public float micVol;
    public float spawnThreshold;
    public float rechargeThreshold;
    float recharge = 0;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int spawnLocation = Random.Range(0, spawnPoints.Length);
        Instantiate(spike, spawnPoints[spawnLocation].position, Quaternion.identity);
        recharge = 0;
        Debug.Log("spawn");
    }
    // Update is called once per frame
    void Update()
    {
        recharge++;
        micVol = mic.testSound;
        if(micVol > spawnThreshold && recharge > rechargeThreshold) { Spawn(); }
    }
}
