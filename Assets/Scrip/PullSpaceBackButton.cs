using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PullSpaceBackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PullSpace pullSpace;
    public void OnPointerDown(PointerEventData eventData)
    {
        pullSpace.isPress = true;  
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pullSpace.isPress = false;
    }

    
}
