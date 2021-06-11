using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{

    public GameObject alert;
    public TextMeshProUGUI alertText;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI eventinfo;
    public TextMeshProUGUI startGame;
    public TextMeshProUGUI selectChallenge;
    public TextMeshProUGUI pleaseWait;
    public Button ENG;
    public Button FR;
    public UserRequests requests;

    private void Start()
    {
        Controller.SetEnglish(true);
        ENG.onClick.AddListener(delegate
        {
            ENGLISH();
        });
        
        FR.onClick.AddListener(delegate
        {
            FRENCH();
        });
    }

    public void OpenChallenge1()
    {
        SceneManager.LoadScene("Challenge 1");
    }
    public void OpenChallenge2()
    {
        SceneManager.LoadScene("Challenge 2");
    }
    public void OpenChallenge3()
    {
        SceneManager.LoadScene("Challenge 3");
    }
    public void OpenChallenge4()
    {
        SceneManager.LoadScene("Challenge 4");
    }
    public void OpenChallenge5()
    {
        SceneManager.LoadScene("Challenge 5");
    }
    public void OpenChallenge6()
    {
        SceneManager.LoadScene("Challenge 6");
    }
    public void Okay()
    {
        alert.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    void ENGLISH()
    {
        Controller.SetEnglish(true);
        startGame.text = "START";
        pleaseWait.text = "Please Wait...";
        selectChallenge.text = "Select Challenge";
        alertText.text = "The 2021 TECHS League Competition begins April 1 and ends June 30, 2021. Every two weeks a new challenge will be available in a new country. With each new challenge previous challenges will still be available for teams to continue working. Scores from each challenge will be added together. Teams with the top scores at the end of the competition wins.";
        eventinfo.text = "The next challenge will be available June 11, 2021.";
        requests.username.text = "HI " + Controller.username;
        requests.highscore.text = "HIGHSCORE: " + Controller.Highscore;
    }

    void FRENCH()
    {
        Controller.SetEnglish(false);
        startGame.text = "DÉBUT";
        pleaseWait.text = "S'il vous plaît, attendez...";
        selectChallenge.text = "Sélectionnez un défi";
        alertText.text = "La compétition de la Ligue TECHS 2021 commence le 1er avril et se termine le 30 juin 2021. Toutes les deux semaines, un nouveau défi sera disponible dans un nouveau pays. Avec chaque nouveau défi, les défis précédents seront toujours disponibles pour que les équipes continuent à travailler. Les scores de chaque défi seront additionnés. Les équipes avec les meilleurs scores à la fin de la compétition l'emportent.";
        eventinfo.text = "Le prochain défi sera disponible le 11 juin 2021.";
        requests.username.text = "SALUT " + Controller.username;
        requests.highscore.text = "SCORE ÉLEVÉ: " + Controller.Highscore;
    }
}
