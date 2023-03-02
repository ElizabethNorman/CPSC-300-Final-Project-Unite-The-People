/** This is intended to be expanded into a larger weapons script when new weapons are added in later development
 * Hence why it is not part of IvanCollider, which it should be apart of right now. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponManager : MonoBehaviour
{
    public VariableCount varCount;
    public GameObject guns;

    // Start is called before the first frame update
    void Start()
    {
        guns.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
      
        if (other.gameObject.CompareTag("gunPickUp"))
        {
            
            guns.SetActive(true);
            Destroy(other.gameObject);
            varCount.gotGun();
        }
    }
}
