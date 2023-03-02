using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtPlayer : MonoBehaviour
{
    public GameObject coin;

    float fireRate;
    float nextFire;

    public EnemyAI enemyAI;

    //public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {

        fireRate = 1f;
        nextFire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAI.getHasTarget() == true) 
        {
            CheckIfTimeToFire();
        }
        

    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(coin, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;

        }
    }
}
