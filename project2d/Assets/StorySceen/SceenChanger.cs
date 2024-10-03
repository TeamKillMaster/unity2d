using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SceenChanger : MonoBehaviour
{

    public GameObject indexs;          // �ε��� ���� ������ GameObject
    public int indexx;                 // ���� �ε���
    public Sprite[] sentences;         // ��������Ʈ �迭
    public Image targetImage;          // �̹����� ������ Image ������Ʈ

    public float fadeDuration = 1.0f;  // ���̵� ��/�ƿ��� �ɸ��� �ð�
    private SceenScript screenScript;  // SceenScript ������Ʈ�� ������ ����
    private int lastIndex = -1;        // ���������� ������ �ε��� ����
    private bool isFading = false;     // ���̵� ������ ���� Ȯ��
    private bool isFirstImage = true;  // ù ��° �̹��� ���� Ȯ��

    // Start�� ù �������� ������Ʈ �Ǳ� ���� ȣ��˴ϴ�.
    void Start()
    {
        // SceenScript ������Ʈ�� ĳ���Ͽ� �� �����Ӹ��� GetComponent�� ȣ������ �ʵ��� �մϴ�.
        screenScript = indexs.GetComponent<SceenScript>();
        if (screenScript == null)
        {
            Debug.LogError("indexs���� SceenScript ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    // Update�� �� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {
        // screenScript�� null�� �ƴ��� Ȯ���մϴ�.
        if (screenScript != null && !isFading)
        {
            indexx = screenScript.index;

            // indexx�� sentences �迭�� ��ȿ�� ���� ���� �ְ�, ���ο� �ε����� ���� ����
            if (indexx != lastIndex && indexx >= 0 && indexx < sentences.Length)
            {
                if (targetImage != null)
                {
                    if (isFirstImage)
                    {
                        // ù ��° �̹����� ���̵� ���� ��� ����
                        targetImage.sprite = sentences[indexx];
                        lastIndex = indexx;
                        isFirstImage = false;  // ù ��° �̹��� ǥ�� �� false�� ����
                    }
                    else
                    {
                        // ù ��° ���� �̹����� ���̵� ��/�ƿ� ����
                        StartCoroutine(FadeImage(sentences[indexx]));
                        lastIndex = indexx; // ������ �ε��� ���� ������Ʈ
                    }
                }
                else
                {
                    Debug.LogWarning("targetImage�� �Ҵ���� �ʾҽ��ϴ�.");
                }
            }
        }
    }

    // �̹��� ���̵� ��/�ƿ� ȿ��
    private IEnumerator FadeImage(Sprite newSprite)
    {
        isFading = true;

        // ���̵� �ƿ� (�����ϰ� �����)
        float elapsedTime = 0f;
        Color color = targetImage.color;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            targetImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ��������Ʈ ����
        targetImage.sprite = newSprite;

        // ���̵� �� (�ٽ� �������ϰ� �����)
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

