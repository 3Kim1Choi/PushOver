using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Player : MonoBehaviour
{

    public float moveSpeed, jumpForce, smoothing;

    Rigidbody2D rb;
    float horizontalMove, verticalMove;
    Vector2 vel = Vector2.zero;
    bool jump, onGround;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        
        
    }

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    private void FixedUpdate() {
        //좌우 움직임
        Vector2 targetVelocity = new Vector2(horizontalMove * Time.deltaTime * moveSpeed * 10, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref vel, smoothing);
        //점프
        if (jump) {
            rb.AddForce(new Vector2(0, jumpForce ), ForceMode2D.Impulse);
            jump = false;
        }
    }

}
