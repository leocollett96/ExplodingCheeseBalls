using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <-0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    internal void CalculateHealth(float damage)
    {
        throw new NotImplementedException();
    }
}
