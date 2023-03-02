using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisualAir : MonoBehaviour
{
    SpriteRenderer sprite;
    EnemyHealth health;
    Color color;
    EnemyAI ai;
    bool facing;

    float blue, red, green;



    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        health = gameObject.GetComponentInParent<EnemyHealth>();
        ai = gameObject.GetComponentInParent<EnemyAI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        facing = ai.returnFacing();
        if (facing == true)
        {
           sprite.flipX = false;
        }
        else
        {
           sprite.flipX = true;
        }

        float healthDisplay = health.getHealth() / 100;
        red = 255;
        blue = healthDisplay * 255;
        green = healthDisplay * 255;
        color = new Color(red, blue, green);
        sprite.color = color;
        // Debug.Log("red " + red + " green " + green + " blue " + blue);




    }
}
