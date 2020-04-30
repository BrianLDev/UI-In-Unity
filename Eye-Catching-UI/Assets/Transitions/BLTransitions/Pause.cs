using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update() {

        // toggles paused screen on spacebar
        if (Input.GetKeyUp(KeyCode.P) ) {
            bool isPaused = anim.GetBool("paused");
            if (!isPaused)
                anim.SetBool("paused", true); 
            else
                anim.SetBool("paused", false);
        }
    }
}
