using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    [Header("Read Only")]
    public float curSpeed;

    Rigidbody2D rb;
    Animator anim;

    Vector2 movement;
    //애니메이션 관련
    string animationState;
    bool movingSideways = true;
    bool moving;
    char dir;
    const string IDLE = "OneChoi_idle";
    const string WALK = "OneChoi_walk";
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update() {
        GetInput();
        curSpeed = rb.velocity.magnitude;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        CheckAnim();
    }

    //입력값 얻음
    void GetInput() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void CheckAnim() {
        if (movement.magnitude < 0.1f) {
            if (moving) {
                ChangeAnimationState(IDLE + dir);
                moving = false;
            }
        } else {
            if(movingSideways) {
                if (movement.x > 0)
                    dir = 'R';
                else if (movement.x < 0)
                    dir = 'L';
                else {
                    if (movement.y > 0) 
                        dir = 'U';
                    else if (movement.y < 0)
                        dir = 'D';
                    movingSideways = false;
                }
            } else {
                if (movement.y > 0) 
                    dir = 'U';
                else if (movement.y < 0)
                    dir = 'D';
                else {
                    if (movement.x > 0)
                        dir = 'R';
                    else if (movement.x < 0)
                        dir = 'L';
                    movingSideways = true;
                }
            }
            ChangeAnimationState(WALK + dir);
            moving = true;
        }
    }

    void ChangeAnimationState(string newState) {
        if (animationState == newState)
            return;
        
        anim.Play(newState);
        animationState = newState;
    }

}
