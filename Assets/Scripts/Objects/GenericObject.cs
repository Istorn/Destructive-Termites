using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class GenericObject : MonoBehaviour {

    public enum Types {
        [Description("Soft object: easily edible")]
        Soft = 0,
        [Description("Hard object: not edible without a special toothing")]
        Hard = 1,
        [Description("Live object: only fools would eat it")]
        Live = 2
    }

    protected Types type;

    public int roomNumber;

    protected float strenghtCoefficient = 0.2f;

    public float integrity = 100.0f;
    protected float oldIntegrity = 100.0f;

    protected Sprite[] sprites;

    protected Level level = null;

    protected GameObject cursor = null;

    protected int avail = 500;
    public int counter = 0;

    protected GameObject infoBar;

    protected IEnumerator selectionCoroutine;

    protected Colony attacker;
    protected Color color;

    protected virtual void Awake()
    {
        attacker = null;
        selectionCoroutine = StartPressing();
    }

    public void setLevel(Level level)
    {
        this.level = level;
    }

    public void setPosition(int roomNumber, Vector3 coordinates, int z_index)
    {
        this.roomNumber = roomNumber;
        gameObject.transform.position = new Vector3(coordinates.x, coordinates.y, -(float)z_index / 100);
        GetComponent<SpriteRenderer>().sortingOrder = z_index;
    }

    public virtual void setObjectName(string objectName)
    {
        sprites = Resources.LoadAll<Sprite>("Levels/1/Objects/" + objectName); //SpriteSheets/Objects/" + objectName);
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        color = GetComponent<Renderer>().material.color;
        gameObject.AddComponent<PolygonCollider2D>();
    }

    void attack(int numberOfAttackers)
    {
        if (integrity > 0)
        {
            integrity -= numberOfAttackers * strenghtCoefficient;
            int i = (int)((100 - integrity) * (sprites.Length - 1) / 100);
            GetComponent<SpriteRenderer>().sprite = sprites[i];
            oldIntegrity = integrity;
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
            Debug.Log("Attacco con: " + cursor.GetComponent<Cursor>().attackers);
            Destroy(cursor);
        }
        else
            select();
    }

    private void select()
    {
        level.infoBarScript.selected(this);
        Color transparentColor = new Color(color.r, color.g, color.b, 0.5f);
        GetComponent<Renderer>().material.color = transparentColor;
    }

    public void deselect()
    {
        GetComponent<Renderer>().material.color = color;
    }


    IEnumerator StartPressing()
    {
        yield return new WaitForSeconds(Costants.OBJ_TIME_TO_START_ATTACK);
        cursor = Instantiate(Resources.Load("Prefabs/Cursor", typeof(GameObject))) as GameObject;
        cursor.GetComponent<Cursor>().availableAttackers = level.availableTermites;
        cursor.GetComponent<Cursor>().setPosition(gameObject.transform.position);
        while (true)
        {
            if (!cursor.GetComponent<Cursor>().updateCursor())
                OnMouseUp();
            yield return new WaitForSeconds(Costants.OBJ_TIME_TO_ADD_ATTACKERS);
        }
    }

    public string getType()
    {
        return Utils.GetEnumDescription(type);
    }
}
