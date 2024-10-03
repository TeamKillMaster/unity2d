using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceenBar : MonoBehaviour
{
    public RectTransform topBar;
    public RectTransform bottomBar;
    public float targetHeight = 150f;  // 목표 높이
    public float speed = 500f;         // 애니메이션 속도
    public float offset = 500f;        // 초기 위치 오프셋

    private Vector2 topBarTargetPos;
    private Vector2 bottomBarTargetPos;

    private void Start()
    {
        // 목표 위치 설정
        topBarTargetPos = topBar.anchoredPosition;
        bottomBarTargetPos = bottomBar.anchoredPosition;

        // 시작 위치를 더 멀리 설정
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
        // 바가 목표 위치에 도달할 때까지 이동
        while (topBar.anchoredPosition.y > topBarTargetPos.y || bottomBar.anchoredPosition.y < bottomBarTargetPos.y)
        {
            // 위쪽 바를 아래로 이동
            topBar.anchoredPosition = Vector2.MoveTowards(topBar.anchoredPosition, topBarTargetPos, speed * Time.deltaTime);
            // 아래쪽 바를 위로 이동
            bottomBar.anchoredPosition = Vector2.MoveTowards(bottomBar.anchoredPosition, bottomBarTargetPos, speed * Time.deltaTime);

            yield return null;
        }
    }
}
