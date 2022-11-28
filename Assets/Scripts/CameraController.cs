using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float maxLookAhead;
    public Transform player;
    public Vector2 maxXY,minXY;
    Camera cam;
    PlayerController playerController;
    Vector2 camPos;
    Vector3 fixPos;
    Vector3 targetPos;
    
    void Start() {
        playerController = player.GetComponent<PlayerController>();
        cam = GetComponent<Camera>();
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10f);
    }

    void FixedUpdate() {
        //카메라가 미리 앞으로 나가는 정도 -> 플레이어 속도에 비례
        float lookAhead = (playerController.curSpeed / playerController.moveSpeed) * maxLookAhead;
        //플레이어의 방향을 위치벡터로 전환
        float degree = (player.eulerAngles.z + 90) % 360;
        targetPos = new Vector3(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad) * 0.6f, 0) * lookAhead;
        //카메라의 위치 부드럽게 변환
        camPos = Vector2.Lerp(transform.position, player.position + targetPos, Time.deltaTime * speed);
        fixPos = new Vector3(Mathf.Clamp(camPos.x,minXY.x,maxXY.x),Mathf.Clamp(camPos.y,minXY.y,maxXY.y),transform.position.z);
        //카메라 위치 설정
        transform.position = fixPos;
    }
}
