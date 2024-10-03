using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEffectr : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public Animator animator;

    void Start()
    {
        // 파티클 재생 및 애니메이션 트리거
        rainParticleSystem.Play();
        animator.SetTrigger("PlayAnimation");
    }
}
