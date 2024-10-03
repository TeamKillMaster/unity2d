using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 7f;
    public float rotateSpeed = 200f;
    public int damage = 10;
    public float homingDuration = 2f; // 플레이어를 추적하는 시간
    public float acceleration = 5f; // 방향 고정 후 가속도

    private Transform target;
    private bool isHoming = true;
    private float homingTimer;

    void Start()
    {
        homingTimer = homingDuration; // 타이머 초기화
        Destroy(gameObject, 6f); // 6초 후에 미사일 파괴
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (isHoming)
        {
            homingTimer -= Time.deltaTime;
            if (homingTimer <= 0)
            {
                isHoming = false; // 타이머가 끝나면 방향 고정
            }
        }

        if (target == null) return;

        if (isHoming)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);
            speed += acceleration * Time.deltaTime; // 방향 고정 후 가속
        }
        else
        {
            speed += acceleration * Time.deltaTime; // 방향 고정 후 가속
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
