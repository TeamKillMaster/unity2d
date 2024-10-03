using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSound : MonoBehaviour
{
    // AudioSource ������Ʈ�� ������ ����
    private AudioSource audioSource;

    // Start�� ��ũ��Ʈ�� ����� �� ó�� �� �� ȣ��˴ϴ�.
    void Start()
    {
        // GameObject�� ����� AudioSource ������Ʈ�� �����ɴϴ�.
        audioSource = GetComponent<AudioSource>();

        // �ݺ� ��� ����
        audioSource.loop = true;

        // ����� ��� ����
        audioSource.Play();
    }


}
