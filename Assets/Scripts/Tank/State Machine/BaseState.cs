﻿using UnityEngine;

public abstract class BaseState
{
    public Vector2 InputVector { get; protected set; }
    public Vector3 FireInputVector { get; protected set; }
    
    protected StateController stateController;
    
    public virtual void Start(StateController stateController)
    {
        this.stateController = stateController;
    }

    public virtual void End()
    {
        
    }

    public abstract void Process();
    public abstract void Transition();
}
