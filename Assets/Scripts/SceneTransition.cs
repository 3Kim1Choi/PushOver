using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void StartAnimation() {
        anim.SetTrigger("start");
    }
    public void EndAnimation() {
        anim.SetTrigger("end");
    }
}
