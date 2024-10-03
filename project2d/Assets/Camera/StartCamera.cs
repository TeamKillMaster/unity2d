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
        // ī�޶��� ��ġ�� �÷��̾��� X, Y ��ǥ�� ���߰�, Z���� ����
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10f);  // Z���� -10���� ����

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

        transform.position = smoothPosition;
    }
}
