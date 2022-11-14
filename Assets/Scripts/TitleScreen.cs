using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    [SerializeField] GameObject[] letters;
    [SerializeField] GameObject bg, stopSign;
    public AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        MoveLetters();
        MoveSign();
        ShowBG();
    }

    void Update() {
        if (Input.GetAxis("Vertical") != 0) {
            if (!keyDown) {
                if (Input.GetAxis("Vertical") < 0) {
                    if (index < maxIndex) {
                        index++;
                    } else {
                        index = 0;
                    }
                } else if (Input.GetAxis("Vertical") > 0) {
                    if (index > 0) {
                        index--;
                    } else {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        } else {
            keyDown = false;
        }
    }

    void MoveLetters() {
        letters[0].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,-9);
        letters[1].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,12);
        letters[2].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,-12);
        letters[3].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,-14);
        letters[4].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,16);
        letters[5].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,-13);
        letters[6].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,12);
        letters[7].GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,9);
        foreach(GameObject letter in letters) {
            letter.GetComponent<RectTransform>().localScale = new Vector3(0.01f, 0.01f, 1f);
            letter.GetComponent<CanvasGroup>().alpha = 0;
        }
        LeanTween.rotate(letters[0],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.rotate(letters[1],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(0.3f);
        LeanTween.rotate(letters[2],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(0.6f);
        LeanTween.rotate(letters[3],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(0.9f);
        LeanTween.rotate(letters[4],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(1.2f);
        LeanTween.rotate(letters[5],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(1.5f);
        LeanTween.rotate(letters[6],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(1.8f);
        LeanTween.rotate(letters[7],new Vector3(0,0,0),0.3f).setEase(LeanTweenType.easeOutBack).setDelay(2.1f);

        LeanTween.alphaCanvas(letters[0].GetComponent<CanvasGroup>(), 1, 0.3f);
        LeanTween.alphaCanvas(letters[1].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(0.3f);
        LeanTween.alphaCanvas(letters[2].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(0.6f);
        LeanTween.alphaCanvas(letters[3].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(0.9f);
        LeanTween.alphaCanvas(letters[4].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(1.2f);
        LeanTween.alphaCanvas(letters[5].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(1.5f);
        LeanTween.alphaCanvas(letters[6].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(1.8f);
        LeanTween.alphaCanvas(letters[7].GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(2.1f);

        LeanTween.scale(letters[0], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[1], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[2], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[3], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[4], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[5], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[6], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.scale(letters[7], new Vector3(1f,1f,1f),0.3f).setEase(LeanTweenType.easeOutBack);
    }

    void MoveSign() {
        stopSign.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,16);
        stopSign.GetComponent<RectTransform>().anchoredPosition = new Vector3(573.7255f, 1200f, 0);

        LeanTween.value(stopSign,1200f,32.171f,0.3f).setDelay(2.2f).setOnUpdate((float val) => {stopSign.GetComponent<RectTransform>().anchoredPosition = new Vector3(573.7255f, val, 0);});
        LeanTween.rotate(stopSign, new Vector3(0,0,0), 0.5f).setDelay(2.5f).setEase(LeanTweenType.easeOutBounce);
    }

    void ShowBG() {
        bg.GetComponent<CanvasGroup>().alpha = 0;

        LeanTween.alphaCanvas(bg.GetComponent<CanvasGroup>(), 1, 0.3f).setDelay(3f);
    }

    public void Button(int n) {
        if (n == 0) {
            GameManager.Instance.GameStart();
        } if (n == 1) {
            GameManager.Instance.Credit();
        } else if (n == 3) {
            GameManager.Instance.Quit();
        }
    }
    
}
