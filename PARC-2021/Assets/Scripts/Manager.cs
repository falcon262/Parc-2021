using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    // Start is called before the first frame update
    void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
    }

    public void MapMenu()
    {
        SceneManager.LoadScene("MapMenu");
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
}
