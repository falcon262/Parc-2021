using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerMain : BEInstruction
{
    //Vector3[] passengerPositions =  new Vector3[3];
    GameObject[] passengerPositions = new GameObject[3];
    int randomVal1;
    int randomVal2;
    
    private void Shuffle()
    {
        GameObject Adult = GameObject.FindGameObjectWithTag("Adult");
        GameObject Animal = GameObject.FindGameObjectWithTag("Animal");
        GameObject Child = GameObject.FindGameObjectWithTag("Child");

        passengerPositions[0] = Adult;
        passengerPositions[1] = Animal;
        passengerPositions[2] = Child;

        randomVal1 = Random.Range(0, passengerPositions.Length);
        randomVal2 = Random.Range(0, passengerPositions.Length);
        while (randomVal1 == randomVal2)
        {
            randomVal2 = Random.Range(0, passengerPositions.Length);
        }

        Vector3 temp = passengerPositions[randomVal1].transform.position;
        passengerPositions[randomVal1].transform.position = passengerPositions[randomVal2].transform.position;
        passengerPositions[randomVal2].transform.position = temp;
    }

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        if(beBlock.BeBlockGroup.isActive)
        {
            if(SceneManager.GetActiveScene().name == "Main")
            {
                for (int i = 0; i < 5; i++)
                {
                    Shuffle();
                }
                GameHandler gameHandler = FindObjectOfType<GameHandler>();
                gameHandler.gameplay = true;
                gameHandler.score = 0;
                gameHandler.scoreText.text = gameHandler.score.ToString();

                BeController.PlayNextInside(beBlock);
            }
            else
            {
                BeController.PlayNextInside(beBlock);
            }
                          
        }
    }
}
