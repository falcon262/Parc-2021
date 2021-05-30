using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge5 : MonoBehaviour
{
    public GameObject Earth;
    public float earthSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Earth.transform.Rotate(0, -earthSpeed, 0);
    }
}
