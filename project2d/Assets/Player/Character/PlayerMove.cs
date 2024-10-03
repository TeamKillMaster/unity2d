using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 입력 처리
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 좌클릭을 누르고 있을 때
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteRenderer.flipX = mousePosition.x < transform.position.x;
        }
        // 좌클릭을 누르고 있지 않을 때
        else
        {
            if (movement.x != 0)
            {
                spriteRenderer.flipX = movement.x < 0;
            }
        }

        // 애니메이션 상태 업데이트
        bool isRunning = Mathf.Abs(movement.x) > 0.1f || Mathf.Abs(movement.y) > 0.1f;
        animator.SetBool("Running", isRunning);
    }

    void FixedUpdate()
    {
        // 물리 기반 이동 처리
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
