using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
    public GameObject splashPrefab; // �� Ƣ�� ��ƼŬ ������
    public float minX = -10f; // ���� �ּ� X ��ǥ
    public float maxX = 10f;  // ���� �ִ� X ��ǥ
    public float minY = -10f;  // ���� �ּ� Y ��ǥ
    public float maxY = 10f;   // ���� �ִ� Y ��ǥ
    public int numberOfSplashes = 10; // �� ���� ������ �� Ƣ��� ȿ���� ��

    private void Start()
    {
        // ���� �� �������� �� Ƣ��� ȿ���� ���
        InvokeRepeating(nameof(PlayRandomSplash), 1f, 0.5f); // 1�� �� �����ϰ�, 0.5�ʸ��� �ݺ�
    }

    private void PlayRandomSplash()
    {
        for (int i = 0; i < numberOfSplashes; i++)
        {
            // ���� ��ġ ����
            Vector2 randomPosition = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );

            // �� Ƣ�� �ִϸ��̼� ���
            GameObject splash = Instantiate(splashPrefab, randomPosition, Quaternion.identity);

            // Ŭ���� 0.3�� �Ŀ� ��������� ����
            Destroy(splash, 0.3f);
        }
    }
}
