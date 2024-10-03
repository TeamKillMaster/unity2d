using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class BossBehavior : MonoBehaviour
{
    public float attackCooldown = 3f;
    private float attackTimer = 0f;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform player;
    public GameObject homingMissilePrefab; // 호밍 미사일 프리팹

    public Transform[] patrolPoints; // 보스가 이동할 패트롤 포인트
    
    public enum BossAttackPattern
    {
        HomingMissiles,
        BlasterAttack // 블래스터 공격 패턴
    }

    public BossAttackPattern[] attackPatterns;
    private int currentPatternIndex = 0;
    private bool isAttacking = false; // 코루틴 실행 여부를 확인할 변수

    void Update()
    {
        PerformAttack();
    }

    void PerformAttack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            if (!isAttacking) // 코루틴이 실행 중이지 않은 경우에만 실행
            {
                switch (attackPatterns[currentPatternIndex])
                {
                    case BossAttackPattern.HomingMissiles:
                        StartCoroutine(LaunchHomingMissiles());
                        break;

                    
                }

                currentPatternIndex = (currentPatternIndex + 1) % attackPatterns.Length;
                attackTimer = 0f;
            }
        }
    }

    // 호밍 미사일 발사 코루틴
    private IEnumerator LaunchHomingMissiles()
    {
        isAttacking = true;
        for (int i = 0; i < 3; i++)
        {
            // firePoint1에서 미사일 발사
            GameObject missile1 = Instantiate(homingMissilePrefab, firePoint1.position, Quaternion.identity);
            missile1.GetComponent<HomingMissile>().SetTarget(player);

            // firePoint2에서 미사일 발사
            GameObject missile2 = Instantiate(homingMissilePrefab, firePoint2.position, Quaternion.identity);
            missile2.GetComponent<HomingMissile>().SetTarget(player);

            // firePoint3에서 미사일 발사
            GameObject missile3 = Instantiate(homingMissilePrefab, firePoint3.position, Quaternion.identity);
            missile3.GetComponent<HomingMissile>().SetTarget(player);

            // 1초 지연
            yield return new WaitForSeconds(1f);
        }
        isAttacking = false; // 코루틴 실행이 끝났음을 표시
    }

    // 블래스터 공격 코루틴
    
}
