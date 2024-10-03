using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, 3f); // 3초 후 자동 파괴
    }
}
