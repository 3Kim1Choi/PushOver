using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    [Header("Read Only")]
    public float curSpeed;

    Rigidbody2D rb;
    CharacterAnimation c_anim;

    Vector2 movement;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        c_anim = GetComponent<CharacterAnimation>();
    }


    void Update() {
        GetInput();
        curSpeed = rb.velocity.magnitude;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        c_anim.CheckAnim(movement);
    }

    //입력값 얻음
    void GetInput() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

}
