using UnityEngine;
using System.Collections;

public class U : BEInstruction
{
 
	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "12.247";

		FindObjectOfType<Meteor>().valueSet = true;
		// Use "beBlock.BeInputs" to get the input values
		
		return result;
	}
	
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		// Use "beBlock.BeInputs" to get the input values
		
		// Make sure to end the function with a "BeController.PlayNextOutside" method and use "BeController.PlayNextInside" to play child blocks if needed
		BeController.PlayNextOutside(beBlock);
	}
 
}
