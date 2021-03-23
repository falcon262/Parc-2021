using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject LoseScreen;
    bool timeUp;
    public TextMeshProUGUI LoseScore;
    public GameObject WinScreen;
    public TextMeshProUGUI WinScore;


    public Animator amb;
    public GameObject Instructions;

    public TextMeshProUGUI ScoreText;
    public int score;

    public TextMeshProUGUI timerText;
    public float startTime;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        obj1.SetActive(false);
        obj2.SetActive(false);
        score = 0;
        ScoreText.text = "SCORE: " + score;
        Cam1.SetActive(true);
        Cam2.SetActive(false);        
    }

    private void Update()
    {
        if(timer <= 0 && timeUp)
        {
            LoseScreen.SetActive(true);
            LoseScore.text = "Score: " + score;
        }
        else if (obj1.activeSelf && obj2.activeSelf)
        {
            WinScreen.SetActive(true);
            WinScore.text = "Score: " + score;
        }
    }

    public void MapMenu()
    {
        SceneManager.LoadScene("MapMenu");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Help()
    {
        Instructions.SetActive(true);
    }

    public void Done()
    {
        Instructions.SetActive(false);
    }

    public void CameraLogic()
    {
        if (Cam1.activeSelf)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }
        else
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
    }

    public IEnumerator StartTimer()
    {
        timer = startTime;
        timeUp = true;

        do
        {
            timer -= Time.deltaTime;
            FormatText();
            yield return null;
        } while (timer > 0);
    }

    void FormatText()
    {
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        //timerText.text = "TIME: " + minutes + ":" + seconds;
        if(minutes < 10 && seconds > 9)
        {
            timerText.text = "TIME: " + "0" + minutes + ":" + seconds;
        }
        else if (minutes < 10 && seconds < 10)
        {
            timerText.text = "TIME: " + "0" + minutes + ":0" + seconds;
        }
        else if (minutes > 9 && seconds < 10)
        {
            timerText.text = "TIME: " + minutes + ":0" + seconds;
        }
        else
        {
            timerText.text = "TIME: " + minutes + ":" + seconds;
        }
    }
}
