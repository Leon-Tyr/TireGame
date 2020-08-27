using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] Hazards;


    private float SpawnTimer;
    private float startTimer = 2.25f;
    public float decreaseTime;
    public float minTime = 0.65f;
    public float[] pos;

    private int SpawnCount = 0;
    private int MaxSpawn = 4;
    private bool CanSpawn = true;

   // private float Scoref;
 

    void Start()
    {
        //Scoref = GetComponent<Score>().scorepoints;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Scoref >= 500) { MaxSpawn = 10;}
        //if (Scoref >= 1000) { MaxSpawn = 20; }
        //if (Scoref >= 2000) { MaxSpawn = 30; }

        if (SpawnCount >= MaxSpawn)
        {
            CanSpawn = false;
        }
        
        int roll = Random.Range(0, 3);

        float randomX = pos[roll];

        transform.position = new Vector3(randomX, transform.position.y, transform.position.z + Random.Range(0,2));

        if (SpawnTimer <= 0 && CanSpawn)
        {
            int rand = Random.Range(0, Hazards.Length);
            Instantiate(Hazards[rand], transform.position, Quaternion.identity);
            SpawnTimer = startTimer;
            SpawnCount++;
            if (startTimer > minTime)
            {
                startTimer -= decreaseTime;
            }
            
        }
        else
        {
            SpawnTimer -= Time.deltaTime;

        }
        
    }
}
