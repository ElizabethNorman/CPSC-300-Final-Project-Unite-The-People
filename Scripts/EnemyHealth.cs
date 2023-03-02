/** The enemy health script controls the enemies health and kills off the enemy if it dies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;

    public bool isDead;

    

    //public GameObject deathEffect;

    void Start()
    {
        isDead = false;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("health is: " + health);

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }


    public float getHealth()
    {
        return health;
    }
}
