using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    [Header("Read Only")]
    public float curSpeed;
    public GameObject bubble;
    [SerializeField] Minigame1UI minigame1UI;

    Rigidbody2D rb;
    CharacterAnimation c_anim;

    Vector2 movement;
    bool playing;
    [SerializeField] GameObject exclamationMark;
    [SerializeField] Camera cam;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        c_anim = GetComponent<CharacterAnimation>();
        playing = true;
    }

    void Update() {
        if (playing)
            GetInput();
        curSpeed = rb.velocity.magnitude;
        if(Input.GetKeyDown(KeyCode.I))
            minigame1UI.GameFail();
            
    }

    private void FixedUpdate() {
        if (playing)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        c_anim.CheckAnim(movement);
    }

    //입력값 얻음
    void GetInput() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    public void Caught() {
        playing = false;
        exclamationMark.SetActive(true);
        exclamationMark.transform.position = cam.WorldToScreenPoint(transform.position + Vector3.up * 1.3f);
        movement = Vector2.zero;
        StartCoroutine("Freeze");
    }

    IEnumerator Freeze() {
        yield return new WaitForSeconds(2f);
        playing = true;
        exclamationMark.SetActive(false);
        GameManager.Instance.M3Fail();
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("clear")) {
            playing = false;
            StartCoroutine("wait");
            Vector3 pos = cam.WorldToScreenPoint(transform.position);
            bubble.transform.position = pos;
            bubble.SetActive(true);
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(3);
        GameManager.Instance.M3Clear();
    }
}
