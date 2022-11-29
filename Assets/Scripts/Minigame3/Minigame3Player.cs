using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    [Header("Read Only")]
    public float curSpeed;
    [SerializeField] Minigame1UI minigame1UI;

    Rigidbody2D rb;
    CharacterAnimation c_anim;

    Vector2 movement;
    bool playing;
    
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
        StartCoroutine("Freeze");
    }

    IEnumerator Freeze() {
        yield return new WaitForSeconds(3f);
        playing = true;
    }
}
