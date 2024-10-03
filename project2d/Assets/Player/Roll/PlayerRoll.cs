using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{ 
    public float dashSpeed = 10f;                // �뽬 �ӵ�
    public float dashDistance = 5f;              // �뽬�� �Ÿ�
    public GameObject dashEffectPrefab;          // �뽬 ����Ʈ ������
    public float dashDelay = 0.1f;               // �뽬 ���� �ð�
    public float dashDuration = 0.2f;            // �뽬 ���� �ð�

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isDashing = false;
    private Vector2 dashDirection;
    private float dashStartTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(DelayDash());
        }
    }

    IEnumerator DelayDash()
    {
        // �뽬 ���� �� ���� �ð� ���� ���
        yield return new WaitForSeconds(dashDelay);

        // �뽬 ����
        StartDash();
    }

    void StartDash()
    {
        Vector2 currentPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dashDirection = (mousePosition - currentPosition).normalized;

        if (dashDirection == Vector2.zero)
        {
            dashDirection = Vector2.right; // �⺻ ����
        }

        targetPosition = currentPosition + dashDirection * dashDistance;

        CreateDashEffect(currentPosition, targetPosition);

        isDashing = true;
        dashStartTime = Time.time; // �뽬 ���� �ð� ���
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            // �뽬 �������� �̵�
            Vector2 movePosition = Vector2.MoveTowards(transform.position, targetPosition, dashSpeed * Time.fixedDeltaTime);
            rb.MovePosition(movePosition);

            // �뽬 ���� �ð� üũ
            if (Time.time - dashStartTime > dashDuration)
            {
                isDashing = false; // �뽬 ����
            }
        }
    }

    void CreateDashEffect(Vector2 startPosition, Vector2 endPosition)
    {
        Vector2 middlePoint = (startPosition + endPosition) / 2;
        float distance = Vector2.Distance(startPosition, endPosition);

        GameObject effect = Instantiate(dashEffectPrefab, middlePoint, Quaternion.identity);

        float angle = Mathf.Atan2(endPosition.y - startPosition.y, endPosition.x - startPosition.x) * Mathf.Rad2Deg;
        effect.transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(effect, 0.2f);
    }

}
