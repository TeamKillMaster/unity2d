using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSound : MonoBehaviour
{
    // AudioSource 컴포넌트를 저장할 변수
    private AudioSource audioSource;

    // Start는 스크립트가 실행될 때 처음 한 번 호출됩니다.
    void Start()
    {
        // GameObject에 연결된 AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();

        // 반복 재생 설정
        audioSource.loop = true;

        // 오디오 재생 시작
        audioSource.Play();
    }


}
