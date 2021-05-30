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
    public bool timeUp;
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

    [Header("Challenge 3 - Blockly Challenges")]
    public GameObject Move;
    public GameObject Rotate;
    public GameObject Turn;
    public GameObject TurnLeft;
    public GameObject TurnRight;
    public GameObject FaceForward;
    public GameObject CarryObject;
    public GameObject ReleaseObject;
    public GameObject FuncitonIf;
    public GameObject FunctionRepeat;
    public GameObject FunctionRepeatForever;
    public GameObject FunctionRepeatUntil;
    public GameObject FunctionWait;
    public GameObject Sound;
    public GameObject Operators;
    public GameObject Sensors;
    public GameObject LogicGates;
    public GameObject Variables;
    public int blockCount = 0;
    public GameObject M1;
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;
    public GameObject F1;
    public GameObject F2;
    public GameObject F3;
    public GameObject F4;
    public GameObject Robot;
    public Vector3 initPos;
    public bool timeStartsOnce = false;
    bool tick1 = false;
    public Slider temp;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            score = 0;
            ScoreText.text = score.ToString();
            if(SceneManager.GetActiveScene().name == "Challenge 4")
            {
                initPos = Robot.transform.position;
                
                Rotate.SetActive(false);
                Turn.SetActive(false);
                FaceForward.SetActive(false);
                CarryObject.SetActive(false);
                ReleaseObject.SetActive(false);
                FuncitonIf.SetActive(false);
                FunctionRepeatForever.SetActive(false);
                FunctionRepeatUntil.SetActive(false);
                FunctionWait.SetActive(false);
                Sound.SetActive(false);
                Operators.SetActive(false);
                Sensors.SetActive(false);
                LogicGates.SetActive(false);
                Variables.SetActive(false);
            }
        }
        catch (Exception except)
        {
            Debug.Log(except.Source);
            Debug.Log(except.Data);
            Debug.Log(except.ToString());
        }
        
    }

    private void Update()
    {
        if(timer <= 0 && timeUp)
        {
            timeUp = false;
            LoseScreen.SetActive(true);
            LoseScore.text = "Score: " + score;
            if(SceneManager.GetActiveScene().name == "Challenge 1")
            {
                if (score > Controller.c1Highscore)
                {
                    Controller.c1Highscore = score;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 2")
            {
                if (score > Controller.c2Highscore)
                {
                    Controller.c2Highscore = score;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 3")
            {
                if (score > Controller.c3Highscore)
                {
                    Controller.c3Highscore = score;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 4")
            {
                if (score > Controller.c4Highscore)
                {
                    Controller.c4Highscore = score;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 5")
            {
                if (score > Controller.c5Highscore)
                {
                    Controller.c5Highscore = score;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            StartCoroutine(UpdateScore(Controller.c1Highscore + Controller.c2Highscore + Controller.c3Highscore + Controller.c4Highscore + Controller.c5Highscore));
        }
        else if (obj1.activeSelf && obj2.activeSelf && !youWin)
        {
            youWin = true;
            WinScreen.SetActive(true);
            WinScore.text = "Score: " + (int)(score + timer);
            int challengeWinScore = (int)(score + timer);
            if (SceneManager.GetActiveScene().name == "Challenge 1")
            {
                if (challengeWinScore > Controller.c1Highscore)
                {
                    Controller.c1Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 2")
            {
                if (challengeWinScore > Controller.c2Highscore)
                {
                    Controller.c2Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 3")
            {
                if (challengeWinScore > Controller.c3Highscore)
                {
                    Controller.c3Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 4")
            {
                if (challengeWinScore > Controller.c4Highscore)
                {
                    Controller.c4Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 5")
            {
                if (challengeWinScore > Controller.c5Highscore)
                {
                    Controller.c5Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }
            }

            StartCoroutine(UpdateScore(Controller.c1Highscore + Controller.c2Highscore + Controller.c3Highscore + Controller.c4Highscore + Controller.c5Highscore));
        }
        else if (SceneManager.GetActiveScene().name == "Challenge 3" && obj1.activeSelf && !youWin)
        {
            youWin = true;
            WinScreen.SetActive(true);
            WinScore.text = "Score: " + (int)(score + timer);
            int challengeWinScore = (int)(score + timer);
            
                if (challengeWinScore > Controller.c3Highscore)
                {
                    Controller.c3Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }

            StartCoroutine(UpdateScore(Controller.c1Highscore + Controller.c2Highscore + Controller.c3Highscore + Controller.c4Highscore + Controller.c5Highscore));
        }
        else if (SceneManager.GetActiveScene().name == "Challenge 5" && obj1.activeSelf && !youWin)
        {
            youWin = true;
            WinScreen.SetActive(true);
            WinScore.text = "Score: " + (int)(score + timer);
            int challengeWinScore = (int)(score + timer);
            
                if (challengeWinScore > Controller.c5Highscore)
                {
                    Controller.c5Highscore = challengeWinScore;
                    StartCoroutine(UpdateUserDetails(Controller.c1Highscore.ToString(), Controller.c2Highscore.ToString(), Controller.c3Highscore.ToString(), Controller.c4Highscore.ToString(), Controller.c5Highscore.ToString()));
                }

            StartCoroutine(UpdateScore(Controller.c1Highscore + Controller.c2Highscore + Controller.c3Highscore + Controller.c4Highscore + Controller.c5Highscore));
        }
        RectangleLogic();
        TriangleLogic();
        Challenge3Logic();
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

    IEnumerator UpdateUserDetails(string c1, string c2, string c3, string c4, string c5)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "ejT2dtEeas9jePrE8jTTZ2xKEPYdnQ2d");
        form.AddField("settings", c1 + ":" + c2 + ":" + c3 + ":" + c4 + ":" + c5);
        //form.AddField("settings", "sounds:"+"on");
        //form.AddBinaryData("settings", File.ReadAllBytes(Application.persistentDataPath + "/SavedCodes/"), Path.GetFileName(Application.persistentDataPath + "/SavedCodes/somefile.BE"));

        using (UnityWebRequest www = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.updateusersetting", form))
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
                //Debug.Log(sb.ToString());

                //Print Body
                //Debug.Log(www.downloadHandler.text);


                //Controller.codeName.Clear();
                //Controller.serverCode.Clear();
                //StartCoroutine(Controller.UserDetails());
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

    void Challenge3Logic()
    {
        if(SceneManager.GetActiveScene().name == "Challenge 4")
        {
            temp.value = blockCount;
            if (obj1.activeSelf && !tick1)
            {
                M1.SetActive(false);
                M2.SetActive(true);
                FuncitonIf.SetActive(true);
                Sensors.SetActive(true);
                FindObjectOfType<BEController>().MainStop();
                FindObjectOfType<BEController>().Play.interactable = true;
                FindObjectOfType<SaveLoadCode>().BEClearCode();
                timeStartsOnce = true;
                tick1 = true;
                blockCount = 0;
                Robot.transform.position = initPos;
            }

            if(blockCount > 7)
            {
                RestartScene();
            }
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
            ScoreText.text = score.ToString();
            obj1.SetActive(true);
        }
        else if (bottomRight && topRight && topLeft && bottomLeft && !left.activeSelf)
        {
            Rectangle.transform.Translate(0, 4.30075f, 0);
            left.SetActive(true);
            score += 50;
            ScoreText.text = score.ToString();
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
            ScoreText.text = score.ToString();
            obj2.SetActive(true);
        }
        else if (bottomLeftVertex && bottomRightVertex && apex && !bottomSide.activeSelf)
        {
            Triangle.transform.Translate(0, 5.734333333f, 0);
            bottomSide.SetActive(true);
            score += 50;
            ScoreText.text = score.ToString();
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
            timerText.text = "0" + minutes + ":" + seconds;
        }
        else if (minutes < 10 && seconds < 10)
        {
            timerText.text = "0" + minutes + ":0" + seconds;
        }
        else if (minutes > 9 && seconds < 10)
        {
            timerText.text = minutes + ":0" + seconds;
        }
        else
        {
            timerText.text = minutes + ":" + seconds;
        }
    }
}
