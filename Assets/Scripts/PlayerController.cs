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

    Vector2 movement;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {
        GetInput();
        curSpeed = rb.velocity.magnitude;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    //입력값 얻음
    void GetInput() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

}
