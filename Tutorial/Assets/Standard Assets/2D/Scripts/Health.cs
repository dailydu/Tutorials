using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.Experimental.UIElements;

public class Health : MonoBehaviour{    public Slider healthSlider;
    public const int startingHealth = 100;                            // The amount of health the player starts the game with.    public int currentHealth;    bool damaged = false;    bool isDead = false;    // Use this for initialization    void Start()    {        currentHealth = startingHealth;    }    // Update is called once per frame    void Update()    {        if (damaged)        {            //animation for taking damage        }        damaged = false;    }    public void TakeDamage(int amount)    {        // Set the damaged flag so the screen will flash.        damaged = true;        // Reduce the current health by the damage amount.        currentHealth -= amount;

        healthSlider.value = currentHealth;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)        {            Death();        }    }    void Death()    {        //death animtion    }}