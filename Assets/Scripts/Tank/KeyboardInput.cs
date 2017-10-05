using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : InputController 
{
    protected override void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        InputVector = input;
    }
}
