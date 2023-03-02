using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 1f;
    public Rigidbody2D rb;
    public int damage = 20;
    
    // Start is called before the first frame update
    void Start()
    {

        Vector3 shootDirection = Input.mousePosition;

        shootDirection.z = 0.0f;

        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;


        rb.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            
            enemy.TakeDamage(damage);
           

        }

        FinalBossHealth elon = hitInfo.GetComponent<FinalBossHealth>();

        if (elon != null)
        {
            elon.TakeDamage(damage);
        }

        Destroy(gameObject);

       


    }
    
}
