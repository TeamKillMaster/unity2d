using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Health;
    public RectTransform uiImageRectTransform;
    public float healthFloat;
    public float lerpSpeed = 5f; // 체력 바가 서서히 줄어드는 속도

    private float targetScaleX;

    void Start()
    {
        // 초기화 코드가 필요하다면 여기 추가
    }

    void Update()
    {
        // 플레이어 체력 값 가져오기
        healthFloat = Health.GetComponent<PlayerHealth>().health;

        // 체력 값 범위 확인 (0과 100 사이)
        healthFloat = Mathf.Clamp(healthFloat, 0, 100);

        // 목표 스케일 설정
        targetScaleX = healthFloat / 100;

        // 현재 스케일을 목표 스케일로 부드럽게 변화시키기
        Vector3 newScale = new Vector3(Mathf.Lerp(uiImageRectTransform.localScale.x, targetScaleX, Time.deltaTime * lerpSpeed), 1, 1);
        uiImageRectTransform.localScale = newScale;
    }
}
