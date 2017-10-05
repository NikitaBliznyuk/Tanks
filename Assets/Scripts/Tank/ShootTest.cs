﻿using Tank.Shoot;
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

    private TankStats stats;
    private InputController inputController;

    private void Awake()
    {
        stats = GetComponent<TankStats>();
        inputController = GetComponent<InputController>();
    }

    private void Update()
    {
        if (inputController.GetFireKeyDown())
        {
            currentCharge = 0.2f;
        }
        else if (inputController.GetFireKey())
        {
            currentCharge += Time.deltaTime;
        }
        else if (inputController.GetFireKeyUp())
        {
            float t = Mathf.Clamp(currentCharge / maxChargeTime, 0.2f, 1.0f);
            Shoot instance = Instantiate(Shoot, ShootSpawn.position, Quaternion.identity);
            instance.Damage = stats.ShootDamage;
            instance.GravityBody.ThisRigidbody.AddForce(Gun.forward.normalized * power * t, ForceMode.Force);
            currentCharge = 0.0f;
        }
        else
        {
            currentCharge = 0.0f;
        }

        CharginSlider.value = Mathf.Clamp(currentCharge, 0.0f, 1.0f);
    }
}
