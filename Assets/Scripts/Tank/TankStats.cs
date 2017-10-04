using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankStats : MonoBehaviour, IVulnerable
{
    [Header("References")]
    [SerializeField]
    private HealthUi healthUi;
    
    [Header("Settings")]
    [SerializeField]
    private float maxHealth = 100.0f;

    [SerializeField]
    private float shootDamage = 25.0f;

    public float CurrentHealth { get; private set; }

    public float ShootDamage
    {
        get { return shootDamage; }
    }

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        healthUi.SetValue(CurrentHealth / maxHealth);
    }

    public void DealDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0.0f, maxHealth);
        
        if (CurrentHealth <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
