using UnityEngine;
using System.Collections;

public class ReleaseObject : BEInstruction
{
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		
		// Use "beBlock.BeInputs" to get the input values
		
		return result;
	}
	
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		// Use "beBlock.BeInputs" to get the input values

		GameObject robotClaw = GameObject.FindGameObjectWithTag("Claw").gameObject;
		GameObject environment = GameObject.FindGameObjectWithTag("Environment").gameObject;

		if (robotClaw.transform.Find("Animal"))
		{
			robotClaw.transform.Find("Animal").gameObject.transform.SetParent(environment.transform);
		}
		else if (robotClaw.transform.Find("Child"))
		{
			robotClaw.transform.Find("Child").gameObject.transform.SetParent(environment.transform);
		}
		else if (robotClaw.transform.Find("Adult"))
		{
			robotClaw.transform.Find("Adult").gameObject.transform.SetParent(environment.transform);
		}
		else if (robotClaw.transform.Find("Barricade"))
		{
			robotClaw.transform.Find("Barricade").gameObject.transform.SetParent(environment.transform);
		}
		else if (robotClaw.transform.Find("Sphere(Clone)"))
		{
			robotClaw.transform.Find("Sphere(Clone)").gameObject.transform.SetParent(environment.transform);
			GameObject.Find("Sphere(Clone)").gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}

		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
