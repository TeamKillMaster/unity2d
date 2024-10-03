using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory; // 인벤토리 게임 오브젝트를 할당할 변수
    private Animator animator;
    private bool isInventoryOpen = false;

    void Start()
    {
        animator = inventory.GetComponent<Animator>(); // Animator 컴포넌트를 가져옴
        inventory.SetActive(false); // 인벤토리를 기본적으로 비활성화
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("dd");

            if (!isInventoryOpen) // 인벤토리가 비활성화된 상태라면
            {
                inventory.SetActive(true); // 인벤토리 활성화
                animator.SetTrigger("Open"); // Open 애니메이션 트리거 설정
                isInventoryOpen = true;
                StartCoroutine(Opening());

            }
            else
            {
                animator.SetBool("Stop", false);
                animator.SetTrigger("Close");
                
                // Close 애니메이션 트리거 설정
                // 애니메이션이 끝난 후 인벤토리를 비활성화하기 위해 코루틴 사용
                StartCoroutine(DeactivateInventory());
                isInventoryOpen = false;
            }
        }
    }

    private IEnumerator DeactivateInventory()
    {
        // 애니메이션 길이만큼 대기
        yield return new WaitForSeconds(0.5f);
        inventory.SetActive(false); // 인벤토리 비활성화
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
