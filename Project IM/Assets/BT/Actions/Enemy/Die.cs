using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Die : Action
{
	protected Animator anim;
	public override void OnAwake()
	{
		anim = GetComponent<Animator>();
	}
	
	public override void OnStart()
	{
		Debug.Log("Slime Die");
	}

	
}