using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEffectr : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public Animator animator;

    void Start()
    {
        // ��ƼŬ ��� �� �ִϸ��̼� Ʈ����
        rainParticleSystem.Play();
        animator.SetTrigger("PlayAnimation");
    }
}
