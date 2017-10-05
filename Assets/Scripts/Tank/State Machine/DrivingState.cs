using System.Linq;
using UnityEngine;

public class DrivingState : BaseState
{
	private float currentTime;
	private readonly float delay = 3.0f;

	public override void Start(StateController stateController)
	{
		base.Start(stateController);

		currentTime = delay;
	}

	public override void Process()
	{
		if (currentTime < delay)
		{
			currentTime += Time.deltaTime;
		}
		else
		{
			float randDeltaX = Random.Range(-0.5f, 0.5f);
			float randDeltaY = Random.Range(-0.5f, 0.5f);
			Vector3 input = InputVector;
			input.x += randDeltaX;
			input.y += randDeltaY;
			input.x = Mathf.Clamp(input.x, -1.0f, 1.0f);
			input.y = Mathf.Clamp(input.y, -1.0f, 1.0f);

			InputVector = input;

			currentTime = 0.0f;
		}
	}

	public override void Transition()
	{
		Collider[] enemies = Physics.OverlapSphere(stateController.transform.position, 5.0f);

		if (!enemies.Any(col => col.CompareTag("Player")))
			return;

		stateController.ChangeState(new FiringState());
	}
}
