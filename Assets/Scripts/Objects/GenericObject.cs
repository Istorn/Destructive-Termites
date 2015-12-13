﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericObject : MonoBehaviour {

    public enum Types {
        
        [Description("SOFT OBJECT")]
        Soft = 0,
        //[Description("Hard object: not eatable without a special toothing")]
        [Description("HARD OBJECT")]
        Hard = 1,
        //[Description("Live object: only fools would eat it")]
        [Description("LIVE OBJECT")]
        Live = 2,
        [Description("NOT EATABLE")]
        NotEatable = 3
    }

    public int id = 0;

    public bool isHanging = true;

    public Types type = Types.NotEatable;

    public Room room = null;

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
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_NOT_EATABLE_OBJECTS);
    }

    public void setLevel(Level level)
    {
        this.level = level;
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

    void enablePhysics()
    {
        //transform.Rotate(Vector3.forward * Random.Range(-25, 25));
        GetComponent<PolygonCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public bool attack(int numberOfAttackers)
    {
        if (integrity > 0)
        {
            integrity -= numberOfAttackers * strenghtCoefficient;
            if (integrity < 0)
                integrity = 0;
            updateObject();
            if (isHanging)
                enablePhysics();

            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
            oldIntegrity = integrity;
            //Debug.Log(integrity);
            // Debug.Log(sprites.Length);
            return true;
        }
        else
        {
            integrity = 100;
            return true;
        }
           // return false;         
    }

    void OnMouseDown()
    {
        Debug.Log("DOWN: " + gameObject.name);
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
            int at = cursor.GetComponent<StartAttackCursor>().attackers;
            Destroy(cursor);

            if (attacker == null)
            {
                GameObject colCursor = Instantiate(Resources.Load("Prefabs/Colony", typeof(GameObject))) as GameObject;
                Colony colony = colCursor.GetComponent<Colony>();
                Button im = colCursor.transform.Find("Cursor").gameObject.GetComponent<Button>();
                im.onClick.AddListener(() => level.infoBarScript.colonySelected(colony));

                colony.setTarget(this);
                colony.setLevel(level); 

            }
            attacker.addTermites(at);
            level.availableTermites -= at;
            level.usedTermites += at;
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
        Color transparentColor = new Color(color.r, color.g, color.b, 0.5f);
        GetComponent<Renderer>().material.color = transparentColor;
    }

    public void deselect()
    {
        GetComponent<Renderer>().material.color = color;
    }

    IEnumerator StartPressing()
    {
        Debug.Log("CLIC: " + gameObject.name);
        level.infoBarScript.objectSelected(this);
        yield return new WaitForSeconds(Costants.OBJ_TIME_TO_START_ATTACK);
        Debug.Log(level.availableTermites + " --- " + type);
        if ((level.availableTermites > 0) && (type != Types.NotEatable))
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

    void OnTriggerExit2D(Collider2D other)
    {
       // Debug.Log("LEAVE: " + name);
        float distance = GetComponent<SpriteRenderer>().sortingOrder - other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        if (distance > 0 & distance <= 1.5)
        {
            enablePhysics();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Object"))
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
    }

}
