using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour {


    public GameObject Platform;
    public Transform GPoint;
    public GameObject Player;

    public float distance;
    private float platformwidth = 100;

    public Transform EPoint;


    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < GPoint.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformwidth + distance);
            Instantiate(Platform, transform.position, transform.rotation);
            DeletePlatform();
         
        }
       

    }
    private void DeletePlatform()
    {
      
    }
}
