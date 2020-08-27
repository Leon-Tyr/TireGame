using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    private float SpeedAdd = 1; 
    public GameObject model;
    public GameObject rotate;

    private Rigidbody rb;

    public float JumpHeight = 10.0f;
    private bool onGround = true;
    private bool isInvulenerable = false;

    public Canvas canvas;
    private bool paused;
    public GameObject Gameover;
    private bool dead;

    public Image currentBoostBar;
    public Text BoostValue;

    private float Boostpoint = 100;
    private float maxBoostpoint = 100;

    public AudioSource Death;
    public AudioSource Boost;
    public AudioSource Zoom;
    public AudioSource CountdownAS;

    public GameObject boostAP;
    public GameObject InvulenerableAP;

    public GameObject countndownImage;




    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Gameover.SetActive(false);
       // Time.timeScale = 1;
        dead = false;
        InvulenerableAP.SetActive(false);
        UpdateBoost();
        boostAP.SetActive(false);
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        Death = GetComponent<AudioSource>();
        UpdateBoost();
        if (!paused)
        {
            model.transform.Translate(Vector3.forward * speed * Time.deltaTime * 4 * SpeedAdd);
            rotate.transform.Rotate(Vector3.right * (speed * Time.deltaTime) * 18);
        }
        // model.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime*speed, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        else if (!paused && !dead)
        {
            if (model.transform.position.x >= 20.5f && model.transform.position.x <= 21.5)
            {
                model.transform.position = new Vector3(21, model.transform.position.y, model.transform.position.z);
            }
            if (Input.GetKeyDown("a"))
            {
                if (model.transform.position.x == 21)
                {
                    model.transform.position = new Vector3(model.transform.position.x - 6, model.transform.position.y, model.transform.position.z) ;
                }
                else if (model.transform.position.x < 27.5f && model.transform.position.x > 26.5f)
                {
                    model.transform.position = new Vector3(21, model.transform.position.y, model.transform.position.z);
                }
                // transform.Rotate(Vector3.down, speed * Time.deltaTime* 10);
            }

            if (Input.GetKeyDown("d"))
            {
                if (model.transform.position.x == 21)
                {
                    model.transform.position = new Vector3(model.transform.position.x + 6, model.transform.position.y, model.transform.position.z);
                }
                else if (model.transform.position.x > 14.5f && model.transform.position.x < 15.5f)
                {
                    model.transform.position = new Vector3(21, model.transform.position.y, model.transform.position.z);
                }

                // transform.Rotate(Vector3.up, speed * Time.deltaTime * 10);

            }

            if (Input.GetKeyDown("space") && onGround)
            {
                rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
                onGround = false;
            }

            if (Input.GetKey("f") && onGround && Boostpoint > 0)
            {
                UseBoost();
                UpdateBoost();
                boostAP.SetActive(true);
            }
            else
            {
                speed = 5;
                Boost.Stop();
                boostAP.SetActive(false);
            }
            if (!Input.GetKey("f"))
            {
                boostAP.SetActive(false);
            }

        }
    }

    private void UseBoost()
    {
        speed += 1;
        Boostpoint -= Time.deltaTime * 20;
        Boost.Play();
    }

    private void UpdateBoost()
    {
        float ratio = Boostpoint / maxBoostpoint;
        currentBoostBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        if (Boostpoint <= 0)
        {
            BoostValue.text = "EMPTY";
            Boostpoint = 0;
        }
        else
        {
            BoostValue.text = (ratio * 100).ToString("F2") + "%";
        }
    }
       

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == ("Platform"))
        {
            onGround = true;
        }

        if (col.collider.tag == ("Hazard"))
        {
            if (isInvulenerable == false)
            {
                Die();
            }
        }
        if (col.collider.tag == ("Collectable"))
        {

            Destroy(col.gameObject);
            if (Boostpoint >= 75)
            {
                Boostpoint = 100;
            }
            else
            {
                Boostpoint += 25;
            }
        }
        if (col.collider.tag == ("Collect2"))
        {
            Destroy(col.gameObject);
            StartCoroutine(FiveSecondsCooldown());
           
        }

    }

    public IEnumerator FiveSecondsCooldown()
    {
        InvulenerableAP.SetActive(true);
        isInvulenerable = true;
        SpeedAdd = 5;
        rotate.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.5f, 1.0f, 0.5f);
        Zoom.Play();
        yield return new WaitForSeconds(6f);
        SpeedAdd = 1;
        isInvulenerable = false;
        InvulenerableAP.SetActive(false);
        rotate.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        Zoom.Stop();
    }

    public void Unpaused()
    {
        paused = false;
    }

    public void Die()
    {
        Gameover.SetActive(true);
        Time.timeScale = 0;
        dead = true;
        Death.Play();
    }

    public IEnumerator Countdown()
    {
        CountdownAS.Play();
        paused = true;
        countndownImage.SetActive(true);
        speed = 0;
        yield return new WaitForSeconds(4f);
        countndownImage.SetActive(false);
        paused = false;
        speed = 5;
        CountdownAS.Stop();
    }
}