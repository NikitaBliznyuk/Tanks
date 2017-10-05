using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FiringState : BaseState
{
    private Transform fireTarget;
    
    public override void Process()
    {
        InputVector = GetInput();
        FireInputVector = GetFireInput();
        
        Collider[] enemies = Physics.OverlapSphere(stateController.transform.position, 5.0f);
        try
        {
            fireTarget = enemies.Select(col => col.transform).First(t => t.CompareTag("Player"));
        }
        catch (InvalidOperationException)
        {
            fireTarget = null;
            FireInputVector = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }

    private Vector2 GetInput()
    {
        Vector2 input = Vector2.zero;

        input.y = 0.0f;
        input.x = 0.5f;
        
        return input;
    }

    private float chargeDelay = 0.0f;
    private float currentDelay = -1.0f;

    private Vector3 GetFireInput()
    {
        Vector3 input = Vector3.zero;

        if (currentDelay >= 0.0f && currentDelay < chargeDelay)
        {
            input.z = 1.0f;
            currentDelay += Time.deltaTime;
        }
        else if (currentDelay >= chargeDelay)
        {
            input.y = 1.0f;
            currentDelay = -1.0f;
        }
        else
        {
            chargeDelay = Random.Range(0.2f, 0.5f);
            currentDelay = 0.0f;
            input.x = 1.0f;
        }

        return input;
    }

    public override void Transition()
    {
        if(fireTarget == null)
            stateController.ChangeState(new DrivingState());
    }
}
