using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pos;
    public float charge = 0f;
    public float incrementValue = 1f; // Ŭ���� ������ ��
    public float maxCharge = 100f; // �ִ� ���� ��

    private bool isClicking = false;
    private ObjectPool bulletPool;

    void Start()
    {
        // �Ѿ� Ǯ �ʱ�ȭ
        bulletPool = new ObjectPool(Bullet, 10); // ���÷� Ǯ ũ�⸦ 10���� ����
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
                charge += incrementValue * Time.deltaTime * 10; // �ð� ��� ����
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
                charge = 0f; // �߻� �� ���� �ʱ�ȭ
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

            // ��� ��ü�� ��� ���� ���, ���������� �� ��ü ���� (��� ��ʿ� ���� �ٸ�)
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