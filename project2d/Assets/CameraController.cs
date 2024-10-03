using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 할당
    public float maxDistance = 5.0f; // 카메라와 플레이어 사이의 최대 거리
    public float smoothTime = 0.3f; // 카메라 이동의 부드러움을 조절하는 변수
    public CameraShake cameraShake; // 카메라 흔들림 스크립트

    private Vector3 velocity = Vector3.zero; // 카메라의 현재 속도
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>(); // 카메라 컴포넌트를 가져옴
    }

    void LateUpdate()
    {
        // 플레이어의 위치를 가져옴
        Vector3 playerPosition = player.position;
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        // z 좌표를 플레이어의 z 좌표와 맞춤
        mousePosition.z = playerPosition.z;

        // 플레이어와 마우스 위치의 중간 지점을 계산
        Vector3 middlePoint = (playerPosition + mousePosition) / 2.0f;
        // 플레이어에서 중간점으로 가는 벡터를 계산
        Vector3 direction = middlePoint - playerPosition;

        // 플레이어와 중간점 사이의 거리를 계산
        float distance = direction.magnitude;

        if (Input.GetMouseButton(0))
        {
            if (distance > maxDistance)
            {
                middlePoint = playerPosition + direction.normalized * maxDistance;
            }

            // 목표 위치를 설정
            Vector3 targetPosition = new Vector3(middlePoint.x, middlePoint.y, transform.position.z);
            // 카메라 위치를 SmoothDamp를 사용하여 자연스럽게 이동
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // 카메라 흔들림 호출
            
        }
        else
        {
            // 기본적으로 플레이어의 위치를 따라가는 경우
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
