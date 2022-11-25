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
    public float maxXDif;
    
    void Start() {
        GeneratePlatform();
    }


    void Update() {
        
    }

    void GeneratePlatform() {
        float prevX = 0;
        for (int i = 0; i < platformCnt; i++) {
            float tmpX = Random.Range(minX, maxX);
            tmpX = Mathf.Clamp(tmpX, -maxXDif, maxXDif);
            GameObject p = Instantiate(platform, new Vector3(tmpX, i * interval - 2, 0) ,Quaternion.identity);
            p.GetComponent<SpriteRenderer>().size = new Vector2(Random.Range(minW, maxW), 0.15f);
            prevX = p.transform.position.x;
            p.transform.parent = parent.transform;
        }
    }
}
