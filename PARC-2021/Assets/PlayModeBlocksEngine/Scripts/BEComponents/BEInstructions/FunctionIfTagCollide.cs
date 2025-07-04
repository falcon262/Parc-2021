﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FunctionIfTagCollide : BEInstruction
{
    string value;
    
    public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
    {
        if (targetObject.GetComponent<Collider2D>())
        {
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(targetObject.transform.position, transform.localScale / 2, 0);
            int i = 0;

            while (i < hitColliders.Length)
            {
                value = "0";
                if (beBlock.BeInputs.stringValues[0] == hitColliders[i].tag)
                {
                    value = "1";
                    break;
                }
                i++;
            }
        }
        else if (targetObject.GetComponent<Collider>())
        {
            
            //Collider[] hitColliders = Physics.OverlapBox(targetObject.transform.position, transform.localScale / 2, Quaternion.identity);

            value = "0";
            RaycastHit hit;
            if (Physics.Raycast(targetObject.transform.position, targetObject.transform.TransformDirection(Vector3.forward), out hit, 15f))
            {
                if (beBlock.BeInputs.stringValues[0] == hit.transform.gameObject.tag)
                {
                    value = "1";
                }
                else
                    value = "0";
            }
            /*int i = 0;

            while (i < hitColliders.Length)
            {
                value = "0";
                Debug.Log("Hit : " + hitColliders[i].name + i);
                if (beBlock.BeInputs.stringValues[0] == hitColliders[i].tag)
                {
                    value = "1";
                    break;
                }
                i++;
            }*/
        }

        return value;
    }

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        if (BEOperation(targetObject, beBlock) == "1")
        {
            BeController.PlayNextInside(beBlock);
        }
        else
        {
            BeController.PlayNextOutside(beBlock);
        }
    }
    
}
