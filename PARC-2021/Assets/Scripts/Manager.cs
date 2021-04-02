using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject LoseScreen;
    bool timeUp;
    bool youWin;
    public TextMeshProUGUI LoseScore;
    public GameObject WinScreen;
    public TextMeshProUGUI WinScore;

    public GameObject Rulers;

    public Animator amb;
    public GameObject Instructions;

    public TextMeshProUGUI ScoreText;
    public int score;

    public TextMeshProUGUI timerText;
    public float startTime;
    public float timer;

    [Header("Challenge 2 - Rectangle")]
    public bool bottomRight;
    public bool bottomLeft;
    public bool topRight;
    public bool topLeft;
    public GameObject left;
    public GameObject right;
    public GameObject top;
    public GameObject bottom;
    public GameObject Rectangle;

    [Header("Challenge 2 - Triangle")]
    public bool bottomRightVertex;
    public bool bottomLeftVertex;
    public bool apex;
    public GameObject leftSide;
    public GameObject rightSide;
    public GameObject bottomSide;
    public GameObject Triangle;

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
            timeUp = false;
            LoseScreen.SetActive(true);
            LoseScore.text = "Score: " + score;
            StartCoroutine(UpdateScore(score));
        }
        else if (obj1.activeSelf && obj2.activeSelf && !youWin)
        {
            youWin = true;
            WinScreen.SetActive(true);
            WinScore.text = "Score: " + (int)(score + timer);
            StartCoroutine(UpdateScore((int)(score + timer)));
        }
        RectangleLogic();
        TriangleLogic();
    }

    IEnumerator UpdateScore(int Highscore)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "ejT2dtEeas9jePrE8jTTZ2xKEPYdnQ2d");
        form.AddField("score", Highscore);

        using (UnityWebRequest www = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.updatescore", form))
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

    public void MapMenu()
    {
        SceneManager.LoadScene("MapMenu");
    }

    public void Measure()
    {
        if (!Rulers.activeSelf)
        {
            Rulers.SetActive(true);
        }
        else
        {
            Rulers.SetActive(false);
        }
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

    void RectangleLogic()
    {
        if (bottomRight && topRight && !left.activeSelf && !bottom.activeSelf && !top.activeSelf && !right.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            left.SetActive(true);
            bottomRight = false;
        }
        else if (bottomRight && bottomLeft && !left.activeSelf && !bottom.activeSelf && !top.activeSelf && !right.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            bottom.SetActive(true);
            bottomRight = false;
        }

        if(!bottomRight && topRight && topLeft && !top.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            top.SetActive(true);
        }
        else if (!bottomRight && bottomLeft && topLeft && !right.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            right.SetActive(true);
        }

        if (!bottomRight && topRight && topLeft && bottomLeft && !right.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            right.SetActive(true);
        }
        else if (!bottomRight && bottomLeft && topLeft && topRight && !top.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            top.SetActive(true);
        }

        if (bottomRight && topRight && topLeft && bottomLeft && !bottom.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            bottom.SetActive(true);
            score += 50;
            ScoreText.text = "SCORE: " + score;
            obj1.SetActive(true);
        }
        else if (bottomRight && topRight && topLeft && bottomLeft && !left.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            left.SetActive(true);
            score += 50;
            ScoreText.text = "SCORE: " + score;
            obj1.SetActive(true);
        }
    }

    void TriangleLogic()
    {
        if(bottomLeftVertex && bottomRightVertex && !bottomSide.activeSelf && !leftSide.activeSelf && !rightSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            bottomSide.SetActive(true);
            bottomLeftVertex = false;
        }
        else if (bottomLeftVertex && apex && !leftSide.activeSelf && !rightSide.activeSelf && !bottomSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            leftSide.SetActive(true);
            bottomLeftVertex = false;
        }

        if(!bottomLeftVertex && bottomRightVertex && apex && !rightSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            rightSide.SetActive(true);
        }
        else if (!bottomLeftVertex && apex && bottomRightVertex && !rightSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            rightSide.SetActive(true);
        }

        if(bottomLeftVertex && bottomRightVertex && apex && !leftSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            leftSide.SetActive(true);
            score += 50;
            ScoreText.text = "SCORE: " + score;
            obj2.SetActive(true);
        }
        else if (bottomLeftVertex && bottomRightVertex && apex && !bottomSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            bottomSide.SetActive(true);
            score += 50;
            ScoreText.text = "SCORE: " + score;
            obj2.SetActive(true);
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
        } while (timer > 0 && !WinScreen.activeSelf);
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
