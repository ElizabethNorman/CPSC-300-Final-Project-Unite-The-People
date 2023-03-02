using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisual : MonoBehaviour
{

    //this is the jankiest bit of code I have placed in this program. This is shame. I am sad. 
    public Animator ani;
    public EnemyHealth health;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (health.getHealth() <= 0)
        {
            isDead = true;
            ani.SetBool("isDead", isDead);
        }


       

        
    }

    
}
