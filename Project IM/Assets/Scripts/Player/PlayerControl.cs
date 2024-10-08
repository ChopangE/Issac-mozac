using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    enum PlayerState {
        Idle, Run, Attack
    }
    PlayerState playerState = PlayerState.Idle;


    [Header("Animation")]
    Animator anim;

    [Header("Movement")]
    Rigidbody2D rb;
    float moveSpeed = 4.0f;
    Vector2 direction;
    Vector2 prevDirection;



    void Awake() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        switch (playerState) {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Run:
                UpdateRun();
                break;
            case PlayerState.Attack:
                break;
            default:
                break;
        }
        SetAnimation();
        SetStatus();
    }

    void UpdateIdle() {
        InputMove();
        PlayerMove();
    }

    void UpdateRun() {
        InputMove();
        PlayerMove();
    }



    void InputMove() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if(inputX == 0 && inputY == 0 && (direction.x != 0 || direction.y != 0)) {
            prevDirection = direction;
        }
        
        direction = new Vector2(inputX, inputY);
        
    }

    void PlayerMove() {
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
    void SetAnimation() {
        anim.SetFloat("PrevMoveX", prevDirection.x);
        anim.SetFloat("PrevMoveY", prevDirection.y);
        anim.SetFloat("MoveMag", direction.magnitude);
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
    }

    void SetStatus() {
        if(direction.magnitude > 0.2f)playerState = PlayerState.Run;
        else playerState = PlayerState.Idle;
    }
}
