using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script exists for future expansion of a game where Ivan would be able to move alongside platforms. This was much harder than
 * anticipated and tutorials online were incomplete so we shelved this for future days
 */

public class PlatformMovement : MonoBehaviour
{
    
        private Rigidbody2D rbody;

        private bool isOnPlatform;

        //private Rigidbody2D platformRBody;

        private void Awake()
        {
            rbody = GetComponent<Rigidbody2D>();
        }


        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Platform")
            {
               // platformRBody = col.gameObject.GetComponent<Rigidbody2D>();
                isOnPlatform = true;
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag == "Platform")
            {
                isOnPlatform = false;
               // platformRBody = null;
            }
        }

        void FixedUpdate()
        {
            if (isOnPlatform)
            {
               // rbody.velocity = rbody.velocity + platformRBody.velocity;
            }
        }
}
