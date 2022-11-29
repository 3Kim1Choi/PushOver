using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation {
    public class Guard : MonoBehaviour {
        CharacterAnimation c_anim;
        Rigidbody2D rb;
        [SerializeField] FieldOfView fieldOfView;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        [Range(0f, 1f)]
        public float startPoint;
        public float maxSpeed;
        public float viewDist;
        public float fov;
        float distanceTravelled;
        bool active;
        Vector2 movement;
        Vector2 posSave;
        float targetSpeed;
        float speed;
        

        private void Start() {
            c_anim = GetComponent<CharacterAnimation>();
            rb = GetComponent<Rigidbody2D>();
            targetSpeed = maxSpeed;
            distanceTravelled = pathCreator.path.length * startPoint;
            speed = targetSpeed;
            posSave = transform.position;
            fieldOfView.fov = fov;
            fieldOfView.viewDistance = viewDist;
        }

        private void Update() {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            movement = (new Vector2(transform.position.x,transform.position.y) - posSave).normalized;
            posSave = new Vector2(transform.position.x, transform.position.y);
        }

        private void FixedUpdate() {
            c_anim.CheckAnim(movement);
            fieldOfView.setAimDirection(movement);
            fieldOfView.SetOrigin(transform.position);
        }
    }
}
