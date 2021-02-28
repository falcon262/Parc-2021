using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globe : MonoBehaviour
{
    public float turnSpeed;
    public Button StartButton;
    bool startPressed;
    bool slowStop;
    public GameObject pleaseWait;
    public Animator mainMenu;
    public GameObject Challenge;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener
            (delegate 
            { 
                startPressed = true;
                if (!slowStop)
                    pleaseWait.SetActive(true);
                else
                    pleaseWait.SetActive(false);
            
            
            });
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        if (startPressed)
        {
            StopGlobe();
        }
        if (slowStop)
        {
            if (turnSpeed <= 0) { turnSpeed = 0; pleaseWait.SetActive(false); mainMenu.SetBool("Start", true); }               
            else
                turnSpeed -= Time.deltaTime*120f;
            
        }
    }

    void StopGlobe()
    {
        startPressed = true;
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 500f))
        {
            if(hit.transform.gameObject.tag == "Africa")
            {
                slowStop = true;
            }
        }
    }
}
