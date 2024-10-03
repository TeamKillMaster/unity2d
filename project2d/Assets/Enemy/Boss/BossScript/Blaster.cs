using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject laserPrefab; // ������ ������
    public Transform firePoint; // ������ �߻� ��ġ
    public float laserDuration = 0.5f; // ������ ���� �ð�
    public float laserSpeed = 10f; // ������ �ӵ�

    private bool isFiring = false; // ������ �߻� ���� Ȯ��

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

        // ������ �߻�
        FireAtPosition(firePoint.position);

        // ������ �߻� �� ��� �ð�
        yield return new WaitForSeconds(1f); // ������ �߻� �� ��� �ð� ����

        isFiring = false;
    }

    public void FireAtPosition(Vector3 targetPosition)
    {
        if (laserPrefab != null && firePoint != null)
        {
            // �������� �߻� ��ġ���� ����
            GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);

            // �������� ���� ����
            LineRenderer lineRenderer = laser.GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                Vector3 direction = (targetPosition - firePoint.position).normalized;
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + direction * 100f); // ���� ����
            }

            // ������ �̵�
            Destroy(laser, laserDuration);
        }
    }
}
