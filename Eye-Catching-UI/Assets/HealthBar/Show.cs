/**
 * Show.cs allows a boolean to be set on or off for showing the HP image
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour {

    public bool show;
    public GameObject HeartFull;
	
    // Use this for initialization
	void Start () {
        show = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (show)
        {
            HeartFull.GetComponent<Image>().enabled = true;
        }
        else
        {
            HeartFull.GetComponent<Image>().enabled = false;
        }
	}
}
