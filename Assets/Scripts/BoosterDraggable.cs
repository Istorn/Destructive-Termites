using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoosterDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject cursor;

    private Sprite sprite = null;

    private Level level = null;

    private Boost booster = null;

    public Booster.Types type;

    private bool contains = false;
    private Vector3 startPosition;

    void Awake()
    {
        booster = new Boost();
        booster.type = type;
    }

    void Start()
    {
        level = GameObject.Find("Level").GetComponent<Level>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (contains)
        {
            cursor.transform.position = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                GenericObject obj = hit.collider.gameObject.GetComponent<GenericObject>();
                if (obj.getAttacker())
                    level.infoBarScript.objectSelected(obj);
            }
        }
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GenericObject obj = hit.collider.gameObject.GetComponent<GenericObject>();
            if (obj.getAttacker())
            {
                Debug.Log("APPLYBO: " + booster.type);
                if (obj.getAttacker().applyBooster(booster))
                {
                    for (int i = 0; i < level.collectedBoosters.Count; i++)
                    {
                        Boost b = level.collectedBoosters[i];
                        if (b.type.Equals(booster.type))
                        {
                            level.collectedBoosters.RemoveAt(i);
                            break;
                        }
                    }
                }
                        
            }
            cursor.transform.position = startPosition;
        }
        else
            cursor.transform.position = startPosition;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = cursor.transform.position;
        contains = false;
        foreach (Boost b in level.collectedBoosters)
            if (b.type.Equals(type))
            {
                contains = true;
                break;
            }
    }
}
