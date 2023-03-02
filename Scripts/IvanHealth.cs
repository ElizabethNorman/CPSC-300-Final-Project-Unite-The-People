/** This class manages Ivan's health as he heals and takes damage throughout the play of the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IvanHealth : MonoBehaviour
{

    int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void Heal(int hp)
    {

        currentHealth += hp;
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        // yield WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
