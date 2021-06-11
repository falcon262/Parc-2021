using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    public LayerMask m_LayerMask;

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (this.gameObject.tag == "2" && hitColliders[i].transform.gameObject.tag == "blueball")
            {
                FindObjectOfType<Manager>().num2 = true;
            }
            if (this.gameObject.tag == "4" && hitColliders[i].transform.gameObject.tag == "blueball")
            {
                FindObjectOfType<Manager>().num4 = true;
            }
            if (this.gameObject.tag == "6" && hitColliders[i].transform.gameObject.tag == "blueball")
            {
                FindObjectOfType<Manager>().num6 = true;
            }
            if (this.gameObject.tag == "8" && hitColliders[i].transform.gameObject.tag == "blueball")
            {
                FindObjectOfType<Manager>().num8 = true;
            }
            if (this.gameObject.tag == "10" && hitColliders[i].transform.gameObject.tag == "blueball")
            {
                FindObjectOfType<Manager>().num10 = true;
            }
        }
    }

}
