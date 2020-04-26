/**
 * Slot.cs sees if there is a child object to set as currently in the slot
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public GameObject currentItem;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.childCount > 0)
        {
            currentItem = transform.GetChild(0).gameObject;
        }
        else
        { 
            currentItem = null;
        }
    }
}
