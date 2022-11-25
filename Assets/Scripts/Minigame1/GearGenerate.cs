using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearGenerate : MonoBehaviour
{
    public Transform player;
    public GameObject gear;
    public Transform gears;

    float timer;
    float lastTime;

    private void Start() {
        timer = 0;
        lastTime = 0;
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer > lastTime + 2f) {
            int rand = Random.Range(0,3);
            if (rand == 0) {
                GameObject g = Instantiate(gear, new Vector3(-10, player.transform.position.y + Random.Range(2, 7), 0 ), Quaternion.identity);
                g.transform.parent = gears.transform;
                g.GetComponent<Gear>().gearType = 0;
            }
            else if (rand == 1) {
                GameObject g = Instantiate(gear, new Vector3(10, player.transform.position.y + Random.Range(2, 7), 0 ), Quaternion.identity);
                g.transform.parent = gears.transform;
                g.GetComponent<Gear>().gearType = 1;
            }
            else if (rand == 2) {
                GameObject g = Instantiate(gear, new Vector3(player.transform.position.x + Random.Range(-1.5f,1.5f), player.transform.position.y + 16, 0), Quaternion.identity);
                g.transform.parent = gears.transform;
                g.GetComponent<Gear>().gearType = 2;
            }
            lastTime += 2f;
        }
    }

}
