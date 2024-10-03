using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // 이 줄을 추가하세요.
using UnityEngine;

public class Storm : MonoBehaviour
{
    public GameObject lightningPanel; // UI 패널
    public float lightningDuration = 0.1f; // 번개가 지속되는 시간
    public float minInterval = 2f; // 최소 간격
    public float maxInterval = 5f; // 최대 간격
    public AudioClip thunderSound1; // 첫 번째 천둥 소리
    public AudioClip thunderSound2; // 두 번째 천둥 소리

    private Image panelImage; // Image 컴포넌트
    private AudioSource audioSource; // AudioSource 컴포넌트

    private void Start()
    {
        panelImage = lightningPanel?.GetComponent<Image>();

        if (panelImage == null)
        {
            Debug.LogError("LightningPanel의 Image 컴포넌트를 찾을 수 없습니다!");
            return; // 초기화가 실패하면 메서드를 종료
        }

        // AudioSource 컴포넌트를 추가
        audioSource = gameObject.AddComponent<AudioSource>();

        // 두 개의 천둥 소리가 할당되지 않았는지 확인
        if (thunderSound1 == null || thunderSound2 == null)
        {
            Debug.LogError("두 개의 ThunderSound가 모두 할당되어야 합니다!");
            return; // 초기화가 실패하면 메서드를 종료
        }

        // 패널을 처음에 투명하게 설정
        panelImage.color = new Color(1f, 1f, 1f, 0f);
        // 천둥 효과 시작
        StartCoroutine(PlayThunderstorm());
    }

    private IEnumerator PlayThunderstorm()
    {
        while (true)
        {
            // 랜덤한 간격 설정
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // 번개 효과
            StartCoroutine(LightningEffect());
            // 랜덤한 천둥 소리 재생
            StartCoroutine(PlayRandomThunderSound());
        }
    }

    private IEnumerator LightningEffect()
    {
        if (panelImage != null)
        {
            // 패널 투명도 변경 (번개 효과)
            panelImage.color = new Color(1f, 1f, 1f, 1f); // 흰색으로 변경
            yield return new WaitForSeconds(lightningDuration); // 잠시 기다림
            panelImage.color = new Color(1f, 1f, 1f, 0f); // 다시 투명하게 변경
        }
    }

    private IEnumerator PlayRandomThunderSound()
    {
        // 0 또는 1의 랜덤 값을 선택하여 소리 결정
        int randomIndex = Random.Range(0, 2);
        AudioClip selectedClip = randomIndex == 0 ? thunderSound1 : thunderSound2;

        // 선택된 소리 재생
        audioSource.clip = selectedClip;
        audioSource.Play();

        // 소리 재생 후 7초 대기
        yield return new WaitForSeconds(7f);

        // 소리 중지
        audioSource.Stop();
    }

}
