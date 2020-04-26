/**
 * WalkTheMap.cs iteratively finds the path to walk from one location to another 
 * and queues it up for player icon
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WalkTheMap : MonoBehaviour {

    public Image playerIcon;
    public GameObject currentLocation;
    public GameObject selectedLocation;
    public List<GameObject> path;
    bool walking;

    // Use this for initialization
    void Start () {
        walking = false;
    }

    void FindNextPath()
    {
        // try the next path
        GameObject find = currentLocation;
        int tries = 0;
        while (find != null && 
               find.GetComponent<FollowPath>().nextLocation != null &&
               tries < 10)
        {
            find = find.GetComponent<FollowPath>().nextLocation;
            tries++;
            if (find != null && find == selectedLocation)
            {
                AddPathStepsToQueue(true);
                return;
            }
        }

        // try the previous path
        find = currentLocation;
        tries = 0;
        while (find != null && 
               find.GetComponent<FollowPath>().previousLocation != null &&
               tries < 10)
        {
            find = find.GetComponent<FollowPath>().previousLocation;
            tries++;
            if (find != null && find == selectedLocation)
            {
                // it's in the prev path
                AddPathStepsToQueue(false);
                return;
            }
        }

        // problem, we didn't find that location in any path
        Debug.Log("not found!");
    }

    void AddPathStepsToQueue(bool next)
    {
        if (next) // next location
        {
            while (currentLocation.GetComponent<FollowPath>().nextLocation != selectedLocation)
            {
                path.AddRange(currentLocation.GetComponent<FollowPath>().nextPath);
                currentLocation = currentLocation.GetComponent<FollowPath>().nextLocation;
                path.Add(currentLocation);
            }
            path.AddRange(currentLocation.GetComponent<FollowPath>().nextPath);
            path.Add(selectedLocation);
        }
        else // previous location
        {
            while (currentLocation.GetComponent<FollowPath>().previousLocation != selectedLocation)
            {
                path.AddRange(currentLocation.GetComponent<FollowPath>().previousPath);
                currentLocation = currentLocation.GetComponent<FollowPath>().previousLocation;
                path.Add(currentLocation);
            }
            path.AddRange(currentLocation.GetComponent<FollowPath>().previousPath);
            path.Add(selectedLocation);
        }
    }

    public void WalkToLocation(Button current)
    {
        // wait for walking to be done
        if (!walking) { 
            selectedLocation = EventSystem.current.currentSelectedGameObject; // current
            FindNextPath();
        }
    }

    // Update is called once per frame
    void Update() {
        if (selectedLocation != currentLocation)
        {
            // start walking
            if (path.Count > 0)
            {
                walking = true;
                GameObject location = path[0];
                if (playerIcon.transform.position.x != location.transform.position.x &&
                    playerIcon.transform.position.y != location.transform.position.y)
                {
                    playerIcon.transform.position = 
                        Vector3.MoveTowards(playerIcon.transform.position, 
                                            location.transform.position, Time.deltaTime * 200f);
                }
                else
                {
                    path.RemoveAt(0);
                }
            }
            else if (path.Count == 0)
            {
                walking = false;
                if (playerIcon.transform.position.x != selectedLocation.transform.position.x &&
                    playerIcon.transform.position.y != selectedLocation.transform.position.y)
                {
                    playerIcon.transform.position = 
                        Vector3.MoveTowards(playerIcon.transform.position, 
                                            selectedLocation.transform.position,
                                            Time.deltaTime * 200f);
                }
                else
                {
                    currentLocation = selectedLocation;
                }
            }
        }
    }
}
