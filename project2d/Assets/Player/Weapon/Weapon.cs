using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Ob;
    private Animator animator;

   
    // Start is called before the first frame update
    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        
        Vector2 direction = (mousePosition - transform.position).normalized;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        


    }
}
