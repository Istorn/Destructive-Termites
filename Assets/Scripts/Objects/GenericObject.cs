using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class GenericObject : MonoBehaviour {

    public enum Model {
        
        [Category("SOFT OBJECT"), Description("THIS OBJECT IS ALWAYS EATABLE")]
        Soft = 0,
        [Category("HARD OBJECT"), Description("USE 'IRON DENTURE' TO EAT IT")]
        Hard = 1,
        [Category("LIVE OBJECT"), Description("USE 'MUSHROOM' TO ATTACK IT")]
        Live = 2/*,
        [Category("NOT EATABLE"), Description("THIS OBJECT IS NOT EATABLE")]
        NotEatable = 3*/
    }

    private int id = 0;

    private bool isHanging = false;

    private bool isOnSomething = false;

    protected Model model = Model.Soft;

    private Room room = null;

    private float strengthCoefficient = 0.01f;

    private float integrity = 100.0f;

    private Sprite[] sprites;

    private StartAttackCursor cursor = null;

    private int currentSprite = -1;

    private IEnumerator selectionCoroutine;

    private Colony attacker = null;

    private string name = "";

    private PolygonCollider2D physicsCollider = null;

    private Color color;

    protected virtual void Awake()
    {
        attacker = null;
        physicsCollider = gameObject.GetComponent<PolygonCollider2D>();
        physicsCollider.tag = Costants.TAG_OBJ_COLLIDER_PHYSICS;
        selectionCoroutine = StartPressing();
    }

    public int getIntegrity()
    {
        return Convert.ToInt32(integrity);
    }

    public int getId()
    {
        return id;
    }
    public string getName()
    {
        return name;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setPosition(Vector3 coordinates, int z_index)
    {
        gameObject.transform.position = new Vector3(coordinates.x, coordinates.y, -(float)z_index/10);
        GetComponent<SpriteRenderer>().sortingOrder = z_index;
    }

    public void setRoom(Room room)
    {
        this.room = room;
    }

    public Room getRoom()
    {
        return room;
    }

    public void setProperties(bool isOnSomething, bool isHanging, bool isHorizantallyFlipped, float strengthCoefficient)
    {
        this.strengthCoefficient = strengthCoefficient;
        this.isHanging = isHanging;
        this.isOnSomething = isOnSomething;

        if (!isHanging && !isOnSomething)
            Destroy(gameObject.GetComponent<Rigidbody2D>());

        int flip = isHorizantallyFlipped?-1:1;
        transform.localScale = new Vector3(transform.localScale.x * flip, transform.localScale.y, transform.localScale.z);
    }

    public void setObjectName(string objectName, string spriteName)
    {
        name = objectName;
        sprites = Resources.LoadAll<Sprite>("Levels/" + GameManager.getCurrentLevel().getLevelNumber() + "/Objects/" + spriteName);
        updateObjectSprite();

        BoxCollider2D selectionCollider = gameObject.AddComponent<BoxCollider2D>();
        selectionCollider.tag = Costants.TAG_OBJ_COLLIDER_SELECTION;

        float min = +100000;
        foreach (Vector2 point in physicsCollider.GetPath(0))
            if (point.y < min)
                min = point.y;

        selectionCollider.offset = new Vector2(0, (selectionCollider.size.y/2 - Math.Abs(min)) / 2);
        selectionCollider.size = new Vector2(selectionCollider.size.x, selectionCollider.size.y - (selectionCollider.size.y / 2 - Math.Abs(min)));
    }

    private void updateObjectSprite()
    {
        int i = (int)((100 - integrity) * (sprites.Length - 1) / 100);
        if (i >= 0 && i < sprites.Length && i != currentSprite)
        {
            currentSprite = i;
            GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
            color = GetComponent<SpriteRenderer>().color;
            PolygonCollider2D tempCollider = gameObject.AddComponent<PolygonCollider2D>();
            physicsCollider.pathCount = tempCollider.pathCount;
            for (int p = 0; p < tempCollider.pathCount; p++ )
                physicsCollider.SetPath(p, tempCollider.GetPath(p));
            Destroy(tempCollider);
        }
    }

    void enablePhysics()
    {
        isHanging = false;
        transform.Rotate(Vector3.forward * UnityEngine.Random.Range(Costants.OBJ_PHYSICS_ROTATION_BOUND_LEFT, Costants.OBJ_PHYSICS_ROTATION_BOUND_RIGHT));
        GetComponent<PolygonCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public bool attack(int numberOfAttackers)
    {
        if (integrity > 0)
        {
            integrity -= numberOfAttackers * strengthCoefficient;
            if (integrity < 0)
                integrity = 0;
            updateObjectSprite();
            if (isHanging)
                enablePhysics();
            return true;
        }
        else
        {
            if (UnityEngine.Random.Range(0, 11) < 3)
			    dropABooster();
            return false;
        }
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            StopCoroutine(selectionCoroutine);
            selectionCoroutine = StartPressing();
            StartCoroutine(selectionCoroutine);
        }
    }

    void OnMouseUp()
    {
        StopCoroutine(selectionCoroutine);
        if (cursor)
        {
            int attackers = cursor.GetComponent<StartAttackCursor>().attackers;
            Destroy(cursor.gameObject);

            if (attacker == null)
            {
                Colony colony = GameManager.getLevelGUI().instantiateColony();
                colony.setTarget(this);
            }
            attacker.addTermites(attackers);
            GameManager.getCurrentLevel().decreaseAvailableTermites(attackers);
        }
    }

    public void setAttacker(Colony attacker)
    {
        this.attacker = attacker;
    }

    public Colony getAttacker()
    {
        return attacker;
    }

    public void select()
    {
        Color transparentColor = new Color(1, 0, 0, 1);//new Color(color.r, color.g, color.b, 0.5f);
        GetComponent<Renderer>().material.color = transparentColor;
    }

    public void deselect()
    {
        //Color transparentColor = new Color(color.r, color.g, color.b, 1f);
        GetComponent<Renderer>().material.color = color;
    }

    IEnumerator StartPressing()
    {
        GameManager.getLevelGUI().objectSelected(this);
        yield return new WaitForSeconds(Costants.OBJ_TIME_TO_START_ATTACK);
        if ((GameManager.getCurrentLevel().getAvailableTermites() > 0))
        {
            cursor = GameManager.getLevelGUI().instantiateStartAttackCursor();
            cursor.availableAttackers = GameManager.getCurrentLevel().getAvailableTermites();
            cursor.setPosition(gameObject.transform.position);
            while (true)
            {
                if (!cursor.GetComponent<StartAttackCursor>().updateCursor())
                    OnMouseUp();
                yield return new WaitForSeconds(Costants.OBJ_TIME_TO_ADD_500_ATTACKERS * GameManager.getCurrentLevel().getAvailableTermites() / 500);
            }
        }
    }

    public string getCategory()
    {
        return Utils.GetEnumCategory(model);
    }

    public string getDescription()
    {
        return Utils.GetEnumDescription(model);
    }

    public Model getModel()
    {
        return model;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        float distance = GetComponent<SpriteRenderer>().sortingOrder - other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        if (distance > 0 && distance <= 5)
            enablePhysics();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((!collision.gameObject.tag.Equals(Costants.TAG_BACKGROUND)))
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
    }

	void dropABooster(){
		int maxDroppableTypes = 2;
        int boosterIdToDrop = UnityEngine.Random.Range(1, maxDroppableTypes + 1);   // creates a number between 1 and maxDroppableTypes
		switch (boosterIdToDrop)
            {
                case 1:
                    {
						GameObject droppedBooster = Instantiate(Resources.Load("Prefabs/Boosters/ironDentureBehaviour", typeof(GameObject))) as GameObject;
						droppedBooster.GetComponent<Transform>().position = this.transform.position;
                    };
                    break;
                case 2:
                    {
						GameObject droppedBooster = Instantiate(Resources.Load("Prefabs/Boosters/mushroomBehaviour", typeof(GameObject))) as GameObject;
						droppedBooster.GetComponent<Transform>().position = this.transform.position;
                    };
                    break;
                // case 3:
                    // {
						
                    // };
                    // break;
                // case 4:
                    // {
						
                    // };
                    // break;
                // case 5:
                    // {
						
                    // };
                    // break;
                // case 6:
                    // {
						
                    // }; break;
            }
	}
}
