using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 7f;
    public float rotateSpeed = 200f;
    public int damage = 10;
    public float homingDuration = 2f; // �÷��̾ �����ϴ� �ð�
    public float acceleration = 5f; // ���� ���� �� ���ӵ�

    private Transform target;
    private bool isHoming = true;
    private float homingTimer;

    void Start()
    {
        homingTimer = homingDuration; // Ÿ�̸� �ʱ�ȭ
        Destroy(gameObject, 6f); // 6�� �Ŀ� �̻��� �ı�
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
                isHoming = false; // Ÿ�̸Ӱ� ������ ���� ����
            }
        }

        if (target == null) return;

        if (isHoming)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);
            speed += acceleration * Time.deltaTime; // ���� ���� �� ����
        }
        else
        {
            speed += acceleration * Time.deltaTime; // ���� ���� �� ����
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
