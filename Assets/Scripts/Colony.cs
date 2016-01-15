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

    private List<Booster> boosters = null;

    private Vector2 oldPosition;
    private Room oldRoom;

    private bool startDrag = false;

    private int roomNumber = 0;

    private IEnumerator attackTargetCorountine = null;
    private IEnumerator animateCoroutine = null;

    private GameObject miniMapCursor = null;

    private GenericObject previousSelected = null;

    private bool isToBePlaced = false;

    private LayerMask mask;

    private int remainingSecondsToPlace = Costants.COLONY_SECONDS_TO_PLACE;

    private IEnumerator placementCountdownCoroutine = null;

	void Awake () {
        boosters = new List<Booster>();
        attackTargetCorountine = null;
        label = gameObject.transform.Find("LabelBackground/Label").GetComponent<Text>();

        transform.Find("LabelBackground").gameObject.SetActive(false);
        mask = 1 << 13;
        mask = ~mask;
        placementCountdownCoroutine = placementCountdown();
        StartCoroutine(placementCountdownCoroutine);
	}

    public void setMiniMapCursor(GameObject miniMapCursor)
    {
        this.miniMapCursor = miniMapCursor;
    }

    public void attack()
    {
        int lost = Convert.ToInt32(termites * UnityEngine.Random.Range(0.01f, 0.15f));
        if (lost < 5)
            lost = 5;
        termites -= lost;
        GameManager.getCurrentLevel().decreaseAvailableTermites(lost);
        if (termites <= 0)
        {
            target.setAttacker(null);
            Destroy(gameObject);
        }
        else
            label.text = termites + "";
    }

    void FixedUpdate()
    {
        if (!startDrag)
            if (isToBePlaced)
                gameObject.transform.position = GameManager.getLevelGUI().getMessageAnchorPoint();
            else
                if (target)
                {
                    gameObject.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
                    miniMapCursor.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
                }
            else
                gameObject.transform.position = GameManager.getLevelGUI().getMessageAnchorPoint();

        if (startDrag)
            transform.Find("LabelBackground").gameObject.SetActive(true);
        else
            if (!startDrag && isToBePlaced)
                transform.Find("LabelBackground").gameObject.SetActive(false);
            else
                if (!startDrag && !isToBePlaced)
                    transform.Find("LabelBackground").gameObject.SetActive(true);
    }

  /*  void FixedUpdate()
    {
        for (int i = boosters.Count - 1; i >= 0; i--)
        {
            Booster b = boosters[i];
            b.activationTime -= Time.deltaTime;
            if (b.activationTime <= 0)
            {
                boosters.RemoveAt(i);
                applyBooster(null);
                Debug.Log("STOP");
            }
        }
    }*/

    public GenericObject getTarget()
    {
        return target;
    }

    void setAttackPossibility(bool possibility)
    {
        if (possibility)
            gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(1, 1, 1, 0f);
        else
            gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(1, 1, 1, 1f);
    }

    public void setTarget(GenericObject target)
    {
        if (this.target)
            this.target.setAttacker(null);
        this.target = target;
        roomNumber = target.getRoom().getNumber();
        /*if (!this.target.getModel().Equals(GenericObject.Model.Live))
            GameManager.getCurrentLevel().alertObjectsQueue.Enqueue(this.target);*/

        /*oldPosition = target.gameObject.transform.position;
        oldRoom = target.getRoom();*/

        Colony col = this.target.getAttacker();
        
        if (col)
        {
            addTermites(col.getTermites());
            foreach (Booster b in col.getBoosters())
                applyBooster(b);
            Destroy(col.gameObject);
        }
        
        this.target.setAttacker(this);
        setIsToBePlaced(false);
      /*  if (animateCoroutine == null)
        {
            animateCoroutine = animate();
            StartCoroutine(animateCoroutine);
        }
        if (attackTargetCorountine != null)
            StopCoroutine(attackTargetCorountine);
        attackTargetCorountine = attackTarget();
        StartCoroutine(attackTargetCorountine);*/
    }

    public List<Booster> getBoosters()
    {
        return boosters;
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
            image.sprite = Resources.Load<Sprite>("GUI/Boosters/Booster_" + (int)boosters[b].getModel() + "_background");
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
                     sprites = Resources.LoadAll<Sprite>("GUI/Boosters/Booster_0");
                 else
                 {
                     b++;
                     if (b == boosters.Count)
                         b = 0;
                     sprites = Resources.LoadAll<Sprite>("GUI/Boosters/Booster_" + (int)boosters[b].getModel());
                 }
            }
            gameObject.GetComponent<Image>().sprite = sprites[spriteIndex];
            spriteIndex++; 
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator placementCountdown()
    {
        while (remainingSecondsToPlace > 0)
        {
            transform.Find("Timer").GetComponent<Text>().text = remainingSecondsToPlace + "";
            remainingSecondsToPlace--;
            yield return new WaitForSeconds(1f);
        }
        GameManager.removeMessage();
        GameManager.getCurrentLevel().decreaseAvailableTermites(termites);
        Destroy(gameObject);
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
      /*  GenericObject oldTarget = target;
        target = findNewTarget(target);
        Destroy(oldTarget.gameObject);
        ChallengeMonitor.refresh(oldTarget);
       */
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

    public void split(float splitRatio)
    {
        int newNumber = Convert.ToInt32(termites * splitRatio);
        if (newNumber == termites)
            newNumber = termites - 1;
        
        if (newNumber == 0)
            termites = 1;
        if ((newNumber > 0) && (newNumber < termites))
        {
            Colony colony = GameManager.getLevelGUI().instantiateColony();
            colony.addTermites(newNumber);
            colony.setIsToBePlaced(true);
            termites = termites - newNumber;
            label.text = termites + "";
            GameManager.addMessage();
            /*EatableObject newTarget = findNewTarget(target);
            if (newTarget)
            {
                Colony colony = GameManager.getLevelGUI().instantiateColony();
                colony.setTarget(newTarget);
                Debug.Log(target.getId() + "   " + newTarget.getId());
                colony.addTermites(newNumber);
                newTarget.select(ObjectSelection.Model.BoosterApplication);
                termites = termites - newNumber;
                label.text = termites + "";
            }
            else
                GameManager.gameEnd();*/

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,  Mathf.Infinity, mask);
        
        if (hit.collider != null)
        {
            GenericObject obj = hit.collider.gameObject.transform.parent.GetComponent<GenericObject>();
            if (obj)
            {
                if (previousSelected)
                    previousSelected.deselect(ObjectSelection.Model.ColonyTarget);
                previousSelected = obj;
                obj.select(ObjectSelection.Model.ColonyTarget);
            }
        }
        else
            if (previousSelected)
            {
                previousSelected.deselect(ObjectSelection.Model.ColonyTarget);
                previousSelected = null;
            }
    }

    public void setTermites(int numOftermites)
    {
        this.termites = numOftermites;
    }

    public EatableObject findNewTarget(GenericObject other = null)
    {
        List<EatableObject> objects = GameManager.getCurrentLevel().getObjects();
        IEnumerable<EatableObject> others = null;

        Graph g = GameManager.getCurrentLevel().getGraphLiveObjects();

        int nO = g.findNearestNode(roomNumber, Camera.main.ScreenToWorldPoint(gameObject.transform.position));

        if (other)
            others = from o in objects
                     let distance = g.distance(nO, g.findNearestNode(o.getRoom().getNumber(), o.gameObject.transform.position))
                     where o.getId() != other.getId()
                     orderby distance
                     select (EatableObject)o;
        else
            others = from o in objects
                     let distance = g.distance(nO, g.findNearestNode(o.getRoom().getNumber(), o.gameObject.transform.position))
                     orderby distance
                     select (EatableObject)o;
            
        if (others.Count() == 0)
            return null;
        else
            return others.First();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Color color = gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color;
        if (color.a > 0)
            gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);

        if (previousSelected)
        {
            setTarget(previousSelected);
            if (!isToBePlaced)
            {
                setIsToBePlaced(false);
                GameManager.removeMessage();
            }
            previousSelected.deselect(ObjectSelection.Model.ColonyTarget);
            previousSelected = null;
        }
        else
        {
            if (!isToBePlaced)
                if (!target)
                    target = findNewTarget();
            if (target)
                gameObject.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
            else
                GameManager.gameEnd();
        }
        
        startDrag = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startDrag = true;
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        Color color = gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color;
        if (color.a > 0)
            gameObject.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
    }

    public void setIsToBePlaced(bool isToBePlaced)
    {
        this.isToBePlaced = isToBePlaced;
        if (!isToBePlaced)
        {
            transform.SetParent(GameManager.getLevelGUI().getGameAreaPanel().transform);
            StopCoroutine(placementCountdownCoroutine);
            transform.Find("Timer").gameObject.SetActive(false);
        }
    }
}
