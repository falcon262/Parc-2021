using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1 : MonoBehaviour
{
    public Manager manager;
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "F1" && other.gameObject.tag == "Robot")
        {
            manager.obj1.SetActive(true);
            manager.score += 30;
            manager.ScoreText.text = manager.score.ToString();
        }
        else if (this.gameObject.tag == "F2" && other.gameObject.tag == "Robot")
        {
            manager.score += 70;
            manager.ScoreText.text = manager.score.ToString();
            manager.obj2.SetActive(true);
        }
    }
}
