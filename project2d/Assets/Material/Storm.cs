using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // �� ���� �߰��ϼ���.
using UnityEngine;

public class Storm : MonoBehaviour
{
    public GameObject lightningPanel; // UI �г�
    public float lightningDuration = 0.1f; // ������ ���ӵǴ� �ð�
    public float minInterval = 2f; // �ּ� ����
    public float maxInterval = 5f; // �ִ� ����
    public AudioClip thunderSound1; // ù ��° õ�� �Ҹ�
    public AudioClip thunderSound2; // �� ��° õ�� �Ҹ�

    private Image panelImage; // Image ������Ʈ
    private AudioSource audioSource; // AudioSource ������Ʈ

    private void Start()
    {
        panelImage = lightningPanel?.GetComponent<Image>();

        if (panelImage == null)
        {
            Debug.LogError("LightningPanel�� Image ������Ʈ�� ã�� �� �����ϴ�!");
            return; // �ʱ�ȭ�� �����ϸ� �޼��带 ����
        }

        // AudioSource ������Ʈ�� �߰�
        audioSource = gameObject.AddComponent<AudioSource>();

        // �� ���� õ�� �Ҹ��� �Ҵ���� �ʾҴ��� Ȯ��
        if (thunderSound1 == null || thunderSound2 == null)
        {
            Debug.LogError("�� ���� ThunderSound�� ��� �Ҵ�Ǿ�� �մϴ�!");
            return; // �ʱ�ȭ�� �����ϸ� �޼��带 ����
        }

        // �г��� ó���� �����ϰ� ����
        panelImage.color = new Color(1f, 1f, 1f, 0f);
        // õ�� ȿ�� ����
        StartCoroutine(PlayThunderstorm());
    }

    private IEnumerator PlayThunderstorm()
    {
        while (true)
        {
            // ������ ���� ����
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // ���� ȿ��
            StartCoroutine(LightningEffect());
            // ������ õ�� �Ҹ� ���
            StartCoroutine(PlayRandomThunderSound());
        }
    }

    private IEnumerator LightningEffect()
    {
        if (panelImage != null)
        {
            // �г� ���� ���� (���� ȿ��)
            panelImage.color = new Color(1f, 1f, 1f, 1f); // ������� ����
            yield return new WaitForSeconds(lightningDuration); // ��� ��ٸ�
            panelImage.color = new Color(1f, 1f, 1f, 0f); // �ٽ� �����ϰ� ����
        }
    }

    private IEnumerator PlayRandomThunderSound()
    {
        // 0 �Ǵ� 1�� ���� ���� �����Ͽ� �Ҹ� ����
        int randomIndex = Random.Range(0, 2);
        AudioClip selectedClip = randomIndex == 0 ? thunderSound1 : thunderSound2;

        // ���õ� �Ҹ� ���
        audioSource.clip = selectedClip;
        audioSource.Play();

        // �Ҹ� ��� �� 7�� ���
        yield return new WaitForSeconds(7f);

        // �Ҹ� ����
        audioSource.Stop();
    }

}
