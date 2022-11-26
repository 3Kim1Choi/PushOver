using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameTitle;
    [SerializeField] Image characterImg;
    [SerializeField] Sprite[] OneChoi;
    [SerializeField] Sprite[] Harang;
    [SerializeField] Sprite[] TaeHan;

    private void Update() {
        if (nameTitle.text == "김원최") {
            characterImg.sprite = OneChoi[0];
        }
        if (nameTitle.text == "류하랑") {
            characterImg.sprite = Harang[0];
        }
        if (nameTitle.text == "송태한") {
            characterImg.sprite = TaeHan[0];
        }
    }

}
