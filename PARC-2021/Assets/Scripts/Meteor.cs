using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public GameObject helpCanvas;
    public GameObject proffessor;
    public GameObject distance;
    public GameObject rocket;
    public GameObject BeController;
    public GameObject restartButton;
    public bool valueSet;
    public bool midpoint;
    public bool timeronce;
    public float rotationSpeed;
    public Manager manager;

    private void Update()
    {
        transform.Rotate(rotationSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "MidPoint" && !midpoint)
        {
            midpoint = true;
            //rb.useGravity = false;
            helpCanvas.SetActive(true);
            //Time.timeScale = 0;
            rb.drag = 100;
        }

    }

    public void CodeButton()
    {
        if(proffessor.activeSelf && distance.activeSelf)
        {
            proffessor.SetActive(false);
            distance.SetActive(false);
            rocket.SetActive(true);
            restartButton.SetActive(false);
            BeController.SetActive(true);
            rb.drag = 35;
            if (!timeronce)
            {
                StartCoroutine(manager.StartTimer());
            }
            //Time.timeScale = 1;
        }
        else
        {
            proffessor.SetActive(true);
            distance.SetActive(true);
            rocket.SetActive(false);
            restartButton.SetActive(true);
            BeController.SetActive(false);
            rb.drag = 100;
            //Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.tag == "rocket" && valueSet)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            manager.score += 50;
            manager.ScoreText.text = manager.score.ToString();
            manager.obj1.SetActive(true);
        }
        else if (collision.transform.gameObject.tag == "rocket" && !valueSet)
        {
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            manager.timer = 0;
        }



        if (collision.transform.gameObject.tag == "SpaceStation")
        {
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            manager.timer = 0;
        }
    }
}
