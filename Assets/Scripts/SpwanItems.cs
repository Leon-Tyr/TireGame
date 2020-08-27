using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanItems : MonoBehaviour
{
    public GameObject[] Items;


    private float SpawnTimer;
    private float startTimer = 2.25f;
    public float decreaseTime;
    public float minTime = 0.65f;
    public float[] pos;

    private int SpawnCount = 0;
    private int MaxSpawn = 1;
    private bool CanSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnCount >= MaxSpawn)
        {
            CanSpawn = false;
        }

        int roll = Random.Range(0, 3);

        float randomX = pos[roll];

        transform.position = new Vector3(randomX, transform.position.y, transform.position.z + Random.Range(0, 2));

        if (SpawnTimer <= 0 && CanSpawn)
        {
            int rand = Random.Range(0, Items.Length);
            Instantiate(Items[rand], transform.position, Quaternion.identity);
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

