using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericObject : MonoBehaviour {

    public enum Types {
        
        [Description("Soft object")]
        Soft = 0,
        //[Description("Hard object: not eatable without a special toothing")]
        [Description("Hard object")]
        Hard = 1,
        //[Description("Live object: only fools would eat it")]
        [Description("Live object")]
        Live = 2
    }

    protected Types type;

    public int roomNumber;

    protected float strenghtCoefficient = 0.05f;

    public float integrity = 100.0f;
    protected float oldIntegrity = 100.0f;

    protected Sprite[] sprites;

    protected Level level = null;

    protected GameObject cursor = null;

    protected int avail = 500;
    public int counter = 0;
    private int currentSprite = -1;

    protected IEnumerator selectionCoroutine;

    protected Colony attacker = null;

    protected Color color;

    protected PolygonCollider2D primaryCollider = null;

    protected virtual void Awake()
    {
        attacker = null;
        primaryCollider = gameObject.GetComponent<PolygonCollider2D>();
        selectionCoroutine = StartPressing();
    }

    public void setLevel(Level level)
    {
        this.level = level;
    }

    public void setPosition(int roomNumber, Vector3 coordinates, int z_index)
    {
        this.roomNumber = roomNumber;
        gameObject.transform.position = new Vector3(coordinates.x, coordinates.y, -(float)z_index/10);
        GetComponent<SpriteRenderer>().sortingOrder = z_index;
    }

    public virtual void setObjectName(string objectName)
    {
        sprites = Resources.LoadAll<Sprite>("Levels/1/Objects/" + objectName); //SpriteSheets/Objects/" + objectName);
        color = GetComponent<Renderer>().material.color;
        updateObject();
    }

    private void updateObject()
    {
        int i = (int)((100 - integrity) * (sprites.Length - 1) / 100);
        if (i >= 0 && i < sprites.Length && i != currentSprite)
        {
            currentSprite = i;
            GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];

            PolygonCollider2D tempCollider = gameObject.AddComponent<PolygonCollider2D>();
            primaryCollider.pathCount = tempCollider.pathCount;
            for (int p = 0; p < tempCollider.pathCount; p++ )
            {
                primaryCollider.SetPath(p, tempCollider.GetPath(p));
            }
            //primaryCollider.points = tempCollider.points;
            Destroy(tempCollider);
        }
    }
    public void attack(int numberOfAttackers)
    {
        
        if (integrity > 0)
        {
            integrity -= numberOfAttackers * strenghtCoefficient;

            updateObject();

            transform.position = new Vector3 (transform.position.x, transform.position.y + 0.001f, transform.position.z);
            oldIntegrity = integrity;
            //Debug.Log(integrity);
           // Debug.Log(sprites.Length);
        }
        else
            Destroy(gameObject);
    }

    void OnMouseDown()
    {
        StopCoroutine(selectionCoroutine);
        selectionCoroutine = StartPressing();
        StartCoroutine(selectionCoroutine);
    }

    void OnMouseUp()
    {
        StopCoroutine(selectionCoroutine);
        if (cursor)
        {
            int at = cursor.GetComponent<StartAttackCursor>().attackers;
            Destroy(cursor);

            if (attacker == null)
            {
                GameObject colCursor = Instantiate(Resources.Load("Prefabs/Colony", typeof(GameObject))) as GameObject;
                colCursor.transform.parent = colCursor.transform;
                attacker = colCursor.GetComponent<Colony>();
                Button im = colCursor.transform.Find("Cursor").gameObject.GetComponent<Button>();
                im.onClick.AddListener(() => attacker.select());
                
                attacker.setTarget(this);
                attacker.setLevel(level);

            }
            attacker.addTermites(at);
            level.availableTermites -= at;
            level.usedTermites += at;
        }        
    }

    private void select()
    {
        level.infoBarScript.objectSelected(this);
        Color transparentColor = new Color(color.r, color.g, color.b, 0.5f);
        GetComponent<Renderer>().material.color = transparentColor;
    }

    public void deselect()
    {
        GetComponent<Renderer>().material.color = color;
    }

    IEnumerator StartPressing()
    {
        select();
        yield return new WaitForSeconds(Costants.OBJ_TIME_TO_START_ATTACK);
        if (level.availableTermites > 0)
        {
            cursor = Instantiate(Resources.Load("Prefabs/StartAttackCursor", typeof(GameObject))) as GameObject;
            cursor.GetComponent<StartAttackCursor>().availableAttackers = level.availableTermites;
            cursor.GetComponent<StartAttackCursor>().setPosition(gameObject.transform.position);
            while (true)
            {
                if (!cursor.GetComponent<StartAttackCursor>().updateCursor())
                    OnMouseUp();
                yield return new WaitForSeconds(Costants.OBJ_TIME_TO_ADD_500_ATTACKERS * level.availableTermites / 500);
            }
        }
    }

    public string getType()
    {
        return Utils.GetEnumDescription(type);
    }

/*
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTER: " + name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
    }

    */

    void OnTriggerExit2D(Collider2D other)
    {
       // Debug.Log("LEAVE: " + name);
        float distance = GetComponent<SpriteRenderer>().sortingOrder - other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        if (distance > 0 & distance <= 1.5)
        {
            transform.Rotate(Vector3.forward * Random.Range(-15, 15));
            GetComponent<PolygonCollider2D>().isTrigger = false;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Object"))
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
    }
}
