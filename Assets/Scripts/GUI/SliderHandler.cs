using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IEndDragHandler, IBeginDragHandler
{
    private bool isBeingDragged = false;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isBeingDragged)
            GameManager.getLevelGUI().sliderValueChanged();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;
        GameManager.getLevelGUI().sliderValueChanged();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
    }
}
