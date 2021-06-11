using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1 : MonoBehaviour
{
    public Manager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "F2" && other.gameObject.tag == "Robot")
        {
            manager.score += 150;
            manager.ScoreText.text = manager.score.ToString();
            manager.obj1.SetActive(true);
        }
    }
}
