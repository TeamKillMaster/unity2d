using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory; // �κ��丮 ���� ������Ʈ�� �Ҵ��� ����
    private Animator animator;
    private bool isInventoryOpen = false;

    void Start()
    {
        animator = inventory.GetComponent<Animator>(); // Animator ������Ʈ�� ������
        inventory.SetActive(false); // �κ��丮�� �⺻������ ��Ȱ��ȭ
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("dd");

            if (!isInventoryOpen) // �κ��丮�� ��Ȱ��ȭ�� ���¶��
            {
                inventory.SetActive(true); // �κ��丮 Ȱ��ȭ
                animator.SetTrigger("Open"); // Open �ִϸ��̼� Ʈ���� ����
                isInventoryOpen = true;
                StartCoroutine(Opening());

            }
            else
            {
                animator.SetBool("Stop", false);
                animator.SetTrigger("Close");
                
                // Close �ִϸ��̼� Ʈ���� ����
                // �ִϸ��̼��� ���� �� �κ��丮�� ��Ȱ��ȭ�ϱ� ���� �ڷ�ƾ ���
                StartCoroutine(DeactivateInventory());
                isInventoryOpen = false;
            }
        }
    }

    private IEnumerator DeactivateInventory()
    {
        // �ִϸ��̼� ���̸�ŭ ���
        yield return new WaitForSeconds(0.5f);
        inventory.SetActive(false); // �κ��丮 ��Ȱ��ȭ
    }

    private IEnumerator Opening()
    {
        yield return new WaitForSeconds(0.4f);
        Open();
    }

    private void Open()
    {
        animator.SetBool("Stop", true);

    }
    private IEnumerator Closing()
    {
        yield return new WaitForSeconds(0.4f);
        Close();
    }

    private void Close()
    {
        animator.SetBool("Stop", false);

    }


}
