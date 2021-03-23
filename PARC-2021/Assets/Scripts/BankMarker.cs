using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMarker : MonoBehaviour
{
    public Manager manager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Safe")
        {
            manager.score += 30;
            manager.ScoreText.text = "SCORE: " + manager.score;
            manager.obj1.SetActive(true);
        }
    }
}
