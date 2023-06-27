using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipperButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject flipperButton;
    public GameObject flipper;
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("TapUp");
        //if (eventData.selectedObject == flipperButton)
            flipper.GetComponent<Flippers>().FlipperUp(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("TapDown");
        //if (eventData.selectedObject == flipperButton)
            flipper.GetComponent<Flippers>().FlipperUp(true);
    }
}
