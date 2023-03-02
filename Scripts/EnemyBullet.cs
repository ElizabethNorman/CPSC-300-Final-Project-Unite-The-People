using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;

    Vector2 moveDirection;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("ivan");

        moveDirection = ((target.transform.position - transform.position).normalized* moveSpeed);
        Debug.Log(moveDirection.x + " " + moveDirection.y);
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("ivan"))
        {
            
            Destroy(gameObject);
            
        }
    }

    
}
