using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Colony : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public GameObject colony = null;

    public Text label = null;

    public GameObject labelBackground = null;

    private int termites = 0;

    private int b = 0;
    private int spriteIndex = 0;

    private GenericObject target = null;

    private List<Booster> boosters = null;

    private Vector2 oldPosition;
    private Room oldRoom;

    private List<Sprite[]> sprites = null;
    private Sprite[] currentSprites = null;

    private bool startDrag = false;

    private int roomNumber = 0;

    private IEnumerator attackTargetCoroutine = null;
    private IEnumerator animateCoroutine = null;

    private GameObject miniMapCursor = null;

    private GenericObject previousSelected = null;

    private bool isToBePlaced = true;

    private Image boosterImage = null;

    

    

    private int remainingSecondsToPlace = Costants.COLONY_SECONDS_TO_PLACE;

    private IEnumerator placementCountdownCoroutine = null;

	void Awake () {
        boosters = new List<Booster>();

        labelBackground.SetActive(false);
        
        placementCountdownCoroutine = placementCountdown();
        animateCoroutine = animate();
        attackTargetCoroutine = attackTarget();

        sprites = new List<Sprite[]>();

        for (int i = 0; i < 7; i++)
            sprites.Add(Resources.LoadAll<Sprite>("GUI/Boosters/Booster_" + i));

        boosterImage = colony.GetComponent<Image>();
	}

    void Start()
    {
        StartCoroutine(placementCountdownCoroutine);
    }

    IEnumerator animate()
    {
        while (true)
        {
            if ((currentSprites == null) || (spriteIndex == currentSprites.Length))
            {
                spriteIndex = 0;
                if (boosters.Count == 0)
                    currentSprites = sprites[0];
                else
                {
                    b++;
                    if (b == boosters.Count)
                        b = 0;
                    currentSprites = sprites[(int)boosters[b].getModel()];
                }
            }
            boosterImage.sprite = currentSprites[spriteIndex];
            spriteIndex++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator placementCountdown()
    {
        while (isToBePlaced)
        {
            if (remainingSecondsToPlace == 0)
            {
                Debug.Log("Deleted");
                GameManager.removeMessage();
                GameManager.getCurrentLevel().decreaseAvailableTermites(termites);
                Destroy(gameObject);
            }
            colony.transform.Find("Timer").GetComponent<Text>().text = remainingSecondsToPlace + "";
            remainingSecondsToPlace--;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator attackTarget()
    {
        bool continueAttack = true;
        while (true)
        {
            if (target)
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
                if (!continueAttack)
                {
                    GenericObject oldTarget = target;
                    target = findNewTarget(target);
                    oldTarget.destroy();
                }
            }
            yield return new WaitForSeconds(Costants.COLONY_ATTACK_FREQUENCY);
        }
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
                colony.transform.position = GameManager.getLevelGUI().getMessageAnchorPoint();
            else
                if (target)
                {
                    colony.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
                    miniMapCursor.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
                }
            else
                    colony.transform.position = GameManager.getLevelGUI().getMessageAnchorPoint();

        if (startDrag)
            labelBackground.SetActive(true);
        else
            if (!startDrag && isToBePlaced)
                labelBackground.SetActive(false);
            else
                if (!startDrag && !isToBePlaced)
                    labelBackground.SetActive(true);
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
            GetComponent<Image>().color = new Color(1, 1, 1, 0f);
        else
            GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
    }

    public void setTarget(GenericObject target)
    {
        if (this.target)
            this.target.setAttacker(null);
        this.target = target;
        roomNumber = target.getRoom().getNumber();
        /*if (!this.target.getModel().Equals(GenericObject.Model.Live))
            GameManager.getCurrentLevel().alertObjectsQueue.Enqueue(this.target);*/

        Colony col = this.target.getAttacker();
        
        if (col)
        {
            addTermites(col.getTermites());
            foreach (Booster b in col.getBoosters())
                applyBooster(b.getModel());
            Destroy(col.gameObject);
        }
        
        this.target.setAttacker(this);
    }

    public List<Booster> getBoosters()
    {
        return boosters;
    }

    public bool applyBooster(Booster.Model model)
    {
        if (hasBooster(model))
            return false;

        switch (model)
        {
            case Booster.Model.QueenTermite:
                int adds = termites * Costants.QUEEN_TERMITE_THRESHOLD;
                if (adds < Costants.QUEEN_TERMITE_THRESHOLD)
                    adds = Costants.QUEEN_TERMITE_THRESHOLD;
                termites += adds;
                return true;
        }
        boosters.Add(Booster.initFromModel(model));
        updateIndicators();
        return true;
    }

    private void updateIndicators()
    {
        GameObject indicatorsBackground = colony.transform.Find("IndicatorsBackground").gameObject;
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
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        colony.transform.position = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,  Mathf.Infinity, Costants.RAYCAST_MASK);
        
        if (hit.collider != null)
        {
            GenericObject obj = hit.collider.gameObject.transform.parent.GetComponent<EatableObject>();
            if (obj)
            {
                if (previousSelected)
                    previousSelected.deselect(ObjectSelection.Model.ColonyTarget);
                previousSelected = obj;
                obj.select(ObjectSelection.Model.ColonyTarget);
            }
            else
                if (previousSelected)
                {
                    previousSelected.deselect(ObjectSelection.Model.ColonyTarget);
                    previousSelected = null;
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

    public bool hasBooster(Booster.Model model)
    {
        foreach (Booster b in boosters)
            if (b.getModel().Equals(model))
                return true;
        return false;
    }

    public EatableObject findNewTarget(GenericObject other = null)
    {
        List<EatableObject> objects = GameManager.getCurrentLevel().getObjects();
        IEnumerable<EatableObject> others = null;

        Graph g = GameManager.getCurrentLevel().getGraphLiveObjects();

        int nO = g.findNearestNode(roomNumber, Camera.main.ScreenToWorldPoint(colony.transform.position));

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
       /* Color color = gameObject.transform.parent.transform.Find("NotAttackImage").GetComponent<Image>().color;
        if (color.a > 0)
            gameObject.transform.parent.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);*/

        if (previousSelected)
        {
            setTarget(previousSelected);
            previousSelected.deselect(ObjectSelection.Model.ColonyTarget);
            previousSelected = null;
        }
        else
        {
            if (!isToBePlaced)
                if (!target)
                    target = findNewTarget();
            if (target)
                colony.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
            else
                GameManager.gameEnd();
        }
        
        startDrag = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startDrag = true;
       /* gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        Color color = gameObject.transform.parent.transform.Find("NotAttackImage").GetComponent<Image>().color;
        if (color.a > 0)
            gameObject.transform.parent.transform.Find("NotAttackImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);*/
    }

    public void setIsToBePlaced(bool isToBePlaced)
    {
        if (!isToBePlaced)
        {
            GameManager.removeMessage();
            colony.transform.Find("Timer").gameObject.SetActive(false);
            colony.transform.SetParent(GameManager.getLevelGUI().getGameAreaPanel().transform);
            StopCoroutine(placementCountdownCoroutine);
            StartCoroutine(animateCoroutine);
            StartCoroutine(attackTargetCoroutine);
            boosterImage.color = new Color(1, 1, 1, 0.6f);
        }
        this.isToBePlaced = isToBePlaced;
    }
}
