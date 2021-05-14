using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    [Serializable]
    public struct userSettings
    {
        public string code;
        public string result;
        public string username;
        public string user_game_settings;
    }
    static userSettings usersettings;

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
    static userInfo info;

    //public int LevelNum;
    static bool isEnglish;
    public static Controller instance;
    public static string username;
    public static string password;
    public static string Entryname;
    public static string token;
    public static int Highscore;
    public static int c1Highscore = 0;
    public static int c2Highscore = 0;
    public static int c3Highscore = 0;
    public static int c4Highscore = 0;
    public static bool userEntered = false;
    public static string previousSettings = "";
    public static List<string> codeName = new List<string>();
    public static List<string> serverCode = new List<string>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

/*    public static IEnumerator User_Info()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "l3k5lrAHZ2UVcJtSdi57UC3zNhItf9");

        using (UnityWebRequest userRequest = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.userinfo", form))
        {
            yield return userRequest.SendWebRequest();

            if (userRequest.isNetworkError || userRequest.isHttpError)
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
                Controller.Highscore = info.maxscore;
            }
        }
    }*/

    public IEnumerator UserDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "ejT2dtEeas9jePrE8jTTZ2xKEPYdnQ2d");
        //form.AddField("settings", "sounds:"+"on");
        //form.AddBinaryData("settings", File.ReadAllBytes(Application.persistentDataPath + "/SavedCodes/"), Path.GetFileName(Application.persistentDataPath + "/SavedCodes/somefile.BE"));

        using (UnityWebRequest www = UnityWebRequest.Post("https://parcrobotics.org/index.php?option=com_games&task=games.usersetting", form))
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
                Debug.Log(www.downloadHandler.text);

                usersettings = JsonUtility.FromJson<userSettings>(www.downloadHandler.text);
                if(usersettings.user_game_settings == "")
                {
                    StartCoroutine(UpdateUserDetails(Highscore.ToString(), c2Highscore.ToString(), c3Highscore.ToString(), c4Highscore.ToString()));
                }
                else
                {
                    string[] scores = usersettings.user_game_settings.Split(':');
                    if(scores.Length == 3)
                    {
                        StartCoroutine(UpdateUserDetails(scores[0], scores[1], scores[2], c4Highscore.ToString()));
                    }
                    else
                    {
                        c1Highscore = int.Parse(scores[0]);
                        c2Highscore = int.Parse(scores[1]);
                        c3Highscore = int.Parse(scores[2]);
                        c4Highscore = int.Parse(scores[3]);
                    }                    
                }
                //Debug.Log(usersettings.user_game_settings);

                //Controller.previousSettings = usersettings.user_game_settings;
                //Debug.Log(Controller.previousSettings);
                //string[] settings = usersettings.user_game_settings.Split('#');


               /* try
                {
                    Controller.codeName.Add(settings[0]);
                    Debug.Log(Controller.codeName[0]);
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }

                try
                {
                    for (int i = 0; i < settings.Length; i++)
                    {
                        Controller.serverCode.Add(settings[i + 1]);
                        Debug.Log(Controller.serverCode[i]);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }*/



            }
        }

    }

    IEnumerator UpdateUserDetails(string c1, string c2, string c3, string c4)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", Controller.token);
        form.AddField("securityid", "ejT2dtEeas9jePrE8jTTZ2xKEPYdnQ2d");
        form.AddField("settings", c1 + ":" + c2 + ":" + c3 + ":" + c4);
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

                c1Highscore = int.Parse(c1);
                c2Highscore = int.Parse(c2);
                c3Highscore = int.Parse(c3);
                c4Highscore = int.Parse(c4);
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

    public static void SetEnglish(bool lang)
    {
        isEnglish = lang;        
    }

    public static bool GetIsEnglish()
    {
        return isEnglish;
    }
}
