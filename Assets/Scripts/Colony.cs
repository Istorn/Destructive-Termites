using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Colony : MonoBehaviour, IDragHandler, IEndDragHandler {

    public Text label;
    public GameObject cursor; 

    private int termites = 0;

    private Sprite[] sprites = null;

    private int b = 0;
    private int spriteIndex = 0;

    private Level level = null;

    private GenericObject target = null;

    public List<Booster> boosters = null;

    private GameObject infoBar;

    private Vector2 oldPosition;
    private Room oldRoom; 

    private IEnumerator attackTargetCorountine = null;

	void Awake () {
        boosters = new List<Booster>();
        attackTargetCorountine = attackTarget();
	}

    public void setLevel(Level level)
    {
        this.level = level;
    }

    public void setTarget(GenericObject target)
    {
        if (this.target)
            this.target.setAttacker(null);
        this.target = target;

        oldPosition = target.gameObject.transform.position;
        oldRoom = target.room;

        Colony col = this.target.getAttacker();
        
        if (col)
        {
            col.addTermites(termites);
            foreach (Booster b in boosters)
                col.applyBooster(b);
            Destroy(gameObject);
        }
        
        target.setAttacker(this);
        cursor.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
        StartCoroutine(animate());
        StartCoroutine(attackTarget());
    }

    public bool applyBooster(Booster booster)
    {
        foreach (Booster b in boosters)
            if (b.type.Equals(booster.type))
                return false;
        boosters.Add(booster);

        GameObject indicatorsBackground = cursor.transform.Find("IndicatorsBackground").gameObject;
        float xWidth = indicatorsBackground.GetComponent<RectTransform>().rect.width;
        float xInc = xWidth / boosters.Count;

        for (int b = boosters.Count; b < 6; b++)
        {
            GameObject indicator = indicatorsBackground.transform.Find("Indicator" + b).gameObject;
            Image image = indicator.GetComponent<Image>();
            Color color = image.color;
            image.color = new Color(color.r, color.g, color.b, 0);
        }

        for(int b = 0; b < boosters.Count; b++)
        {
            float xPos = xInc * b + xInc / 2;
            float yPos = 0;
            
            GameObject indicator = indicatorsBackground.transform.Find("Indicator" + b).gameObject;
            Image image = indicator.GetComponent<Image>();
            Color color = image.color;
            image.color = new Color(color.r, color.g, color.b, 1);
            image.sprite = Resources.Load<Sprite>("GUI/AttackCursor/Booster_" + (int)boosters[b].type + "_background");
            image.enabled = true;
            indicator.transform.localPosition = new Vector3(xPos, yPos, 0);
        }
        return true;
    }

    IEnumerator animate()
    {
        while (true)
        {
            if ((sprites == null) || (spriteIndex == sprites.Length))
            {
                spriteIndex = 0;
                 if (boosters.Count == 0)
                     sprites = Resources.LoadAll<Sprite>("GUI/AttackCursor/Booster_0");
                 else
                 {
                     b++;
                     if (b == boosters.Count)
                         b = 0;
                     sprites = Resources.LoadAll<Sprite>("GUI/AttackCursor/Booster_" + (int)boosters[b].type);
                 }
            }
            cursor.GetComponent<Image>().sprite = sprites[spriteIndex];
            spriteIndex++; 
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void addTermites(int termites)
    {
        this.termites += termites;
        label.text = this.termites + "";
    }

    IEnumerator attackTarget()
    {
        while (target && (target.attack(termites)))
        {
            yield return new WaitForSeconds(1f);
        }
        changeTarget(null);
    }


    public int getTermites()
    {
        return this.termites;
    }

    public void select()
    {
        label.color = Color.red;
        level.infoBarScript.colonySelected(this);
    }

    public void deselect()
    {
        label.color = Color.white;
    }

    public void changeTarget(GenericObject target)
    {
        StopCoroutine(attackTargetCorountine);

        if (target)
            setTarget(target); 
        else
        {
            GenericObject newTarget = null;
            if (this.target)
            {
                newTarget = this.target.room.getOtherObject(this.target);
                this.target.room.removeObject(this.target);
                Destroy(this.target.gameObject);
                this.target = null;
                
            }
            else
            {
                oldRoom.getObject(oldPosition);
            }
                
            if (newTarget)
                setTarget(newTarget);
            else
            {//DA AGGIORNARE->ELIMINA COLONIA SE NON TROVA OGETTI NELLA STANZA
                Destroy(gameObject);
            }
            
        }
        attackTargetCorountine = attackTarget();
       /* StartCoroutine(attackTargetCorountine);*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        cursor.transform.position = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<GenericObject>().select();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            setTarget(hit.collider.gameObject.GetComponent<GenericObject>());
            
        }
        else
        {
            cursor.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position); 
        }
            
    }
}
