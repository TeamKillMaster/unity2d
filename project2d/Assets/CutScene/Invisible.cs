using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invisible : MonoBehaviour
{
    public CutSceenScript CutSceenNow;
    
    public float fadeSpeed = 2.0f; // 투명해지거나 다시 보이게 되는 속도

    private Graphic uiElement; // Image 또는 Text 컴포넌트를 참조하는 변수
    private Color originalColor; // 원래 색상 저장
    private float targetAlpha; // 목표 alpha 값

    void Start()
    {
        uiElement = GetComponent<Graphic>(); // Image나 Text 컴포넌트를 참조
        originalColor = uiElement.color; // UI 요소의 원래 색상 저장
        targetAlpha = originalColor.a; // 처음 alpha 값 저장
    }

    void Update()
    {
        // isTransparent에 따라 목표 알파 값 설정
        targetAlpha = CutSceenNow ? 0f : 1f;

        // 현재 알파 값을 목표 알파 값으로 천천히 보간
        Color newColor = uiElement.color;
        newColor.a = Mathf.Lerp(newColor.a, targetAlpha, Time.deltaTime * fadeSpeed);
        uiElement.color = newColor;
    }
}
