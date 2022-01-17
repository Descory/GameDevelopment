using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    protected Stats stat;

    protected virtual void Start(){
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        combat.OnAttack += OnAttack;
        stat = GetComponent<Stats>();
    }
    protected virtual void Update()
    {
        animator.SetBool("combat", combat.InCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
    }
    protected virtual void OnDamage()
    {
        animator.SetTrigger("gotHit");
    }
}
