using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Use this for initialization

    public Text score;
    public float scorepoints;
    private float Pspeed;

    public GameObject player;

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Pspeed = player.GetComponent<PlayerController>().speed;
        scorepoints = scorepoints + (Time.deltaTime * Pspeed);
        score.text = "Score: " + (int)scorepoints;
	}

    public void scoreBoost()
    {
        scorepoints++;
    }

    public void scoreBoostEnd()
    {
        scorepoints = scorepoints + (Time.deltaTime * 5);
    }
}
