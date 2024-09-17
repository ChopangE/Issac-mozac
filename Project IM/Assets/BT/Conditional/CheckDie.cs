using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckDie : Conditional
{
	public EnemyBase enemyBase;

	public override void OnAwake()
	{
		enemyBase = GetComponent<EnemyBase>();
	}
	
	
	public override TaskStatus OnUpdate()
	{
		if (enemyBase.CurHealth > 0)
		{
			return TaskStatus.Failure;
		}
		return TaskStatus.Success;
	}
}