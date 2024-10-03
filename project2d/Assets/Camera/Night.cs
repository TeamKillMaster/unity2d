using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    public Color nightAmbientColor = new Color(0.05f, 0.05f, 0.1f); // ��ο� �Ķ���
    public float nightAmbientIntensity = 0.1f;
    public Color nightDirectionalLightColor = new Color(0.1f, 0.1f, 0.2f);
    public float nightDirectionalLightIntensity = 0.2f;
    public Material nightSkybox;
    public GameObject[] lampObjects; // ���� ������Ʈ �迭

    private Light directionalLight;

    void Start()
    {
        // ȯ�� ���� ����
        RenderSettings.ambientLight = nightAmbientColor;
        RenderSettings.ambientIntensity = nightAmbientIntensity;

        // ��ī�̹ڽ� ����
        if (nightSkybox != null)
        {
            RenderSettings.skybox = nightSkybox;
        }

        // Directional Light ����
        directionalLight = FindObjectOfType<Light>();
        if (directionalLight != null)
        {
            directionalLight.color = nightDirectionalLightColor;
            directionalLight.intensity = nightDirectionalLightIntensity;
        }

        // ����Ʈ ���μ��� ȿ�� �߰� (�ʿ��� ��� �߰�)
        AddPostProcessingEffects();

        // ��� �Һ� �߰�
        AddLightsToLamps();
    }

    void AddPostProcessingEffects()
    {
        // ����Ʈ ���μ��� ȿ���� �߰��Ͽ� ��ο� �� �����⸦ ��ȭ�մϴ�.
        // �� �κ��� ����Ʈ ���μ��� ��Ű�� ������ ���� �ٸ� �� �ֽ��ϴ�.
    }

    void AddLightsToLamps()
    {
        foreach (GameObject lamp in lampObjects)
        {
            GameObject lightGameObject = new GameObject("LampLight");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.color = Color.yellow; // ���� �Һ� ����
            lightComp.intensity = 5f; // ���� �Һ� ���
            lightComp.range = 10f; // ���� �Һ� ����
            lightComp.type = LightType.Point; // ����Ʈ ����Ʈ

            lightGameObject.transform.SetParent(lamp.transform);
            lightGameObject.transform.localPosition = Vector3.zero; // ���� ������Ʈ�� ��ġ�� �°� ����
        }
    }


}
