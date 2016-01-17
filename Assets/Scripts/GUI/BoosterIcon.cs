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

    private Sprite sprite = null;

    private bool contains = false;

    private Vector3 startPosition;

    private GenericObject previousSelectedObject = null;
    private Colony previousSelectedColony = null;

    void Start()
    {
        startPosition = cursor.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            if (previousSelectedObject)
                if (previousSelectedColony)
                {
                    if (previousSelectedColony.applyBooster(model))
                    {
                        GameManager.getLevelGUI().usedBooster(model);
                        for (int i = 0; i < GameManager.getCurrentLevel().getCollectedBoosters().Count; i++)
                        {
                            Booster b = GameManager.getCurrentLevel().getCollectedBoosters()[i];
                            if (b.getModel().Equals(model))
                            {
                                GameManager.getCurrentLevel().getCollectedBoosters().RemoveAt(i);
                                break;
                            }
                        }
                    }
                    previousSelectedObject.deselect(ObjectSelection.Model.ColonyTarget);
                    previousSelectedObject = null;
                    previousSelectedColony = null;
                }
            cursor.transform.position = startPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        contains = false;
        foreach (Booster b in GameManager.getCurrentLevel().getCollectedBoosters())
            if (b.getModel().Equals(model))
            {
                contains = true;
                break;
            }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
            if (contains)
            {
                cursor.transform.position = Input.mousePosition;
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, Costants.RAYCAST_MASK);

                if (hit.collider != null)
                {
                    GenericObject obj = hit.collider.gameObject.transform.parent.GetComponent<EatableObject>();
                    if ((obj) && (obj.getAttacker()))
                    {
                        if (previousSelectedObject)
                            previousSelectedObject.deselect(ObjectSelection.Model.BoosterApplication);
                        previousSelectedObject = obj;
                        previousSelectedColony = obj.getAttacker();
                        obj.select(ObjectSelection.Model.ColonyTarget);
                    }
                    else
                        if (previousSelectedObject)
                        {
                            previousSelectedObject.deselect(ObjectSelection.Model.BoosterApplication);
                            previousSelectedObject = null;
                            previousSelectedColony = null;
                        }
                }
                else
                    if (previousSelectedObject)
                    {
                        previousSelectedObject.deselect(ObjectSelection.Model.BoosterApplication);
                        previousSelectedObject = null;
                        previousSelectedColony = null;
                    }
            }
    }
}
