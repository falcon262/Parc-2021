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
            LoseScreen.SetActive(true);
            LoseScore.text = "Score: " + score;
        }
        else if (obj1.activeSelf && obj2.activeSelf)
        {
            WinScreen.SetActive(true);
            WinScore.text = "Score: " + score;
        }
        RectangleLogic();
        TriangleLogic();
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

    void RectangleLogic()
    {
        if (bottomRight && topRight && !left.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            left.SetActive(true);
            bottomRight = false;
        }

        if(!bottomRight && topRight && topLeft && !top.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            top.SetActive(true);
        }

        if (!bottomRight && topRight && topLeft && bottomLeft && !right.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            right.SetActive(true);
        }
        if (bottomRight && topRight && topLeft && bottomLeft && !bottom.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            bottom.SetActive(true);
            score += 50;
            ScoreText.text = "SCORE: " + score;
            obj1.SetActive(true);
        }

        /*if (bottomRight && bottomLeft && topRight && topLeft)
        {
            obj1.SetActive(true);
        }*/
    }

    void TriangleLogic()
    {
        if(bottomLeftVertex && bottomRightVertex && !bottomSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            bottomSide.SetActive(true);
            bottomLeftVertex = false;
        }
        if(!bottomLeftVertex && bottomRightVertex && apex && !rightSide.activeSelf)
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
