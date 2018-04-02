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

    private BoxCollider2D colliderPlayer;
    public Rigidbody2D rigidbodyPlayer;

    public float walkspeed = 10.0f;
    private float H;
    private float V;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        colliderPlayer= GetComponent<BoxCollider2D>();
       // rigidbodyPlayer= GetComponent<Rigidbody2D>();

        animator.SetBool("Run", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //在这里取得移动
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

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

    private void FixedUpdate()
    {
        //在fixupdate中改变刚体受力
        Move();
    }

    private void Move()
    {
        if (Mathf.Abs(H) > 0.1 || Mathf.Abs(V) > 0.1)
        {
            Debug.Log("move  is  on H:" + H + "   V:" + V);
            Vector2 movement = new Vector2(H, V);
            // rigidbodyPlayer.AddForce(movement * walkspeed);
            if (stateInfo.IsName(IdleState)|| stateInfo.IsName("Run"))
            {
                animator.SetBool("Run", true);
                transform.Translate(movement * walkspeed);
            }
            
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    private void Attack()
    {
        if (stateInfo.IsName(IdleState) && stateInfo.normalizedTime > 0.1f)
        {
            animator.SetInteger("Attack", 1);
        }
        if (stateInfo.IsName(Attack1State) && stateInfo.normalizedTime > 0.6f)
        {
            animator.SetInteger("Attack", 2);
        }
        if (stateInfo.IsName(Attack2State) && stateInfo.normalizedTime > 0.6f)
        {
            animator.SetInteger("Attack", 3);
        }
    }
}
