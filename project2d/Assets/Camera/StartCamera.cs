using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        // 카메라의 위치를 플레이어의 X, Y 좌표에 맞추고, Z축은 고정
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10f);  // Z축을 -10으로 고정

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

        transform.position = smoothPosition;
    }
}
