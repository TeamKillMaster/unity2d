using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // �÷��̾��� ü��
    public GameObject cameraObject; // ī�޶� ������Ʈ

    private CameraShake cameraShake; // ī�޶� ��鸲 ��ũ��Ʈ

    void Start()
    {
        if (cameraObject != null)
        {
            cameraShake = cameraObject.GetComponent<CameraShake>();
        }
    }

    // �������� �޴� �Լ�
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // ī�޶� ��鸲 ȣ��
        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shake());
        }

        if (health <= 0)
        {
            Die();
        }
    }

    // �÷��̾ ������� �� ȣ��Ǵ� �Լ�
    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
