using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearAnimation : MonoBehaviour
{
    public int minigameNum;
    [SerializeField] GameObject heart;
    [SerializeField] GameObject shadow;
    [SerializeField] Slider slider;
    

    private void Start() {
        minigameNum = GameManager.Instance.minigame;
        LeanTween.moveY(heart, 510f, 0.7f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scaleX(shadow, 0.8f, 0.7f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(heart, 490f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(0.7f);
        LeanTween.scaleX(shadow, 1f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(0.7f);
        LeanTween.moveY(heart, 510f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(1.4f);
        LeanTween.scaleX(shadow, 0.8f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(1.4f);
        LeanTween.moveY(heart, 490f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(2.1f);
        LeanTween.scaleX(shadow, 1f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(2.1f);
        LeanTween.moveY(heart, 510, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(2.8f);
        LeanTween.scaleX(shadow, 0.8f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(2.8f);
        LeanTween.moveY(heart, 490, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(3.5f);
        LeanTween.scaleX(shadow, 1f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(3.5f);
        LeanTween.moveY(heart, 510, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(4.2f);
        LeanTween.scaleX(shadow, 0.8f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(4.2f);
        LeanTween.moveY(heart, 490, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(4.9f);
        LeanTween.scaleX(shadow, 1f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(4.9f);
        LeanTween.moveY(heart, 510, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(5.6f);
        LeanTween.scaleX(shadow, 0.8f, 0.7f).setEase(LeanTweenType.easeInOutSine).setDelay(5.6f).setOnComplete(ChangeScene);
        if (minigameNum == 1) {
            LeanTween.value(gameObject, 0, 0.35f, 2.5f).setEase(LeanTweenType.easeInQuad).setOnUpdate((float val) => {slider.value = val;}).setDelay(1f);
            slider.value = 0;
        }
        if (minigameNum == 2) {
            LeanTween.value(gameObject, 0.35f, 0.58f, 2.5f).setEase(LeanTweenType.easeInQuad).setOnUpdate((float val) => {slider.value = val;}).setDelay(1f);
            slider.value = 0.35f;
        }
        if (minigameNum == 3) {
            LeanTween.value(gameObject, 0.67f, 1f, 2.5f).setEase(LeanTweenType.easeInQuad).setOnUpdate((float val) => {slider.value = val;}).setDelay(1f);
            slider.value = 5.8f;
        }
    }

    void ChangeScene() {
        GameManager.Instance.ToUniv();
    }

}
