using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{
    public GameObject projectilePrefab; // 발사체 프리팹
    public Transform spawnPoint; // 발사체 생성 위치
    public float maxChargeTime = 3f; // 최대 차징 시간
    public float minProjectileSpeed = 10f; // 최소 발사체 속도
    public float maxProjectileSpeed = 50f; // 최대 발사체 속도

    private float chargeTime;
    private bool isCharging;

    void Update()
    {
        // 좌클릭 누르기 시작하면 차징 시작
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            chargeTime = 0f;
        }

        // 좌클릭을 계속 누르고 있으면 차징 시간 증가
        if (isCharging && Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Min(chargeTime, maxChargeTime); // 최대 차징 시간 제한
        }

        // 좌클릭을 떼면 발사체 발사
        if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        float chargePercent = chargeTime / maxChargeTime;
        float projectileSpeed = Mathf.Lerp(minProjectileSpeed, maxProjectileSpeed, chargePercent);

        // 마우스 위치에서 월드 방향을 계산
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D 환경에서는 z축을 0으로 설정

        Vector3 direction = (mousePosition - spawnPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
