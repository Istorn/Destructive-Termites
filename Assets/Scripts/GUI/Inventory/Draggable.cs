using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	
	//IBeginDragHandler implementation
	public void OnBeginDrag(PointerEventData eventData){
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}

	//IDragHandler implementation
	public void OnDrag(PointerEventData eventData){
		transform.position = Input.mousePosition;
	}
	
	//IEndDragHandler implementation
	public void OnEndDrag(PointerEventData eventData){
		itemBeingDragged = null;
		transform.position = startPosition;
	}
}

