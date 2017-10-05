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
}
