using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerMain : BEInstruction
{
    //Vector3[] passengerPositions =  new Vector3[3];
    GameObject[] items = new GameObject[3];
    int randomVal1;
    int randomVal2;
    
    private void Shuffle()
    {
        GameObject FirstAid = GameObject.FindGameObjectWithTag("FirstAid");
        GameObject Safe = GameObject.FindGameObjectWithTag("Safe");
        //GameObject Child = GameObject.FindGameObjectWithTag("Child");

        items[0] = FirstAid;
        items[1] = Safe;
       

        randomVal1 = Random.Range(0, 2);
        randomVal2 = Random.Range(0, 2);
        while (randomVal1 == randomVal2)
        {
            randomVal2 = Random.Range(0, 2);
        }
        Debug.Log("rand 1: " + randomVal1 + "  rand 2: " + randomVal2);
        Vector3 temp = items[randomVal1].gameObject.transform.position;
        items[randomVal1].gameObject.transform.position = items[randomVal2].gameObject.transform.position;
        items[randomVal2].gameObject.transform.position = temp;

        /*passengerPositions[2] = Child;

        

        Vector3 temp = passengerPositions[randomVal1].transform.position;
        passengerPositions[randomVal1].transform.position = passengerPositions[randomVal2].transform.position;
        passengerPositions[randomVal2].transform.position = temp;*/
    }

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        if(beBlock.BeBlockGroup.isActive)
        {
            if (SceneManager.GetActiveScene().name == "Challenge 1")
            {
                for (int i = 0; i < Random.Range(0, 10); i++)
                {
                    Shuffle();
                }
            }
            if (SceneManager.GetActiveScene().name != "Challenge 4" && SceneManager.GetActiveScene().name != "Challenge 5")
            {
                StartCoroutine(GameObject.FindObjectOfType<Manager>().StartTimer());
            }
            else if (SceneManager.GetActiveScene().name == "Challenge 4" && !FindObjectOfType<Manager>().timeStartsOnce)
            {
                StartCoroutine(GameObject.FindObjectOfType<Manager>().StartTimer());
            }
            BeController.PlayNextInside(beBlock);
                          
        }
    }
}
