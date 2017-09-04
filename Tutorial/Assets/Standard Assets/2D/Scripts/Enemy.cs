using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    GameObject player;
    Health playerHealth;                  // Reference to the player's health.
    bool playerInRange = false;
    float timer;
    bool playerDead = false;
    public Transform target;
    public float speed;

    public float timeBetweenAttacks = 1f;     // The time in seconds between each attack.
    public const int attackDamage = 25;               // The amount of health taken away per attack.

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        playerHealth = player.GetComponent<Health>();

        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

        transform.Translate(Vector3.up * Time.deltaTime * speed);

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            // ... attack.
            Debug.Log("attack");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the entering collider is the player...
        if (collision.gameObject.name == "Player")
        {
            // ... the player is in range.
            playerInRange = true;
            Debug.Log("Playr in range");
        }

        if (playerDead == true)
        {
            if (collision.gameObject.name == "Player")
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the exiting collider is the player...
        if (collision.gameObject.name == "Player")
        {
            // ... the player is no longer in range.
            playerInRange = false;
            Debug.Log("Playr out range");
        }

        if (playerDead == true)
        {
            if (collision.gameObject.name == "Player")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
