using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject laserPrefab; // 레이저 프리팹
    public Transform firePoint; // 레이저 발사 위치
    public float laserDuration = 0.5f; // 레이저 지속 시간
    public float laserSpeed = 10f; // 레이저 속도

    private bool isFiring = false; // 레이저 발사 여부 확인

    void Update()
    {
        PerformAttack();
    }

    void PerformAttack()
    {
        if (!isFiring)
        {
            StartCoroutine(FireLaserRoutine());
        }
    }

    public IEnumerator FireLaserRoutine()
    {
        isFiring = true;

        // 레이저 발사
        FireAtPosition(firePoint.position);

        // 레이저 발사 후 대기 시간
        yield return new WaitForSeconds(1f); // 레이저 발사 후 대기 시간 설정

        isFiring = false;
    }

    public void FireAtPosition(Vector3 targetPosition)
    {
        if (laserPrefab != null && firePoint != null)
        {
            // 레이저를 발사 위치에서 생성
            GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);

            // 레이저의 방향 설정
            LineRenderer lineRenderer = laser.GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                Vector3 direction = (targetPosition - firePoint.position).normalized;
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + direction * 100f); // 길이 조절
            }

            // 레이저 이동
            Destroy(laser, laserDuration);
        }
    }
}
