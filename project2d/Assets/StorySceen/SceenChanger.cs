using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SceenChanger : MonoBehaviour
{

    public GameObject indexs;          // 인덱스 값을 가져올 GameObject
    public int indexx;                 // 현재 인덱스
    public Sprite[] sentences;         // 스프라이트 배열
    public Image targetImage;          // 이미지를 변경할 Image 컴포넌트

    public float fadeDuration = 1.0f;  // 페이드 인/아웃에 걸리는 시간
    private SceenScript screenScript;  // SceenScript 컴포넌트를 저장할 변수
    private int lastIndex = -1;        // 마지막으로 보여준 인덱스 저장
    private bool isFading = false;     // 페이드 중인지 여부 확인
    private bool isFirstImage = true;  // 첫 번째 이미지 여부 확인

    // Start는 첫 프레임이 업데이트 되기 전에 호출됩니다.
    void Start()
    {
        // SceenScript 컴포넌트를 캐싱하여 매 프레임마다 GetComponent를 호출하지 않도록 합니다.
        screenScript = indexs.GetComponent<SceenScript>();
        if (screenScript == null)
        {
            Debug.LogError("indexs에서 SceenScript 컴포넌트를 찾을 수 없습니다.");
        }
    }

    // Update는 매 프레임마다 호출됩니다.
    void Update()
    {
        // screenScript가 null이 아닌지 확인합니다.
        if (screenScript != null && !isFading)
        {
            indexx = screenScript.index;

            // indexx가 sentences 배열의 유효한 범위 내에 있고, 새로운 인덱스일 때만 실행
            if (indexx != lastIndex && indexx >= 0 && indexx < sentences.Length)
            {
                if (targetImage != null)
                {
                    if (isFirstImage)
                    {
                        // 첫 번째 이미지는 페이드 없이 즉시 적용
                        targetImage.sprite = sentences[indexx];
                        lastIndex = indexx;
                        isFirstImage = false;  // 첫 번째 이미지 표시 후 false로 변경
                    }
                    else
                    {
                        // 첫 번째 이후 이미지는 페이드 인/아웃 실행
                        StartCoroutine(FadeImage(sentences[indexx]));
                        lastIndex = indexx; // 마지막 인덱스 값을 업데이트
                    }
                }
                else
                {
                    Debug.LogWarning("targetImage가 할당되지 않았습니다.");
                }
            }
        }
    }

    // 이미지 페이드 인/아웃 효과
    private IEnumerator FadeImage(Sprite newSprite)
    {
        isFading = true;

        // 페이드 아웃 (투명하게 만들기)
        float elapsedTime = 0f;
        Color color = targetImage.color;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            targetImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 스프라이트 변경
        targetImage.sprite = newSprite;

        // 페이드 인 (다시 불투명하게 만들기)
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            targetImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isFading = false;
    }
}

