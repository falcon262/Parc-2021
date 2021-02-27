using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCam : MonoBehaviour
{
    public GameObject Challenges;

    public void SpawnChallenges()
    {
        Challenges.SetActive(true);
    }
}
