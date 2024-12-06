using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotuar : StateMachineBehaviour
{
    public float atkRange = 50f;

    Transform player;
    Rigidbody2D rb;
    Flip flip;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerStats>().transform;
        rb = animator.GetComponent<Rigidbody2D>();
        flip = animator.GetComponent<Flip>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flip.LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) <= atkRange)
        {
            animator.SetTrigger("lightAttack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("lightAttack");
    }
}
