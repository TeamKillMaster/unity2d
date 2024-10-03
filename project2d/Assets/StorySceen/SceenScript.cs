using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceenScript : MonoBehaviour
{
    public Text dialogueText;  // Unity UI�� Text ������Ʈ
    public float typingSpeed = 0.05f;  // ���ڰ� ��Ÿ���� �ӵ�
    public string[] sentences;  // ����� ������� �迭�� ����
    public AudioSource typingSound;
    public AudioClip[] typingClips; // ���� ���� Ÿ���� ȿ���� �迭

    public int index = 0;  // ���� ������ �ε���
    private bool isTyping = false;  // �ؽ�Ʈ ��� ������ ���� Ȯ��

    private void Start()
    {
        // ù ��° ���� ��� ����
        StartCoroutine(TypeSentence(sentences[index]));
    }

    private void Update()
    {
        // �����̽��ٸ� ������ �ؽ�Ʈ ����� ������ �� ���� �������� �̵�
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextSentence();
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;  // �ؽ�Ʈ ��� ������ ǥ��
        dialogueText.text = "";  // �ؽ�Ʈ�� �ʱ�ȭ

        // �Էµ� ������ �� ���ھ� �߰�
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            // 70% Ȯ���� Ÿ���� �Ҹ� ���
            if (Random.Range(0f, 1f) <= 0.7f && typingClips.Length > 0)
            {
                int randomIndex = Random.Range(0, typingClips.Length);
                typingSound.PlayOneShot(typingClips[randomIndex]);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;  // �ؽ�Ʈ ����� ����
    }

    private void NextSentence()
    {
        // ���� ������ ������ ���
        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            dialogueText.text = "��簡 ��� �������ϴ�.";  // ������ ��� ���� ǥ���� �޽���
        }
    }
}
