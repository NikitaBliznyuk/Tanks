using UnityEngine;

public class StateController : MonoBehaviour
{
    public InputController InputController { get; private set; }

    public BaseState CurrentState { get; private set; }

    private void Awake()
    {
        InputController = GetComponent<InputController>();
        
        CurrentState = new DrivingState();
        CurrentState.Start(this);
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Process();
            CurrentState.Transition();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if(CurrentState != null)
            CurrentState.End();

        CurrentState = newState;
        
        if(CurrentState != null)
            CurrentState.Start(this);
    }
}
