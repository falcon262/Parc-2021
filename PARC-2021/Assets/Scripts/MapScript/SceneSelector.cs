using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    //GameObject lastbuilding = null;

    // Update is called once per frame
    void Update()
    {
        //Selector();
    }

    public void OpenChallenge1()
    {
        SceneManager.LoadScene("Challenge 1");
    }

   /* void Selector()
    {
        RaycastHit hit;
        Ray ray;
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 300.0f))
        {
            
            
            if(hit.transform.gameObject.tag == "Building")
            {
                Color buildingColor = hit.transform.gameObject.GetComponent<MeshRenderer>().material.color;
                lastbuilding = hit.transform.gameObject;
                buildingColor.a = 1;
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = buildingColor;
            }
            else if (hit.transform.gameObject.tag != "Building")
            {
                if (lastbuilding == null)
                    return;
                else
                {
                    Color buildingColor = lastbuilding.GetComponent<MeshRenderer>().material.color;
                    buildingColor.a = 0.3f;
                    lastbuilding.GetComponent<MeshRenderer>().material.color = buildingColor;
                } 
            }

        }
        
    }*/
}
