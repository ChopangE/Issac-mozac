using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerControl : MonoBehaviour
{
    public enum PlayerState {
        Idle, Run, Attack
    }
    protected PlayerState playerState = PlayerState.Idle;


    [Header("Player")] 
    protected Player.Player player;

    [Header("Animation")]
    protected Animator anim;
    [Header("Movement")]
    protected Rigidbody2D rb;
    public Vector2 direction;
    public Vector2 prevDirection;

    [Header("Attack")] 
    protected PlayerWeapon playerWeapon;
    protected bool isAttack;


    void Awake() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerWeapon = GetComponent<PlayerWeapon>();
        player = GetComponent<Player.Player>();
    }
    void Start()
    {
        isAttack = false;

    }
    void Update()
    {
        GetInput();
        SetStatus();
        switch (playerState) {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Run:
                UpdateRun();
                break;
            case PlayerState.Attack:
                UpdateAttack();
                break;
            default:
                break;
        }
        SetAnimation();
    }

    void UpdateIdle() {
        PlayerMove();
    }

    void UpdateRun() {
        PlayerMove();
    }

    void UpdateAttack()
    {
        
    }

    public void AttackEnd()
    {
        isAttack = false;
        anim.speed = 1.0f;
    }
    
    void GetInput()
    {
        //AttackMethod는 반드시 아래 코드를 포함하고 있어야함.
        AttackMethod();
        // if (Input.GetKeyDown(KeyCode.Z) && !isAttack)
        // {
        //     isAttack = true;
        //     rb.velocity = Vector2.zero;
        //     playerWeapon.StartAttack();
        //     anim.speed = player.atkSpeed;
        // }
        
        if (isAttack) return;
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if(inputX == 0 && inputY == 0 && (direction.x != 0 || direction.y != 0)) {
            prevDirection = direction;
        }
        direction = new Vector2(inputX, inputY);
       
    }

    public abstract void AttackMethod();
    void PlayerMove()
    {
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * player.speed, direction.y * player.speed);
    }
    void SetAnimation() {
        anim.SetFloat("PrevMoveX", prevDirection.x);
        anim.SetFloat("PrevMoveY", prevDirection.y);
        anim.SetFloat("MoveMag", direction.magnitude);
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetBool("Attack", isAttack);
    }

    void SetStatus() 
    {
        if (isAttack)
        {
            playerState = PlayerState.Attack;
            return;
        }
        if(direction.magnitude > 0.2f)playerState = PlayerState.Run;
        else playerState = PlayerState.Idle;
    }
}
