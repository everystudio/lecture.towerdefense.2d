using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using System;

public class Castle : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    [SerializeField] private HealthBar healthBar;

    public static UnityEvent<float> OnTakeDamage = new UnityEvent<float>();
    public static UnityEvent OnCastleDestroy = new UnityEvent();

    public float Health => currentHealth;

    private void Start()
    {
        OnTakeDamage.AddListener(TakeDamage);
        currentHealth = maxHealth;
    }

    private void TakeDamage(float arg0)
    {
        currentHealth -= arg0;
        healthBar.SetHealth(currentHealth / maxHealth);

        var impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();

        if (currentHealth <= 0)
        {
            OnCastleDestroy.Invoke();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCastleDestroy.Invoke();
        }
    }


}
