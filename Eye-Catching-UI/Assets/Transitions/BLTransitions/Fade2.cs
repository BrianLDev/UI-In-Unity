using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade2 : MonoBehaviour
{
    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update() {

        // toggles paused screen on spacebar
        if (Input.GetKeyUp(KeyCode.Space) ) {
            bool isFaded = anim.GetBool("fade");
            if (!isFaded)
                anim.SetBool("fade", true); 
            else
                anim.SetBool("fade", false);
        }
    }
}
