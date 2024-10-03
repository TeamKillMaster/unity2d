using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{
    public GameObject projectilePrefab; // �߻�ü ������
    public Transform spawnPoint; // �߻�ü ���� ��ġ
    public float maxChargeTime = 3f; // �ִ� ��¡ �ð�
    public float minProjectileSpeed = 10f; // �ּ� �߻�ü �ӵ�
    public float maxProjectileSpeed = 50f; // �ִ� �߻�ü �ӵ�

    private float chargeTime;
    private bool isCharging;

    void Update()
    {
        // ��Ŭ�� ������ �����ϸ� ��¡ ����
        if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            chargeTime = 0f;
        }

        // ��Ŭ���� ��� ������ ������ ��¡ �ð� ����
        if (isCharging && Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Min(chargeTime, maxChargeTime); // �ִ� ��¡ �ð� ����
        }

        // ��Ŭ���� ���� �߻�ü �߻�
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

        // ���콺 ��ġ���� ���� ������ ���
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D ȯ�濡���� z���� 0���� ����

        Vector3 direction = (mousePosition - spawnPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
