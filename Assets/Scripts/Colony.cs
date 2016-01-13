using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Colony : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    private Text label;

    private int termites = 0;

    private Sprite[] sprites = null;

    private int b = 0;
    private int spriteIndex = 0;

    private GenericObject target = null;

    public List<Booster> boosters = null;

    private Vector2 oldPosition;
    private Room oldRoom;

    private bool startDrag = false;

    private IEnumerator attackTargetCorountine = null;
    private IEnumerator animateCoroutine = null;

    private GameObject miniMapCursor = null;

	void Awake () {
        boosters = new List<Booster>();
        attackTargetCorountine = null;
	}

    public void setMiniMapCursor(GameObject miniMapCursor)
    {
        this.miniMapCursor = miniMapCursor;
    }

    public void attack()
    {
        //level.usedTermites -= termites;
      /*  if ((int)(termites * 0.1) < 10)
            termites = (int)(termites * 0.9);
        else
            termites -= 10;*/
        termites = Convert.ToInt32(termites * UnityEngine.Random.Range(0.85f, 0.99f));
        /*if (termites < 0)
            termites = 0;*/
       // level.usedTermites += termites;
        label.text = termites + "";
        if (termites == 0)
        {
            target.setAttacker(null);
            Destroy(gameObject);
        }  
    }

    void Update()
    {
        if (target && !startDrag)
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
            miniMapCursor.transform.position = target.gameObject.transform.position;
        }
    }

    void FixedUpdate()
    {
       /* for (int i = boosters.Count - 1; i >= 0; i--)
        {
            Booster b = boosters[i];
            b.activationTime -= Time.deltaTime;
            if (b.activationTime <= 0)
            {
                boosters.RemoveAt(i);
                applyBooster(null);
                Debug.Log("STOP");
            }
        }*/
    }

    public GenericObject getTarget()
    {
        return target;
    }

    void setAttackPossibility(bool possibility)
    {
        Color col = gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color;
        if (possibility)
            gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(col.r, col.g, col.b, 0f);
        else
            gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(col.r, col.g, col.b, 1f);
    }

    public void setTarget(GenericObject target)
    {
        if (this.target)
            this.target.setAttacker(null);
        this.target = target;
        if (!this.target.getModel().Equals(GenericObject.Model.Live))
            GameManager.getCurrentLevel().alertObjectsQueue.Enqueue(this.target);
        //gameObject.transform.parent = this.target.gameObject.transform;
        oldPosition = target.gameObject.transform.position;
        oldRoom = target.getRoom();

        Colony col = this.target.getAttacker();
        
        if (col)
        {
            col.addTermites(termites);
            foreach (Booster b in boosters)
                col.applyBooster(b);
            Destroy(gameObject);
        }
        
        this.target.setAttacker(this);
        
        if (animateCoroutine == null)
        {
            animateCoroutine = animate();
            StartCoroutine(animateCoroutine);
        }
        if (attackTargetCorountine != null)
            StopCoroutine(attackTargetCorountine);
        attackTargetCorountine = attackTarget();
        StartCoroutine(attackTargetCorountine);
    }

    public bool applyBooster(Booster booster)
    {
        if (booster != null)
        {
            Debug.Log("Apply");
            foreach (Booster b in boosters)
                if (b.getModel().Equals(booster.getModel()))
                    return false;
            Booster newBooster = new Booster();
           /* newBooster.setType(booster.type);
            newBooster.activationTime = Time.time;
            newBooster.owner = this;*/
            boosters.Add(newBooster);
        }
        GameObject indicatorsBackground = gameObject.transform.Find("IndicatorsBackground").gameObject;
        float xWidth = indicatorsBackground.GetComponent<RectTransform>().rect.width;
        float xInc = xWidth / boosters.Count;

        for (int b = boosters.Count; b < 6; b++)
        {
            GameObject indicator = indicatorsBackground.transform.Find("Indicator" + b).gameObject;
            Image image = indicator.GetComponent<Image>();
            Color color = image.color;
            image.color = new Color(color.r, color.g, color.b, 0);
        }

        for (int b = 0; b < boosters.Count; b++)
        {
            float xPos = xInc * b + xInc / 2;
            float yPos = 0;

            GameObject indicator = indicatorsBackground.transform.Find("Indicator" + b).gameObject;
            Image image = indicator.GetComponent<Image>();
            Color color = image.color;
            image.color = new Color(color.r, color.g, color.b, 1);
            image.sprite = Resources.Load<Sprite>("GUI/AttackgameObject/Booster_" + (int)boosters[b].getModel() + "_background");
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
                     sprites = Resources.LoadAll<Sprite>("GUI/AttackCursor/Booster_" + (int)boosters[b].getModel());
                 }
            }
            gameObject.GetComponent<Image>().sprite = sprites[spriteIndex];
            spriteIndex++; 
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void removeBooster(Booster.Model type)
    {
        for (int i = 0; i< boosters.Count; i++)
        {
            Booster b = boosters[i];
            if (b.getModel().Equals(type))
            {
                boosters.RemoveAt(i);
            }
        }
    }
    public void addTermites(int termites)
    {
        this.termites += termites;
        label.text = this.termites + "";
    }

    IEnumerator attackTarget()
    {
        bool continueAttack = true;
        while (target && continueAttack)
        {
            List<GenericObject.Model> eatableTypes = new List<GenericObject.Model>();
            eatableTypes.Add(GenericObject.Model.Soft);
            foreach (Booster b in boosters)
                eatableTypes = eatableTypes.Concat(b.getExtraEatableMaterials()).ToList();
            
            if (eatableTypes.Contains(target.getModel()))
            {
                continueAttack = target.attack(termites);
                setAttackPossibility(true);
            }
            else
            {
                continueAttack = true;
                setAttackPossibility(false);
            }
            yield return new WaitForSeconds(Costants.COLONY_ATTACK_FREQUENCY);
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
                newTarget = this.target.getRoom().getOtherObject(this.target);
                this.target.getRoom().removeObject(this.target);
                GenericObject selected = GameManager.getLevelGUI().getSelectedObject();
                if (selected && selected.getId() == this.target.getId())
                    GameManager.getLevelGUI().colonySelected(this);
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

    public void split(int newNumber)
    {
        GameObject colgameObject = Instantiate(Resources.Load("Prefabs/Colony", typeof(GameObject))) as GameObject;
        Colony colony = colgameObject.GetComponent<Colony>();
        Button im = colgameObject.transform.Find("gameObject").gameObject.GetComponent<Button>();
        im.onClick.AddListener(() => GameManager.getLevelGUI().colonySelected(colony));

        GenericObject newTarget = this.target.getRoom().getOtherObject(this.target);
        if (newTarget)
            //DA CERCARE IN OGNI STANZA
            colony.setTarget(newTarget);
        colony.addTermites(termites - newNumber);
        termites = newNumber;
        label.text = termites + "";
    }

    public void OnDrag(PointerEventData eventData)
    {
      /*  gameObject.transform.position = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GenericObject obj = hit.collider.gameObject.GetComponent<GenericObject>();
            //if (!obj.getModel().Equals(GenericObject.Model.NotEatable))
                GameManager.getLevelGUI().objectSelected(obj);
        }*/
    }
    public void setTermites(int numOftermites)
    {
        this.termites = numOftermites;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       /* RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            GenericObject obj = hit.collider.gameObject.GetComponent<GenericObject>();
           //if (!obj.getModel().Equals(GenericObject.Model.NotEatable))
                setTarget(obj);
        }
        else
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position); 
        }
        startDrag = false;*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       /* startDrag = true;*/
    }
}
