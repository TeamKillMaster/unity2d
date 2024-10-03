using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBoss : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public int damage = 10;

    void Start()
    {
        // 일정 시간이 지나면 발사체를 파괴합니다.
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 발사체를 앞으로 이동시킵니다.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 객체가 플레이어일 경우 데미지를 줍니다.
        PlayerHealth PlayerHealth = collision.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.TakeDamage(10);
        }

        // 발사체를 파괴합니다.
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

}
