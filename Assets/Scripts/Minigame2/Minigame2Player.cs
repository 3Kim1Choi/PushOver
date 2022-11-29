using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2Player : MonoBehaviour
{
    public bool playing;
    public float moveSpeed, jumpForce, smoothing;
    public Transform GroundCheck1;
    public LayerMask groundLayer;
    public GameObject bubble;
    public Camera cam;

    Rigidbody2D rb;
    Animator anim;
    float horizontalMove, verticalMove;
    Vector2 vel = Vector2.zero;
    bool jump, onGround, facingLeft;
    string animationState;
    [SerializeField] Minigame2UI ui;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start() {
        StartMinigame();
    }

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        onGround = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);
    }

    void StartMinigame() {
        transform.position = new Vector3(-1.04f, -0.475189f, 0);
        playing = true;
        facingLeft = true;
    }

    private void FixedUpdate() {
        if (!playing)
            return;

        Vector2 targetVelocity = new Vector2(3 * Time.deltaTime * moveSpeed * 10, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref vel, smoothing);

        if (jump && onGround) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }

        //애니메이션
        if (!onGround) {
            AnimationControl("jump");
        }
        else {
            AnimationControl("run");
        }
        
        
        if (facingLeft) {
            facingLeft = false;
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y, transform.localScale.z);
        }
    }

        void AnimationControl(string animation) {
        if (animation == animationState)
            return;
        anim.Play(animation);
        animationState = animation;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("death") && playing) {
            Debug.Log("gameover");
            playing = false;
            rb.velocity = Vector3.zero;
            ui.GameFail();
        }
        if (col.CompareTag("clear")) {
            Debug.Log("clear");
            StartCoroutine("wait");
            playing = false;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            Vector3 pos = cam.WorldToScreenPoint(transform.position);
            bubble.transform.position = pos;
            bubble.SetActive(true);
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(3);
        GameManager.Instance.M1Clear();
    }

}