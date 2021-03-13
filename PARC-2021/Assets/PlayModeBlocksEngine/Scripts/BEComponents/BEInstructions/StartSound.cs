using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class StartSound : BEInstruction
{
	string result;

	public bool isGo;

	// Use this for Operations
	public override string BEOperation(BETargetObject targetObject, BEBlock beBlock)
	{
		string result = "0";
		if (targetObject.soundfreq >= 0)
			result = targetObject.soundfreq.ToString();
		else if (targetObject.soundfreq >= 40)
			result = targetObject.soundfreq.ToString();
		else if (targetObject.soundfreq >= 80)
			result = targetObject.soundfreq.ToString();
		else if (targetObject.soundfreq == 0)
			result = targetObject.soundfreq.ToString();

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
