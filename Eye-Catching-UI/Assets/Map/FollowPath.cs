/**
 * FollowPath.cs holds path information for each location 
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public GameObject previousLocation = null;
    public GameObject nextLocation = null;
    public List<GameObject> previousPath;
    public List<GameObject> nextPath;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
