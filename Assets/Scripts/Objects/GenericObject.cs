using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericObject : MonoBehaviour {

    public enum Types { Soft, Hard, Live}

    protected Types type;

    public int roomNumber;

    protected float strenghtCoefficient = 0.2f;

    protected float integrity = 100.0f;
    protected float oldIntegrity = 100.0f;

    protected Sprite[] sprites;

    protected Level level = null;

    protected GameObject cursor = null;

    protected int avail = 500;
    protected int counter = 0;

    protected GameObject infoBar;

    protected IEnumerator selectionCoroutine;

    protected List<Colony> attackers;

    public float getIntegrity()
    {
        return this.integrity;
    }
    protected virtual void Awake()
    {
        attackers = new List<Colony>();
        selectionCoroutine = StartPressing();
    }

    public void setLevel(Level level)
    {
        this.level = level;
    }

    public void setPosition(int roomNumber, Vector2 coordinates, int z_index)
    {
        this.roomNumber = roomNumber;
        gameObject.transform.position = coordinates;
        GetComponent<SpriteRenderer>().sortingOrder = z_index;
    }

    public virtual void setObjectName(string objectName)
    {
        sprites = Resources.LoadAll<Sprite>("SpriteSheets/Objects/" + objectName);
        GetComponent<SpriteRenderer>().sprite = sprites[0];
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
            Debug.Log("SELEZIONE INFO");
        
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
            yield return new WaitForSeconds(Costants.OBJ_TTIME_TO_ADD_ATTACKERS);
        }
    }

}
