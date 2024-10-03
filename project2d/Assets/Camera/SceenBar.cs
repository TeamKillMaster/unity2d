using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceenBar : MonoBehaviour
{
    public RectTransform topBar;
    public RectTransform bottomBar;
    public float targetHeight = 150f;  // ��ǥ ����
    public float speed = 500f;         // �ִϸ��̼� �ӵ�
    public float offset = 500f;        // �ʱ� ��ġ ������

    private Vector2 topBarTargetPos;
    private Vector2 bottomBarTargetPos;

    private void Start()
    {
        // ��ǥ ��ġ ����
        topBarTargetPos = topBar.anchoredPosition;
        bottomBarTargetPos = bottomBar.anchoredPosition;

        // ���� ��ġ�� �� �ָ� ����
        topBar.anchoredPosition = new Vector2(topBar.anchoredPosition.x, topBarTargetPos.y + targetHeight + offset);
        bottomBar.anchoredPosition = new Vector2(bottomBar.anchoredPosition.x, bottomBarTargetPos.y - targetHeight - offset);

       
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            StartCoroutine(ShowBars());
        }
    }



    private IEnumerator ShowBars()
    {
        // �ٰ� ��ǥ ��ġ�� ������ ������ �̵�
        while (topBar.anchoredPosition.y > topBarTargetPos.y || bottomBar.anchoredPosition.y < bottomBarTargetPos.y)
        {
            // ���� �ٸ� �Ʒ��� �̵�
            topBar.anchoredPosition = Vector2.MoveTowards(topBar.anchoredPosition, topBarTargetPos, speed * Time.deltaTime);
            // �Ʒ��� �ٸ� ���� �̵�
            bottomBar.anchoredPosition = Vector2.MoveTowards(bottomBar.anchoredPosition, bottomBarTargetPos, speed * Time.deltaTime);

            yield return null;
        }
    }
}
