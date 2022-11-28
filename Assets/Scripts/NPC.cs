using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation {
    public class NPC : MonoBehaviour {
        CharacterAnimation c_anim;
        Rigidbody2D rb;

        NPCController npcController;
        public PathCreator pathCreator;
        public int pathNum;
        public EndOfPathInstruction endOfPathInstruction;
        public Transform player;
        public float targetSpeed;
        float speed;
        [Range(0f, 1f)]
        public float startPoint;
        float distanceTravelled;
        bool active;
        Vector2 movement;


        void Start() {
            c_anim = GetComponent<CharacterAnimation>();
            rb = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            npcController = FindObjectOfType<NPCController>();
            targetSpeed = npcController.npcSpeed;
            distanceTravelled = pathCreator.path.length * startPoint;
            speed = targetSpeed;
        }

        private void Update() {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            movement = new Vector2(rb.velocity.x, rb.velocity.y).normalized;
        }

        private void FixedUpdate() {
            c_anim.CheckAnim(movement);
        }

        public void MoveNPC() {
            LeanTween.value(gameObject, speed, targetSpeed, 2f).setOnUpdate((x) => speed = x);
        }
        public void StopNPC() {
            speed = 0;
        }
    }

}
