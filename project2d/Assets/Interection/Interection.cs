using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interection : MonoBehaviour
{
    public Color highlightColor = Color.yellow; // ������ ����
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // ���� ���� ����
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 2f)
        {
            spriteRenderer.color = highlightColor; // ���� �������� ����
        }
        else
        {
            spriteRenderer.color = originalColor; // ���� �������� �ǵ�����
        }
    }
}
