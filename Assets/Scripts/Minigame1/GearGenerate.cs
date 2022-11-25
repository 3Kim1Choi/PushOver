using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearGenerate : MonoBehaviour
{
    public Transform player;
    public GameObject gear;

    float timer;
    float lastTime;

    private void Start() {
        timer = 0;
        lastTime = 0;
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer > lastTime + 1.5f) {
            int rand = Random.Range(0,3);
            if (rand == 0) {
                GameObject g = Instantiate(gear, new Vector3(-10, player.transform.position.y + Random.Range(2, 4), 0 ), Quaternion.identity);
                g.GetComponent<Gear>().gearType = 0;
            }
            else if (rand == 1) {
                GameObject g = Instantiate(gear, new Vector3(10, player.transform.position.y + Random.Range(2, 4), 0 ), Quaternion.identity);
                g.GetComponent<Gear>().gearType = 1;
            }
            else if (rand == 2) {
                GameObject g = Instantiate(gear, new Vector3(Random.Range(-4,4), player.transform.position.y + 12, 0),    Quaternion.identity);
                g.GetComponent<Gear>().gearType = 2;
            }
            lastTime += 1.5f;
        }
    }

}
