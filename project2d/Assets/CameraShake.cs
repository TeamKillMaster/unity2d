using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;   // ��鸮�� �ð�
    public float shakeMagnitude = 0.1f;  // ��鸲�� ����

    private Vector3 originalPosition;    // ���� ī�޶� ��ġ

    void Start()
    {
        originalPosition = transform.position; // ī�޶��� ���� ��ġ ����
    }

    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null; // �������� ���� ������ ���
        }

        transform.position = originalPos; // ��鸲�� ���� �� ���� ��ġ�� ����
    }
}
