using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float startingHealth = 100;

    public Slider healthSlider;
    bool damaged = false;
    bool isDead = false;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;

        healthSlider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(25);
        }

        if (damaged)
        {
            //animation for taking damage
        }

        damaged = false;

    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        healthSlider.value = CalculateHealth();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    float CalculateHealth()
    {
        return currentHealth / startingHealth;
    }

    void Death()
    {
        //death animtion
        Debug.Log("Dead.");

    }
}