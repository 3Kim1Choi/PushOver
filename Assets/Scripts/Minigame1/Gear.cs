using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public int gearType;
    public float speed;
    [SerializeField] Sprite s1,s2,s3;
    SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        LeanTween.rotate(gameObject, new Vector3(0, 0, 90), 0.5f).setRepeat(30);
        if (gearType == 0) {
            LeanTween.moveX(gameObject, 10, Random.Range(4,6)).setEase(LeanTweenType.easeInOutCubic).setOnComplete(Destroy);
            sr.sprite = s1;
        } else if (gearType == 1) {
            LeanTween.moveX(gameObject, -10, Random.Range(4,6)).setEase(LeanTweenType.easeInOutCubic).setOnComplete(Destroy);
            sr.sprite = s2;
        } else if (gearType == 2) {
            LeanTween.moveY(gameObject, transform.position.y - 25, Random.Range(7,9)).setEase(LeanTweenType.easeInCubic).setOnComplete(Destroy);
            sr.sprite = s3;
        }
    }

    void Destroy() {
        Destroy(gameObject);
    }
    
}
