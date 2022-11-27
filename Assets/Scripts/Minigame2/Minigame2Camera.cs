using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2Camera : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float startPosX;

    Camera cam;
    Vector2 camPos;
    Vector3 targetPos;
    float camMaxY;
    
    void Start() {
        cam = GetComponent<Camera>();
        transform.position = new Vector3(startPosX, 1.14f, -10f);
        camMaxY = startPosX;
    }

    void FixedUpdate() {
        if (player.position.x > camMaxY) {
            //카메라의 위치 부드럽게 변환
            camPos = Vector2.Lerp(player.position, transform.position, Time.deltaTime * speed);
            //카메라 위치 설정
            transform.position = new Vector3(camPos.x + 0.2f, 1.14f, transform.position.z);
            camMaxY = player.position.x;
        }
    }
}
