using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour {

    bool hitdoor = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hitdoor == true)
        {
            if (Input.GetKeyDown("f"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Door")
        {
            print("col");
            hitdoor = true;
        }
        else
        {
            hitdoor = false;
        }

    }


}
