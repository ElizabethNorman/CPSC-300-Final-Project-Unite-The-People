/** This simple script changes the animation of the woman found in the game so that there is indication
 * that she has recieved the word about communism 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCollider : MonoBehaviour
{

    public Animator animator;

    public VariableCount varCount;

    void OnCollisionEnter2D(Collision2D other)
    {

      

        if (other.gameObject.CompareTag("ivan") && varCount.returnManifestoCount() > 0)
        {

            animator.SetBool("IsTouched", true);
        }

    }

}
