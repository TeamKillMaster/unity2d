using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPre : MonoBehaviour
{
    public float attackCooldown = 3f;
    private float attackTimer = 0f;
    public Transform player;
    public GameObject projectilePrefab1; // 첫 번째 발사체 프리팹
    public GameObject projectilePrefab2; // 두 번째 발사체 프리팹
    public Transform firePoint;

    public enum BossAttackPattern
    {
        ShootProjectileType1,
        ShootProjectileType2,
        SpiralPattern,
        HomingMissiles
    }

    public BossAttackPattern[] attackPatterns;
    private int currentPatternIndex = 0;

    void Update()
    {
        PerformAttack();
    }

    void PerformAttack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            switch (attackPatterns[currentPatternIndex])
            {
                case BossAttackPattern.ShootProjectileType1:
                    ShootProjectileType1();
                    break;
                case BossAttackPattern.ShootProjectileType2:
                    ShootProjectileType2();
                    break;
                case BossAttackPattern.SpiralPattern:
                    ShootSpiralPattern();
                    break;
                case BossAttackPattern.HomingMissiles:
                    ShootHomingMissiles();
                    break;
            }

            currentPatternIndex = (currentPatternIndex + 1) % attackPatterns.Length;
            attackTimer = 0f;
        }
    }

    void ShootProjectileType1()
    {
        int projectileCount = 10;
        float angleStep = 360f / projectileCount;
        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(projectilePrefab1, firePoint.position, rotation);
        }
    }

    void ShootProjectileType2()
    {
        int projectileCount = 5;
        float angleStep = 360f / projectileCount;
        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(projectilePrefab2, firePoint.position, rotation);
        }
    }

    void ShootSpiralPattern()
    {
        int projectileCount = 20;
        float angleStep = 18f; // 360 / 20 = 18 degrees step for each projectile
        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle + (Time.time * 100)); // Time.time to create spiral effect
            Instantiate(projectilePrefab1, firePoint.position, rotation);
        }
    }

    void ShootHomingMissiles()
    {
        int missileCount = 3;
        for (int i = 0; i < missileCount; i++)
        {
            GameObject missile = Instantiate(projectilePrefab2, firePoint.position, Quaternion.identity);
            missile.GetComponent<HomingMissile>().SetTarget(player); // Assuming the projectilePrefab2 has a HomingMissile script
        }
    }
}
