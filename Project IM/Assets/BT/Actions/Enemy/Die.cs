using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Die : Action
{
	public override void OnStart()
	{
		Debug.Log("Slime Die");
	}

	
}