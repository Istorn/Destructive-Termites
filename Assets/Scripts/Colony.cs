using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Colony : MonoBehaviour {

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
        this.target = target;
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
        while (target.attack(termites))
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
       // Debug.Log("OLD: " + this.target.id);
        StopCoroutine(attackTargetCorountine);

        if (target)
            setTarget(target); 
        else
        {
            GenericObject newTarget = this.target.room.getOtherObject(this.target);
            this.target.room.removeObject(this.target);
            if (newTarget)
                setTarget(newTarget);
            //Debug.Log("NEW: " + newTarget.id);
        }
        
        attackTargetCorountine = attackTarget();
       /* StartCoroutine(attackTargetCorountine);*/
    }
}
