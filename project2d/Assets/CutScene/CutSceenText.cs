using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceenText : MonoBehaviour
{
    public TMP_Text dialogueText; // TMP �ؽ�Ʈ ������Ʈ ����
    public float typingSpeed = 0.05f; // �� ���� ��� �ӵ�

    [TextArea(3, 10)] // Inspector���� ���� ���� �ؽ�Ʈ �迭 ����
    public string[] dialogues; // ���� ��縦 �����ϴ� �迭

    public CutSceenScript otherScript; // CutSceneNow ������ ���� �ٸ� ��ũ��Ʈ ����

    // �ܺο��� ȣ���� �� �ִ� �Լ� (Ư�� �ε����� ��縦 ���)
    public void StartDialogue(int dialogueIndex)
    {
        if (dialogueIndex >= 0 && dialogueIndex < dialogues.Length) // ��ȿ�� �ε������� Ȯ��
        {
            StopAllCoroutines(); // ���� ��ȭ�� �����ִٸ� ����
            otherScript.CutSceenNow = true; // �ƽ� ���� �� true
            StartCoroutine(TypeSentence(dialogues[dialogueIndex])); // ������ �ε����� ��� ���
        }
        else
        {
            Debug.LogWarning("Invalid dialogue index!"); // ��ȿ���� ���� �ε��� ���
        }
    }

    // �� ���ھ� ����ϴ� �ڷ�ƾ
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; // ���� �ؽ�Ʈ �ʱ�ȭ
        foreach (char letter in sentence.ToCharArray()) // ������ �� ���ھ� ���
        {
            dialogueText.text += letter; // �� ���� �߰�
            yield return new WaitForSeconds(typingSpeed); // ������ �ӵ���ŭ ���
        }

        otherScript.CutSceenNow = false; // ��簡 ������ �ƽ� ���� -> ���� false
    }

    // ��ȭ ��ü�� ��ŵ�ϰ� ��� ����ϴ� ���
    public void SkipDialogue(int dialogueIndex)
    {
        if (dialogueIndex >= 0 && dialogueIndex < dialogues.Length) // ��ȿ�� �ε������� Ȯ��
        {
            StopAllCoroutines(); // ��ȭ ����
            dialogueText.text = dialogues[dialogueIndex]; // �ش� �ε����� ��� ��� ���
            otherScript.CutSceenNow = false; // ��簡 ������ �ƽ� ���� -> ���� false
        }
        else
        {
            Debug.LogWarning("Invalid dialogue index!"); // ��ȿ���� ���� �ε��� ���
        }
    }
}
