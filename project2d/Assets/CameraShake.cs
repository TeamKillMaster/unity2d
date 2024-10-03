using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;   // 흔들리는 시간
    public float shakeMagnitude = 0.1f;  // 흔들림의 강도

    private Vector3 originalPosition;    // 원래 카메라 위치

    void Start()
    {
        originalPosition = transform.position; // 카메라의 원래 위치 저장
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

            yield return null; // 프레임이 끝날 때까지 대기
        }

        transform.position = originalPos; // 흔들림이 끝난 후 원래 위치로 복원
    }
}
