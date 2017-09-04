using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    GameObject player;
    Health playerHealth;                  // Reference to the player's health.
    Health enemyHealth;
    bool playerInRange = false;
    float timer;
    bool playerDead = false;

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public const int attackDamage = 25;               // The amount of health taken away per attack.

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            playerDead = true;
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }

        if(playerDead == true)
        {
            if (other.gameObject.name == "Player")
            {
                Destroy(other.gameObject);
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }

        if (playerDead == true)
        {
            if (other.gameObject.name == "Player")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
