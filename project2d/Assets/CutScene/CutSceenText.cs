using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceenText : MonoBehaviour
{
    public TMP_Text dialogueText; // TMP 텍스트 컴포넌트 연결
    public float typingSpeed = 0.05f; // 각 글자 출력 속도

    [TextArea(3, 10)] // Inspector에서 보기 좋게 텍스트 배열 설정
    public string[] dialogues; // 여러 대사를 저장하는 배열

    public CutSceenScript otherScript; // CutSceneNow 변수를 가진 다른 스크립트 참조

    // 외부에서 호출할 수 있는 함수 (특정 인덱스의 대사를 출력)
    public void StartDialogue(int dialogueIndex)
    {
        if (dialogueIndex >= 0 && dialogueIndex < dialogues.Length) // 유효한 인덱스인지 확인
        {
            StopAllCoroutines(); // 이전 대화가 남아있다면 중지
            otherScript.CutSceenNow = true; // 컷신 시작 시 true
            StartCoroutine(TypeSentence(dialogues[dialogueIndex])); // 지정된 인덱스의 대사 출력
        }
        else
        {
            Debug.LogWarning("Invalid dialogue index!"); // 유효하지 않은 인덱스 경고
        }
    }

    // 한 글자씩 출력하는 코루틴
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; // 기존 텍스트 초기화
        foreach (char letter in sentence.ToCharArray()) // 문장을 한 글자씩 출력
        {
            dialogueText.text += letter; // 한 글자 추가
            yield return new WaitForSeconds(typingSpeed); // 지정한 속도만큼 대기
        }

        otherScript.CutSceenNow = false; // 대사가 끝나면 컷신 종료 -> 변수 false
    }

    // 대화 전체를 스킵하고 즉시 출력하는 기능
    public void SkipDialogue(int dialogueIndex)
    {
        if (dialogueIndex >= 0 && dialogueIndex < dialogues.Length) // 유효한 인덱스인지 확인
        {
            StopAllCoroutines(); // 대화 중지
            dialogueText.text = dialogues[dialogueIndex]; // 해당 인덱스의 대사 즉시 출력
            otherScript.CutSceenNow = false; // 대사가 끝나면 컷신 종료 -> 변수 false
        }
        else
        {
            Debug.LogWarning("Invalid dialogue index!"); // 유효하지 않은 인덱스 경고
        }
    }
}
