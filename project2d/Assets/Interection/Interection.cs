using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interection : MonoBehaviour
{
    public Color highlightColor = Color.yellow; // 강조할 색상
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 원래 색상 저장
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 2f)
        {
            spriteRenderer.color = highlightColor; // 강조 색상으로 변경
        }
        else
        {
            spriteRenderer.color = originalColor; // 원래 색상으로 되돌리기
        }
    }
}
