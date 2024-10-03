using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceenScript : MonoBehaviour
{
    public Text dialogueText;  // Unity UI의 Text 컴포넌트
    public float typingSpeed = 0.05f;  // 글자가 나타나는 속도
    public string[] sentences;  // 출력할 문장들을 배열로 저장
    public AudioSource typingSound;
    public AudioClip[] typingClips; // 여러 개의 타이핑 효과음 배열

    public int index = 0;  // 현재 문장의 인덱스
    private bool isTyping = false;  // 텍스트 출력 중인지 여부 확인

    private void Start()
    {
        // 첫 번째 문장 출력 시작
        StartCoroutine(TypeSentence(sentences[index]));
    }

    private void Update()
    {
        // 스페이스바를 누르고 텍스트 출력이 끝났을 때 다음 문장으로 이동
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextSentence();
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;  // 텍스트 출력 중임을 표시
        dialogueText.text = "";  // 텍스트를 초기화

        // 입력된 문장을 한 글자씩 추가
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            // 70% 확률로 타이핑 소리 재생
            if (Random.Range(0f, 1f) <= 0.7f && typingClips.Length > 0)
            {
                int randomIndex = Random.Range(0, typingClips.Length);
                typingSound.PlayOneShot(typingClips[randomIndex]);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;  // 텍스트 출력이 끝남
    }

    private void NextSentence()
    {
        // 다음 문장이 있으면 출력
        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            dialogueText.text = "대사가 모두 끝났습니다.";  // 마지막 대사 이후 표시할 메시지
        }
    }
}
