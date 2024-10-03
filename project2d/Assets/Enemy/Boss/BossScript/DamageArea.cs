using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float duration = 3f;

    void Start()
    {
        Destroy(gameObject, duration); // 일정 시간 후 자동 파괴
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어에게 피해를 줄 로직 추가
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by damage area!");
            // other.GetComponent<Player>().TakeDamage(damageAmount);
        }
    }
}
