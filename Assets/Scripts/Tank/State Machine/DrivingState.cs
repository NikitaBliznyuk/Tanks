using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingState : BaseState {

	public override void Process()
	{
		InputVector = new Vector2(0.5f, 1.0f);
	}

	public override void Transition()
	{
		
	}
}
