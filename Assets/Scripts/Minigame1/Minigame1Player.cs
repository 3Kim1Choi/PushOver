using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Player : MonoBehaviour
{

    public float moveSpeed, jumpForce, smoothing;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    float horizontalMove, verticalMove;
    Vector2 vel = Vector2.zero;
    bool jump, onGround;
    [SerializeField] Minigame1UI ui;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        transform.position = new Vector3(0, -3.5f, 0);
    }

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        onGround = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);
    }

    private void FixedUpdate() {
        //좌우 움직임
        Vector2 targetVelocity = new Vector2(horizontalMove * Time.deltaTime * moveSpeed * 10, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref vel, smoothing);
        //점프
        if (jump && onGround) {
            rb.AddForce(new Vector2(0, jumpForce ), ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("death")) {
            Debug.Log("gameover");
            Time.timeScale = 0;
            ui.GameFail();
        }
        if (col.CompareTag("clear")) {
            Debug.Log("clear");
            GameManager.Instance.M1Clear();
        }
    }

}
