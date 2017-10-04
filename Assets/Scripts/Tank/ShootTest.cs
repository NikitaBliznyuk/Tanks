﻿using Planet;
using Tank.Shoot;
using UnityEngine;
using UnityEngine.UI;

public class ShootTest : MonoBehaviour
{
    public Shoot Shoot;
    public Transform Gun;
    public Transform ShootSpawn;
    public Slider CharginSlider;

    public float power;
    public float maxChargeTime;

    private float currentCharge;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentCharge = 0.2f;
        } 
        else if (Input.GetKey(KeyCode.Space))
        {
            currentCharge += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            float t = Mathf.Clamp(currentCharge / maxChargeTime, 0.2f, 1.0f);
            GravityBody instance = Instantiate(Shoot, ShootSpawn.position, Quaternion.identity).GravityBody;
            instance.ThisRigidbody.AddForce(Gun.forward.normalized * power * t, ForceMode.Force);
            currentCharge = 0.0f;
        }

        CharginSlider.value = Mathf.Clamp(currentCharge, 0.0f, 1.0f);
    }
}
