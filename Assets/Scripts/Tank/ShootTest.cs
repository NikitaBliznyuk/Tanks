using System.Collections;
using System.Collections.Generic;
using Planet;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    public Shoot Shoot;
    public Transform Gun;

    public float power;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GravityBody instance = Instantiate(Shoot).GravityBody;
            instance.transform.position = Gun.position + Gun.forward;
            instance.ThisRigidbody.AddForce(Gun.forward * power);
        }
    }
}
