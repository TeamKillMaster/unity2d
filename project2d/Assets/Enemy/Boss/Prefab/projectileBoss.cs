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
        // ���� �ð��� ������ �߻�ü�� �ı��մϴ�.
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // �߻�ü�� ������ �̵���ŵ�ϴ�.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ��ü�� �÷��̾��� ��� �������� �ݴϴ�.
        PlayerHealth PlayerHealth = collision.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.TakeDamage(10);
        }

        // �߻�ü�� �ı��մϴ�.
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

}
