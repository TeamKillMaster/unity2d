using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraFollowingt : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� �Ҵ�
    public float maxDistance = 5.0f; // ī�޶�� �÷��̾� ������ �ִ� �Ÿ�
    public float smoothTime = 0.3f; // ī�޶� �̵��� �ε巯���� �����ϴ� ����
    public GameObject Ob;
    public int Weapon_;

    private Vector3 velocity = Vector3.zero; // ī�޶��� ���� �ӵ�
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>(); // ī�޶� ������Ʈ�� ������


    }

    private void Update()
    {
        Weapon_ = Ob.GetComponent<PlayerWeapon>().Weapon;
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



        if (Input.GetMouseButton(0) == true&& Weapon_ ==1 )
        {
            if (distance > maxDistance)
            {
                middlePoint = playerPosition + direction.normalized * maxDistance;
            }

            // ��ǥ ��ġ�� ����
            Vector3 targetPosition = new Vector3(middlePoint.x, middlePoint.y, transform.position.z);
            // ī�޶� ��ġ�� SmoothDamp�� ����Ͽ� �ڿ������� �̵�
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
    
        // �ִ� �Ÿ��� �ʰ��ϸ� ����� �Ÿ��� ����
        
}
