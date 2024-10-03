using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invisible : MonoBehaviour
{
    public CutSceenScript CutSceenNow;
    
    public float fadeSpeed = 2.0f; // ���������ų� �ٽ� ���̰� �Ǵ� �ӵ�

    private Graphic uiElement; // Image �Ǵ� Text ������Ʈ�� �����ϴ� ����
    private Color originalColor; // ���� ���� ����
    private float targetAlpha; // ��ǥ alpha ��

    void Start()
    {
        uiElement = GetComponent<Graphic>(); // Image�� Text ������Ʈ�� ����
        originalColor = uiElement.color; // UI ����� ���� ���� ����
        targetAlpha = originalColor.a; // ó�� alpha �� ����
    }

    void Update()
    {
        // isTransparent�� ���� ��ǥ ���� �� ����
        targetAlpha = CutSceenNow ? 0f : 1f;

        // ���� ���� ���� ��ǥ ���� ������ õõ�� ����
        Color newColor = uiElement.color;
        newColor.a = Mathf.Lerp(newColor.a, targetAlpha, Time.deltaTime * fadeSpeed);
        uiElement.color = newColor;
    }
}
