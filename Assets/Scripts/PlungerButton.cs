using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlungerButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject plungerButton;
    public GameObject plunger;
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("TapUp");
        //if (eventData.selectedObject == flipperButton)
        plunger.GetComponent<Plunger>().OnTouch(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("TapDown");
        //if (eventData.selectedObject == flipperButton)
        plunger.GetComponent<Plunger>().OnTouch(true);
    }
}
