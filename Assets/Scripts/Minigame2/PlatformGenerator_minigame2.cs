using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator_minigame2 : MonoBehaviour
{
    public GameObject parent;
    public GameObject platform;
    public int platformCnt;
    public float min_interval, max_interval;
    public float yPos1,yPos2;
    
    void Start() {
        GeneratePlatform();
    }


    void Update() {
        
    }

    void GeneratePlatform() {
        float prevX = 0;
        for (int i = 0; i < platformCnt; i++) {
            int yRand = Random.Range(0,2);
            //tmpY = Mathf.Clamp(tmpY, -maxYDif, maxYDif);
            GameObject p = Instantiate(platform, new Vector3(i * (max_interval + min_interval) / 2 + Random.Range(min_interval, max_interval) - (max_interval + min_interval) / 2 + 40, yPos1, 0) ,Quaternion.identity);
            prevX = p.transform.position.x;
            p.transform.parent = parent.transform;
        }
    }
}
