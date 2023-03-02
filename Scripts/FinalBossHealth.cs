/** This script controls Elon's health and health bar 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealth : MonoBehaviour
{

    int maxHealth = 250;
    int currentHealth;

    public HealthBar healthBar;

    public GameObject bossUI;

    public GameObject Marx;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("health is: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        bossUI.SetActive(false);
        Marx.SetActive(true);
    }

}
