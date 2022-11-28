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
        public float targetSpeed;
        float speed;
        [Range(0f, 1f)]
        public float startPoint;
        float distanceTravelled;
        bool active;
        Vector2 movement;
        Vector2 posSave;


        void Start() {
            c_anim = GetComponent<CharacterAnimation>();
            rb = GetComponent<Rigidbody2D>();
            npcController = FindObjectOfType<NPCController>();
            targetSpeed = npcController.npcSpeed;
            distanceTravelled = pathCreator.path.length * startPoint;
            speed = targetSpeed;
            posSave = transform.position;
        }

        private void Update() {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            movement = (new Vector2(transform.position.x,transform.position.y) - posSave).normalized;
            posSave = new Vector2(transform.position.x, transform.position.y);
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
