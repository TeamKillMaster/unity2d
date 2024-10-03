using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    public Color nightAmbientColor = new Color(0.05f, 0.05f, 0.1f); // 어두운 파란색
    public float nightAmbientIntensity = 0.1f;
    public Color nightDirectionalLightColor = new Color(0.1f, 0.1f, 0.2f);
    public float nightDirectionalLightIntensity = 0.2f;
    public Material nightSkybox;
    public GameObject[] lampObjects; // 전등 오브젝트 배열

    private Light directionalLight;

    void Start()
    {
        // 환경 조명 설정
        RenderSettings.ambientLight = nightAmbientColor;
        RenderSettings.ambientIntensity = nightAmbientIntensity;

        // 스카이박스 설정
        if (nightSkybox != null)
        {
            RenderSettings.skybox = nightSkybox;
        }

        // Directional Light 설정
        directionalLight = FindObjectOfType<Light>();
        if (directionalLight != null)
        {
            directionalLight.color = nightDirectionalLightColor;
            directionalLight.intensity = nightDirectionalLightIntensity;
        }

        // 포스트 프로세싱 효과 추가 (필요한 경우 추가)
        AddPostProcessingEffects();

        // 전등에 불빛 추가
        AddLightsToLamps();
    }

    void AddPostProcessingEffects()
    {
        // 포스트 프로세싱 효과를 추가하여 어두운 밤 분위기를 강화합니다.
        // 이 부분은 포스트 프로세싱 패키지 설정에 따라 다를 수 있습니다.
    }

    void AddLightsToLamps()
    {
        foreach (GameObject lamp in lampObjects)
        {
            GameObject lightGameObject = new GameObject("LampLight");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.color = Color.yellow; // 전등 불빛 색상
            lightComp.intensity = 5f; // 전등 불빛 밝기
            lightComp.range = 10f; // 전등 불빛 범위
            lightComp.type = LightType.Point; // 포인트 라이트

            lightGameObject.transform.SetParent(lamp.transform);
            lightGameObject.transform.localPosition = Vector3.zero; // 전등 오브젝트의 위치에 맞게 조정
        }
    }


}
