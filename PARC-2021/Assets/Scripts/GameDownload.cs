using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDownload : MonoBehaviour
{
    public Button PC;
    private const string downloadLink = "https://parcrobotics.org/ParcodeV2/parcode_offline_PARC2021.zip";
    // Start is called before the first frame update
    void Start()
    {
        PC.onClick.AddListener(delegate
        {
            OpenGformLink();
        });
    }

    private static void OpenLink(string link)
    {
        bool googleSearch = link.Contains("google.com/search");
        string linkNoSpaces = link.Replace(" ", googleSearch ? "+" : "%20");
        Application.OpenURL(linkNoSpaces);
    }

    private static void OpenGformLink()
    {
        string urllink = downloadLink; //+ "viewform";
        OpenLink(urllink);
    }
}
