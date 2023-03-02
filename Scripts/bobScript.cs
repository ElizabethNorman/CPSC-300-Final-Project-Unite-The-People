/** This script allows objects to move up and down without need of an animation, to allow it to be more general purpose than individual
 * animations for each object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobScript : MonoBehaviour
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public float speed;
    private Vector3 startPosition;
    private Vector3 endPosition;


    void Start()
    {
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
    }

    void Update()
    {
        if (transform.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if (transform.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
    }

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
