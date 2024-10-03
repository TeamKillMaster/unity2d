using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pos;
    public float charge = 0f;
    public float incrementValue = 1f; // 클릭당 증가할 값
    public float maxCharge = 100f; // 최대 충전 값

    private bool isClicking = false;
    private ObjectPool bulletPool;

    void Start()
    {
        // 총알 풀 초기화
        bulletPool = new ObjectPool(Bullet, 10); // 예시로 풀 크기를 10으로 설정
    }

    void Update()
    {
        RotateToMouse();

        if (Input.GetMouseButtonDown(0))
        {
            isClicking = true;
            StartCoroutine(IncrementCharge());
        }

        if (Input.GetMouseButtonUp(0))
        {
            FireBullet();
            charge = 0;
            isClicking = false;
        }
    }

    private void RotateToMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private IEnumerator IncrementCharge()
    {
        while (isClicking)
        {
            if (charge < maxCharge)
            {
                charge += incrementValue * Time.deltaTime * 10; // 시간 기반 증가
#if UNITY_EDITOR
                Debug.Log("Charge: " + charge);
#endif
            }
            yield return null;
        }
    }

    private void FireBullet()
    {
        if (charge >= maxCharge)
        {
            GameObject bullet = bulletPool.GetObject();
            if (bullet != null)
            {
                bullet.transform.position = pos.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                charge = 0f; // 발사 후 충전 초기화
            }
            else
            {
                Debug.LogWarning("Failed to get bullet from object pool.");
            }
        }
        else
        {
            Debug.LogWarning("Charge is not sufficient to fire.");
        }
    }

    public class ObjectPool
    {
        private GameObject objectPrefab;
        private List<GameObject> pool;

        public ObjectPool(GameObject prefab, int initialSize)
        {
            objectPrefab = prefab;
            pool = new List<GameObject>();

            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = GameObject.Instantiate(objectPrefab);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }

        public GameObject GetObject()
        {
            foreach (GameObject obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            // 모든 객체가 사용 중인 경우, 선택적으로 새 객체 생성 (사용 사례에 따라 다름)
            GameObject newObj = GameObject.Instantiate(objectPrefab);
            newObj.SetActive(false);
            pool.Add(newObj);
            return newObj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}