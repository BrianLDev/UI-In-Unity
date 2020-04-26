/**
 * ItemAction.cs allows object to be dragged onto a Slot and have text appear when hovered over
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAction : MonoBehaviour {

    public Canvas canvas;
    Vector3 origin;
    public List<GameObject> Slots;
    GameObject hover;

    // Use this for initialization
    void Start () {
		
	}

    public void StartHover()
    {
        if (hover == null)
        {
            GameObject instance = Instantiate(Resources.Load("HoverText", typeof(GameObject))) as GameObject;
            hover = instance;
            hover.transform.GetChild(0).GetComponent<Text>().text = gameObject.name;
            hover.transform.parent = canvas.transform;
            hover.transform.localScale = Vector3.one;
            hover.transform.position = new Vector2(transform.position.x, transform.position.y+40f);
        }
    }

    public void EndHover()
    {
        if (hover != null)
        {
            Destroy(hover);
            hover = null;
        }
    }

    public void Select()
    {
        EndHover();
        origin = transform.position;
    }

    public void Drag()
    {
        EndHover();
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);
    }

    public void Drop()
    {
        EndHover();
        bool moved = false;
        foreach (GameObject slot in Slots)
        {
            if (slot.GetComponent<Slot>().currentItem == null)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint
                    (slot.transform as RectTransform, Input.mousePosition))
                {
                    // make sure it was dropped in a slot
                    transform.parent = slot.transform;
                    transform.localPosition = Vector3.zero;
                    slot.GetComponent<Slot>().currentItem = gameObject;
                    moved = true;
                }
            }
        }

        if (!moved)
        {
            //   move the card back to original position
            transform.position = origin;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
