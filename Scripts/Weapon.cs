/** This script fires bullets from the gun! That's all.  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: RENAME TO MORE DESCRIPTIVE NAME 
public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPreFab;
   

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();

        }


    }

    void Shoot()
    {
        Instantiate(bulletPreFab, firepoint.position, firepoint.rotation);
    }



}
