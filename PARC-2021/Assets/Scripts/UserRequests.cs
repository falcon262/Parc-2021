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

public class UserRequests : MonoBehaviour
{
    [Serializable]
    public struct userInfo
    {
        public string code;
        public string result;
        public string userid;
        public string token;
        public string name;
        public string username;
        public string email;
        public int maxscore;
    }
    userInfo info;

    public TextMeshProUGUI username;
    public TextMeshProUGUI highscore;


    public GameObject MainMenu;
    public GameObject LoginMenu;
    public Animator InvalidDetails;
    public TMP_InputField userNameInput;
    public TMP_InputField passwordInput;
    public Button Submit;
    public Controller controller;


    private const string BaseURL = "https://parcrobotics.org/index.php?option=com_games&task=games.login";


    /*    private void Awake()
        {
            StartCoroutine(FetchUrl());
        }*/

    private void Start()
    {
        if (!Controller.userEntered)
        {
            Submit.onClick.AddListener(delegate
            {
                StartCoroutine(SigninRequest(userNameInput.text, passwordInput.text));
            });
        }
        else
        {
            LoginMenu.SetActive(false);
            MainMenu.SetActive(true);
            StartCoroutine(SigninRequest(Controller.Entryname, Controller.password));
        }

    }


    IEnumerator SigninRequest(string Username, string Password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", Username);
        form.AddField("password", Password);
        form.AddField("securityid", "ejT2dtEeas9jePrE8jTTZ2xKEPYdnQ2d");

        using (UnityWebRequest www = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.login", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                //NoInternet.SetActive(true);
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
                if (www.downloadHandler.text.Contains("404"))
                {
                    InvalidDetails.SetTrigger("Invalid");
                }
                else if (www.downloadHandler.text.Contains("200"))
                {
                    Controller.password = Password;
                    Controller.Entryname = Username;
                    if (!MainMenu.activeSelf && LoginMenu.activeSelf)
                    {
                        MainMenu.SetActive(true);
                        LoginMenu.SetActive(false);
                    }
                    info = JsonUtility.FromJson<userInfo>(www.downloadHandler.text);
                    Controller.username = info.name;
                    Controller.token = info.token;
                    Controller.Highscore = info.maxscore;
                    username.text = "HI " + info.name;
                    highscore.text = "HIGHSCORE: " + info.maxscore;
                    Controller.userEntered = true;

                    StartCoroutine(controller.UserDetails());
                }
            }
        }

    }

    /*IEnumerator FetchUrl()
    {
        string token;
        //"https://parcrobotics.org/index.php?option=com_games&task=game.load&data=P8222F&game=Tech"
        string embedUrl = Application.absoluteURL;
        using (UnityWebRequest www = UnityWebRequest.Get(embedUrl))
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
                //Debug.Log(www.url);
                string someUrl = www.url;
                string urlstring = someUrl;
                int startindex = 72;
                int endindex = 6;
                token = urlstring.Substring(startindex, endindex);
                //Debug.Log(token);
                //tokenText.text = token;


                WWWForm form = new WWWForm();
                form.AddField("token", token);
                form.AddField("securityid", "ejT2dtEeas9jePrE8jTTZ2xKEPYdnQ2d");

                using (UnityWebRequest userRequest = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.userinfo", form))
                {
                    yield return userRequest.SendWebRequest();

                    if (userRequest.isNetworkError || www.isHttpError)
                    {
                        Debug.Log(userRequest.error);
                    }
                    else
                    {
                        StringBuilder feedback = new StringBuilder();
                        foreach (KeyValuePair<string, string> dict in userRequest.GetResponseHeaders())
                        {
                            feedback.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
                        }

                        //Print Headers
                        //Debug.Log(feedback.ToString());

                        //Print Body
                        //Debug.Log(userRequest.downloadHandler.text);

                        info = JsonUtility.FromJson<userInfo>(userRequest.downloadHandler.text);
                        Controller.username = info.name;
                        Controller.token = info.token;
                        Controller.Highscore = info.maxscore;
                        username.text = "HI " + info.name;
                        highscore.text = "HIGHSCORE: " + info.maxscore;

                        StartCoroutine(controller.UserDetails());
                        //StartCoroutine(Controller.UserDetails());
                        //Debug.Log(Controller.username);
                        //Debug.Log(Controller.token);
                        //Debug.Log(Controller.Highscore);

                        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                    }
                }

            }
        }

    }*/
}
