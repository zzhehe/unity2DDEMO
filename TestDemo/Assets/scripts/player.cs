using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private Animator animator;
    private AnimatorStateInfo stateInfo;

    private const string IdleState = "Idle";
    private const string Attack1State = "Attack1";
    private const string Attack2State = "Attack2";


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();

        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName(IdleState) && stateInfo.normalizedTime > 0.8f)
        {
            animator.SetInteger("Attack", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Attack();
        }
    }

    private void MovePlayer()
    {
        throw new NotImplementedException();
    }

    private void Attack()
    {
        if (stateInfo.IsName(IdleState) && stateInfo.normalizedTime > 0.1f)
        {
            animator.SetInteger("Attack", 1);
            Debug.Log("attack1  is  on");
        }
        if (stateInfo.IsName(Attack1State) && stateInfo.normalizedTime > 0.8f)
        {
            animator.SetInteger("Attack", 2);
            Debug.Log("attack2  is  on");
        }
        if (stateInfo.IsName(Attack2State) && stateInfo.normalizedTime > 0.8f)
        {
            animator.SetInteger("Attack", 3);
            Debug.Log("attack3  is  on");
        }
    }
}
