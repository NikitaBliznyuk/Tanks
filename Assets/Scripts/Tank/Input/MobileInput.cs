using UnityEngine;

public class MobileInput : InputController
{
    protected override void Update()
    {
        
    }

    private bool fireKeyDown;
    private bool fireKeyUp;
    private bool fireKey;

    public void Up(bool pressed)
    {
        Vector3 input = InputVector;
        input.y = pressed ? 1.0f : 0.0f;
        InputVector = input;
    }

    public void Down(bool pressed)
    {
        Vector3 input = InputVector;
        input.y = pressed ? -1.0f : 0.0f;
        InputVector = input;
    }

    public void Left(bool pressed)
    {
        Vector3 input = InputVector;
        input.x = pressed ? -1.0f : 0.0f;
        InputVector = input;
    }

    public void Right(bool pressed)
    {
        Vector3 input = InputVector;
        input.x = pressed ? 1.0f : 0.0f;
        InputVector = input;
    }

    public void OnPointerDown()
    {
        fireKey = true;
        fireKeyDown = true;
    }

    public void OnPointerUp()
    {
        fireKey = false;
        fireKeyUp = true;
    }

    public override bool GetFireKeyDown()
    {
        bool temp = fireKeyDown;
        fireKeyDown = false;
        return temp;
    }

    public override bool GetFireKeyUp()
    {
        bool temp = fireKeyUp;
        fireKeyUp = false;
        return temp;
    }

    public override bool GetFireKey()
    {
        return fireKey;
    }
}
