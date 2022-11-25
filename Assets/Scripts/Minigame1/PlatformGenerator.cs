using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject parent;
    public GameObject platform;
    public int platformCnt;
    public float interval;
    public float minX, maxX;
    public float minW, maxW;
    
    void Start() {
        GeneratePlatform();
    }


    void Update() {
        
    }

    void GeneratePlatform() {
        for (int i = 0; i < platformCnt; i++) {
            GameObject p = Instantiate(platform, new Vector3(Random.Range(minX, maxX), i * interval - 2, 0) ,Quaternion.identity);
            p.GetComponent<SpriteRenderer>().size = new Vector2(Random.Range(minW, maxW), 0.15f);
            p.transform.parent = parent.transform;
        }
    }
}
