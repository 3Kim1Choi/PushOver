using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Camera : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float startPosY;

    Camera cam;
    Vector2 camPos;
    Vector3 targetPos;
    float camMaxY;
    
    void Start() {
        cam = GetComponent<Camera>();
        transform.position = new Vector3(0, startPosY, -10f);
        camMaxY = startPosY;
    }

    void FixedUpdate() {
        if (player.position.y > camMaxY) {
            //카메라의 위치 부드럽게 변환
            camPos = Vector2.Lerp(transform.position, player.position, Time.deltaTime * speed);
            //카메라 위치 설정
            transform.position = new Vector3(0, camPos.y,transform.position.z);
            camMaxY = player.position.y;
        }
    }
}
