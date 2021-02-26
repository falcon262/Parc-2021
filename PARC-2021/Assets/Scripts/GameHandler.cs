using System.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GameHandler : MonoBehaviour
{
    [SerializeField] float startTime = 5f;
    public TextMeshProUGUI timerText;
    public float timer;
    public GameObject StartCharge;
    public Animator Bar1;
    public Animator Bar2;
    public Animator Bar3;
    public BETargetObject robot;

    public GameObject TimeOut;
    public TextMeshProUGUI finalScore;

    public List<GameObject> spheres;
    
    public int score;
    public int obj4Counter;
    public TextMeshProUGUI scoreText;

    public GameObject mainCam;
    
    public bool obj1, obj2, obj3, obj4, obj5;
    public bool isVet, isSchool, isWork;
    public bool isSensing;
    public bool stopCoroutine;
    public bool gameplay;
    public bool tick1, tick2, tick3, tick4, tick5;
    public bool isManual;
    public bool isTimeout;

    public GameObject rulesScreen;
    public GameObject tik1;
    public GameObject tik2;
    public GameObject tik3;
    public GameObject tik4;
    public GameObject tik5;
    public GameObject Wait;
    public GameObject Charged;
    public GameObject Done;
    
    public void CameraLogic()
    {
        if (mainCam.activeSelf)
        {
            mainCam.SetActive(false);
        }
        else if(!mainCam.activeSelf)
        {
            mainCam.SetActive(true);
        }
    }



    public void rulesScreenTriggerOn()
    {
        rulesScreen.SetActive(true);
    }
    
    public void rulesScreenTriggerOff()
    {
        rulesScreen.SetActive(false);
    }
    public void ChargeScreenTriggerOff()
    {
        StartCharge.SetActive(false);
    }



    public IEnumerator Timer()
    {
        gameplay = true;
        timer = startTime;

        do
        {
            if (stopCoroutine)
            {
                stopCoroutine = false;
            }
            isTimeout = true;
            timer -= Time.deltaTime;

            if (obj1 && !tick1)
            {
                tik1.SetActive(true);
                robot.beAudioSource.clip = robot.bing;
                robot.beAudioSource.Play();
                tick1 = true;
            }

            if (obj2 && !tick2)
            {
                tik2.SetActive(true);
                robot.beAudioSource.clip = robot.bing;
                robot.beAudioSource.Play();
                tick2 = true;
            }

            if (obj3 && !tick3)
            {
                tik3.SetActive(true);
                robot.beAudioSource.clip = robot.bing;
                robot.beAudioSource.Play();
                tick3 = true;
            }
            if (obj4 && !tick4)
            {
                tik4.SetActive(true);
                robot.beAudioSource.clip = robot.bing;
                robot.beAudioSource.Play();
                tick4 = true;
            }
            if (obj5 && !tick5)
            {
                tik5.SetActive(true);
                robot.beAudioSource.clip = robot.bing;
                robot.beAudioSource.Play();
                tick5 = true;
            }
            
            FormatText();
            if(isVet && isSchool && isWork && !obj2)
            {
                score += 50;
                scoreText.text = score.ToString();
                obj2 = true;
            }
            yield return null;

        } while (timer > 0 && !stopCoroutine);
    }

    private void Update()
    {
        if(timer <= 0 && isTimeout)
        {
            isTimeout = false;
            TimeOut.SetActive(true);
            finalScore.text = "Score: " + score;
            StartCoroutine(UpdateScore());
        }        
    }

    IEnumerator UpdateScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "l3k5lrAHZ2UVcJtSdi57UC3zNhItf9");
        form.AddField("score", score);

        using(UnityWebRequest www = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.updatescore", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> dict in www.GetResponseHeaders())
                {
                    sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
                }

                //Print Headers
                Debug.Log(sb.ToString());

                //Print Body
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    private void FormatText()
    {
        int days = (int)(timer / 86400) % 365;
        int hours = (int)(timer / 3600) % 24;
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60) ;

        timerText.text = minutes + ":" + seconds;
        /*if(days > 0)
        {
            timerText.text += days + ".";
        }
        if(hours > 0)
        {
            timerText.text += hours + ".";
        }
        if(minutes > 0)
        {
            timerText.text += minutes + ".";
        }
        if(seconds > 0)
        {
            timerText.text += seconds + "";
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        spheres = new List<GameObject>();
        score = 0;
        scoreText.text = score.ToString();
    }
}
