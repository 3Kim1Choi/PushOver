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
            lastTime += 2f;
            int rand = Random.Range(0,3);
            if (rand == 0) {
                GameObject g = ObjectPool.instance.gearQueue.Dequeue();
                g.transform.position = new Vector3(-10, player.transform.position.y + Random.Range(4, 10), 0 );
                g.SetActive(true);
                g.transform.parent = gears.transform;
                g.GetComponent<Gear>().gearType = 0;
                g.GetComponent<Gear>().Generated();
            }
            else if (rand == 1) {
                GameObject g = ObjectPool.instance.gearQueue.Dequeue();
                g.SetActive(true);
                g.transform.position = new Vector3(10, player.transform.position.y + Random.Range(4, 10), 0 );
                g.transform.parent = gears.transform;
                g.GetComponent<Gear>().gearType = 1;
                g.GetComponent<Gear>().Generated();
            }
            else if (rand == 2) {
                GameObject g = ObjectPool.instance.gearQueue.Dequeue();
                g.SetActive(true);
                g.transform.position = new Vector3(player.transform.position.x + Random.Range(-1.5f,1.5f), player.transform.position.y + 16, 0);
                g.transform.parent = gears.transform;
                g.GetComponent<Gear>().gearType = 2;
                g.GetComponent<Gear>().Generated();
            }
        }
    }

}
