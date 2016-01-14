using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoosterIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isDraggable = true; 

    public GameObject cursor;

    public Booster.Model model;

    private Booster booster = null;

    private Sprite sprite = null;

    private Level level = null;

    

    private bool contains = false;
    private Vector3 startPosition;

    void Awake()
    {
        booster = Booster.initFromModel(model);
    }

    void Start()
    {
        startPosition = cursor.transform.position;
        level = GameObject.Find("Level").GetComponent<Level>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
            if (contains)
            {
                cursor.transform.position = Input.mousePosition;
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    GenericObject obj = hit.collider.gameObject.GetComponent<GenericObject>();
                    if (obj.getAttacker())
                        GameManager.getLevelGUI().objectSelected(obj);
                }
            }
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                GenericObject obj = hit.collider.transform.parent.GetComponent<GenericObject>();
                if (obj.getAttacker())
                {
                    if (obj.getAttacker().applyBooster(booster))
                    {
                        for (int i = 0; i < level.getCollectedBoosters().Count; i++)
                        {
                            Booster b = level.getCollectedBoosters()[i];
                            if (b.getModel().Equals(booster.getModel()))
                            {
                                level.getCollectedBoosters().RemoveAt(i);
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
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        contains = false;
        foreach (Booster b in level.getCollectedBoosters())
            if (b.getModel().Equals(booster.getModel()))
            {
                contains = true;
                break;
            }
    }
}
