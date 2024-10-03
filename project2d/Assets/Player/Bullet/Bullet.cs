using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime = 3f; 

    void Start()
    {
        Destroy(gameObject, lifeTime);

        StartCoroutine(WaitForOneSecond());
    }

    IEnumerator WaitForOneSecond()
    {
        
        yield return new WaitForSeconds(4);
        
        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);


    }
}
