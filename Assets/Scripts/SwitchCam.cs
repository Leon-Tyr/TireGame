using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchCam : MonoBehaviour
{
    public GameObject Player;
    public Camera Camera1;
    public Camera Camera2;

    // Use this for initialization
    void Start()
    {
        Camera1.enabled = false;
        Camera2.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Camera1.enabled = !Camera1.enabled && !Camera2.enabled;
        }
        if (Input.GetKeyDown("i"))
        {
            Camera2.enabled = !Camera2.enabled && !Camera1.enabled;
        }
    }

}