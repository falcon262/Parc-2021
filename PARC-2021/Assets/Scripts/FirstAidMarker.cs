using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidMarker : MonoBehaviour
{
    public Manager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "FirstAid")
        {
            other.transform.gameObject.SetActive(false);
            manager.amb.SetTrigger("Drive");
            manager.score += 20;
            manager.ScoreText.text = "SCORE: " + manager.score;
            manager.obj2.SetActive(true);
        }
    }
}
