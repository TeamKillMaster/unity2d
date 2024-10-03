using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� �Ҵ�
    public float maxDistance = 5.0f; // ī�޶�� �÷��̾� ������ �ִ� �Ÿ�
    public float smoothTime = 0.3f; // ī�޶� �̵��� �ε巯���� �����ϴ� ����
    public CameraShake cameraShake; // ī�޶� ��鸲 ��ũ��Ʈ

    private Vector3 velocity = Vector3.zero; // ī�޶��� ���� �ӵ�
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>(); // ī�޶� ������Ʈ�� ������
    }

    void LateUpdate()
    {
        // �÷��̾��� ��ġ�� ������
        Vector3 playerPosition = player.position;
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        // z ��ǥ�� �÷��̾��� z ��ǥ�� ����
        mousePosition.z = playerPosition.z;

        // �÷��̾�� ���콺 ��ġ�� �߰� ������ ���
        Vector3 middlePoint = (playerPosition + mousePosition) / 2.0f;
        // �÷��̾�� �߰������� ���� ���͸� ���
        Vector3 direction = middlePoint - playerPosition;

        // �÷��̾�� �߰��� ������ �Ÿ��� ���
        float distance = direction.magnitude;

        if (Input.GetMouseButton(0))
        {
            if (distance > maxDistance)
            {
                middlePoint = playerPosition + direction.normalized * maxDistance;
            }

            // ��ǥ ��ġ�� ����
            Vector3 targetPosition = new Vector3(middlePoint.x, middlePoint.y, transform.position.z);
            // ī�޶� ��ġ�� SmoothDamp�� ����Ͽ� �ڿ������� �̵�
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // ī�޶� ��鸲 ȣ��
            
        }
        else
        {
            // �⺻������ �÷��̾��� ��ġ�� ���󰡴� ���
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
