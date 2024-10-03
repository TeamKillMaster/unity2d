using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
    public GameObject splashPrefab; // 물 튀는 파티클 프리팹
    public float minX = -10f; // 맵의 최소 X 좌표
    public float maxX = 10f;  // 맵의 최대 X 좌표
    public float minY = -10f;  // 맵의 최소 Y 좌표
    public float maxY = 10f;   // 맵의 최대 Y 좌표
    public int numberOfSplashes = 10; // 한 번에 생성할 물 튀기기 효과의 수

    private void Start()
    {
        // 시작 시 랜덤으로 물 튀기는 효과를 재생
        InvokeRepeating(nameof(PlayRandomSplash), 1f, 0.5f); // 1초 후 시작하고, 0.5초마다 반복
    }

    private void PlayRandomSplash()
    {
        for (int i = 0; i < numberOfSplashes; i++)
        {
            // 랜덤 위치 생성
            Vector2 randomPosition = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );

            // 물 튀는 애니메이션 재생
            GameObject splash = Instantiate(splashPrefab, randomPosition, Quaternion.identity);

            // 클론이 0.3초 후에 사라지도록 설정
            Destroy(splash, 0.3f);
        }
    }
}
