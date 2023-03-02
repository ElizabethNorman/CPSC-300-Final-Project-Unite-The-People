using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/* This class contains a huge block of if statements to determine what course of action to take 
 * depending on the object that Ivan collides with. Whenever Ivan collides with an object marked with a collider, the object's tagged is
 * checked and a course of action is taken.
 */

public class IvanCollider : MonoBehaviour
{
    public IvanController ivanController;

    public TMP_Text text;

    public VariableCount varCount;

    public Transform teleportTo;

    public Transform player;

    public IvanHealth health;

    public GameObject bossUI;

    public AudioSource oof;



    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            health.TakeDamage(10);
            oof.Play();
        }
        
        if (other.gameObject.CompareTag("person"))
        {

            if (varCount.returnManifestoCount() > 0)
            {
               varCount.removeManifesto();
               text.SetText("MANIFESTS: " + varCount.returnManifestoCount());

            }
        }

        if (other.gameObject.CompareTag("manifesto"))
        {
                    
            Destroy(other.gameObject);
            varCount.addManifesto();
            text.SetText("MANIFESTS: " + +varCount.returnManifestoCount());
        }

        if (other.gameObject.CompareTag("deadZone1"))
        {
            Debug.Log("dead zoned");
            ivanController.stopJump();
            player.transform.position = teleportTo.position;

        }

        if (other.gameObject.CompareTag("enemy"))
        {
            oof.Play();
            health.TakeDamage(20);

        }

        if (other.gameObject.CompareTag("bossMarker"))
        {
            bossUI.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Marx"))
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Food food = hitInfo.GetComponent<Food>();

        if (food != null)
        {
            int hp = food.GetHealthPoints();
            health.Heal(hp);
            Destroy(hitInfo.gameObject);
        }

    }
}
