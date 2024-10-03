using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Health;
    public RectTransform uiImageRectTransform;
    public float healthFloat;
    public float lerpSpeed = 5f; // ü�� �ٰ� ������ �پ��� �ӵ�

    private float targetScaleX;

    void Start()
    {
        // �ʱ�ȭ �ڵ尡 �ʿ��ϴٸ� ���� �߰�
    }

    void Update()
    {
        // �÷��̾� ü�� �� ��������
        healthFloat = Health.GetComponent<PlayerHealth>().health;

        // ü�� �� ���� Ȯ�� (0�� 100 ����)
        healthFloat = Mathf.Clamp(healthFloat, 0, 100);

        // ��ǥ ������ ����
        targetScaleX = healthFloat / 100;

        // ���� �������� ��ǥ �����Ϸ� �ε巴�� ��ȭ��Ű��
        Vector3 newScale = new Vector3(Mathf.Lerp(uiImageRectTransform.localScale.x, targetScaleX, Time.deltaTime * lerpSpeed), 1, 1);
        uiImageRectTransform.localScale = newScale;
    }
}
