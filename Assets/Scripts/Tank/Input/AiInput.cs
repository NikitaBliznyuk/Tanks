using UnityEngine;

[RequireComponent(typeof(StateController))]
public class AiInput : InputController
{
    private StateController stateController;

    private void Awake()
    {
        stateController = GetComponent<StateController>();
    }

    protected override void Update()
    {
        InputVector = stateController.CurrentState.InputVector;
    }

    public override bool GetFireKeyDown()
    {
        return stateController.CurrentState.FireInputVector.x > 0.0f;
    }

    public override bool GetFireKeyUp()
    {
        return stateController.CurrentState.FireInputVector.y > 0.0f;
    }

    public override bool GetFireKey()
    {
        return stateController.CurrentState.FireInputVector.z > 0.0f;
    }
}
