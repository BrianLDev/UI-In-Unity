/**
 * CardAction.cs allows drag and drop to a discard pile
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAction : MonoBehaviour {

    public Canvas canvas;
    Vector3 origin;
    public GameObject DiscardPile;
    public GameObject DiscardCard;

    // Use this for initialization
    void Start () {

    }

    public void Select()
    {
        origin = transform.position;
    }

    public void Drag()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);
    }

    public void Drop()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint
            (DiscardPile.transform as RectTransform, Input.mousePosition))
        {
            // make sure it was dropped in discard pile, if it was
            //   move the card into the discard deck
            transform.parent = DiscardPile.transform;
        }
        else
        {
            //   move the card back to original position
            transform.position = origin;
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
