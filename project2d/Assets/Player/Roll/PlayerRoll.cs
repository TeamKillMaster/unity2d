using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{ 
    public float dashSpeed = 10f;                // 대쉬 속도
    public float dashDistance = 5f;              // 대쉬할 거리
    public GameObject dashEffectPrefab;          // 대쉬 이펙트 프리팹
    public float dashDelay = 0.1f;               // 대쉬 지연 시간
    public float dashDuration = 0.2f;            // 대쉬 지속 시간

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
        // 대쉬 시작 전 지연 시간 동안 대기
        yield return new WaitForSeconds(dashDelay);

        // 대쉬 시작
        StartDash();
    }

    void StartDash()
    {
        Vector2 currentPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dashDirection = (mousePosition - currentPosition).normalized;

        if (dashDirection == Vector2.zero)
        {
            dashDirection = Vector2.right; // 기본 방향
        }

        targetPosition = currentPosition + dashDirection * dashDistance;

        CreateDashEffect(currentPosition, targetPosition);

        isDashing = true;
        dashStartTime = Time.time; // 대쉬 시작 시간 기록
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            // 대쉬 방향으로 이동
            Vector2 movePosition = Vector2.MoveTowards(transform.position, targetPosition, dashSpeed * Time.fixedDeltaTime);
            rb.MovePosition(movePosition);

            // 대쉬 지속 시간 체크
            if (Time.time - dashStartTime > dashDuration)
            {
                isDashing = false; // 대쉬 중지
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
