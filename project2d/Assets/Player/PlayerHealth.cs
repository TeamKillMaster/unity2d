using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // 플레이어의 체력
    public GameObject cameraObject; // 카메라 오브젝트

    private CameraShake cameraShake; // 카메라 흔들림 스크립트

    void Start()
    {
        if (cameraObject != null)
        {
            cameraShake = cameraObject.GetComponent<CameraShake>();
        }
    }

    // 데미지를 받는 함수
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // 카메라 흔들림 호출
        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shake());
        }

        if (health <= 0)
        {
            Die();
        }
    }

    // 플레이어가 사망했을 때 호출되는 함수
    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
