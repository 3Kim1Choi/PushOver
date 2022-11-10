using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] TitleScreen titleScreen;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;

    private void Update() {
        if (titleScreen.index == thisIndex) {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1) {
                animator.SetBool("pressed", true);
            } else if (animator.GetBool("pressed")) {
                animator.SetBool("pressed",false);
            }
        } else {
            animator.SetBool("selected",false);
        }
    }
    
}
