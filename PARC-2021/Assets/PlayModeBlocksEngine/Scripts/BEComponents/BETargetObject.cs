using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BETargetObject : MonoBehaviour
{
    public List<BEBlock> beBlockGroupsList;

    public AudioClip ready;
    public AudioClip set;
    public AudioClip go;
    public AudioClip bing;
    public Animator Wheels;

    public bool isGo;
    public bool objOnce;
    public float soundfreq;

    public AudioSource beAudioSource;
    //public GameHandler gameHandler;
    private BEController beController;
    public Animator Dispenser;
    GameObject robotClaw;
    public GameObject Ball;
    public Transform BallPoint;

    public int ballCounter = 0;

    public float speed = 2.0f;
    public float rotationSpeed = 30.0f;
    bool screwing;
    public BEController BeController { get => beController; }



    //v1.1 -Enable programming env from target object inspector
    [HideInInspector]
    public BEProgrammingEnv beProgrammingEnv;
    [SerializeField]
    private bool enableProgrammingEnv = true;
    public bool EnableProgrammingEnv
    {
        get
        {
            return enableProgrammingEnv;
        }
        set
        {
            enableProgrammingEnv = value;
            SetEnableProgrammingEnv(value);
        }
    }

    private void OnDisable()
    {
        SetEnableProgrammingEnv(false);
    }

    private void OnDestroy()
    {
        try
        {
            Destroy(beProgrammingEnv.gameObject);
        }
        catch
        {
            // object already destroyed
        }
    }

    private void SetEnableProgrammingEnv(bool value)
    {
        if (beController == null)
        {
            beController = GetBeController();
        }
        try
        {
            beController.FindTargetObjects();
            if (beController.singleEnabledProgrammingEnv && value == true)
            {
                foreach (BETargetObject targetObject in BEController.beTargetObjectList)
                {
                    if (targetObject != this)
                    {
                        targetObject.EnableProgrammingEnv = false;
                    }
                }
            }
            if (beProgrammingEnv != null)
            {
                beProgrammingEnv.gameObject.SetActive(value);
            }
            else
            {
                GetProgrammingEnv(transform).gameObject.SetActive(value);
            }
        }
        catch
        {
            //exiting play mode
        }
    }

    // v1.1 -GetBeController method added to BETargetObject using FindObjectOfType, more suitable than tag=="GameController"
    private BEController GetBeController()
    {
        return FindObjectOfType<BEController>();
    }

    public BEProgrammingEnv GetProgrammingEnv(Transform parent)
    {
        BEProgrammingEnv progEnv = null;
        foreach (Transform child in parent)
        {
            if (child.GetComponent<BEProgrammingEnv>())
            {
                progEnv = child.GetComponent<BEProgrammingEnv>();
                break;
            }
            GetProgrammingEnv(child);
        }
        return progEnv;
    }

    private void OnValidate()
    {
        SetEnableProgrammingEnv(enableProgrammingEnv);
    }

    private void Awake()
    {
        beController = GetBeController();
    }

    void Start()
    {
        robotClaw = transform.Find("The Beetle v2").transform.Find("Claw").gameObject;
        beBlockGroupsList = new List<BEBlock>();
        beAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        /*if(SceneManager.GetActiveScene().name == "Main")
        {
            if (gameHandler.tick2 && gameHandler.tick3 && gameHandler.isManual)
            {
                ControllerMove();
            }
        }*/
             
    }

    public void ControllerMove()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.J))
        {
            RaycastHit hit;
            if (Physics.Raycast(robotClaw.transform.position, this.transform.TransformDirection(Vector3.forward), out hit, 1f))
            {
                if (hit.transform.gameObject.tag == "Screw")
                {
                    robotClaw.GetComponent<Animator>().SetTrigger("Screw");
                    screwing = true;
                }
            }
            else
            {
                robotClaw.GetComponent<Animator>().SetTrigger("Screw");
            }
            
        }

        if (screwing)
        {
            GameObject environment = GameObject.FindGameObjectWithTag("Environment").gameObject;
            Debug.Log("screwing Succesful");
            Dispenser.SetTrigger("Drop");
            Instantiate(Ball, BallPoint.position, BallPoint.rotation, environment.transform);
            screwing = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("We are functioning");
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hit, 6f))
            {
                if (hit.transform.gameObject.tag == "Animal" || hit.transform.gameObject.tag == "Child" || hit.transform.gameObject.tag == "Adult" || hit.transform.gameObject.tag == "Ball")
                {
                    if(hit.transform.gameObject.tag == "Ball")
                    {
                        hit.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        Debug.Log("We've hit something" + hit.transform.gameObject.tag);
                        robotClaw.GetComponentInChildren<Animator>().SetTrigger("Carry");
                        hit.transform.gameObject.transform.position = robotClaw.transform.position + new Vector3(0f, 0.2f, 0.4f);
                        hit.transform.gameObject.transform.SetParent(robotClaw.transform);
                    }
                    else
                    {
                        Debug.Log("We've hit something" + hit.transform.gameObject.tag);
                        robotClaw.GetComponentInChildren<Animator>().SetTrigger("Carry");
                        hit.transform.gameObject.transform.position = robotClaw.transform.position + new Vector3(0.6f, -0.5f, 0.4f);
                        hit.transform.gameObject.transform.SetParent(robotClaw.transform);
                    }
                }
                else if (hit.transform.gameObject.tag == "Barricade")
                {
                    Debug.Log("We've hit something" + hit.transform.gameObject.tag);
                    robotClaw.GetComponentInChildren<Animator>().SetTrigger("Carry");
                    hit.transform.gameObject.transform.position = robotClaw.transform.position + new Vector3(0f, -1f, 0f);
                    hit.transform.gameObject.transform.SetParent(robotClaw.transform);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject environment = GameObject.FindGameObjectWithTag("Environment").gameObject;

            if (robotClaw.transform.Find("Animal"))
            {
                robotClaw.transform.Find("Animal").gameObject.transform.SetParent(environment.transform);
            }
            else if (robotClaw.transform.Find("Child"))
            {
                robotClaw.transform.Find("Child").gameObject.transform.SetParent(environment.transform);
            }
            else if (robotClaw.transform.Find("Adult"))
            {
                robotClaw.transform.Find("Adult").gameObject.transform.SetParent(environment.transform);
            }
            else if (robotClaw.transform.Find("Barricade"))
            {
                robotClaw.transform.Find("Barricade").gameObject.transform.SetParent(environment.transform);
            }
            else if (robotClaw.transform.Find("Sphere") || robotClaw.transform.Find("Sphere(Clone)"))
            {
                if (robotClaw.transform.Find("Sphere"))
                {
                    robotClaw.transform.Find("Sphere").gameObject.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    robotClaw.transform.Find("Sphere").gameObject.transform.SetParent(environment.transform);
                }
                else if (robotClaw.transform.Find("Sphere(Clone)"))
                {
                    robotClaw.transform.Find("Sphere(Clone)").gameObject.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    robotClaw.transform.Find("Sphere(Clone)").gameObject.transform.SetParent(environment.transform);
                }
                               
            }
        }
    }
}