using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class EatableObject : GenericObject {

    private bool isHanging = false;
    private bool isOnSomething = false;

    private float strengthCoefficient = 0.01f;

    private Sprite[] objSprites;
    private int currentObjSprite = -1;

    protected Sprite[] dustSprites;
    private int currentDustSprite = -2;

    protected GameObject selector = null;
    protected GameObject dust = null;

    protected override void Awake()
    {
        base.Awake();

        selector = transform.Find("Selector").gameObject;
        selector.GetComponent<EatableObjectSelector>().setObj(this);

        obj.GetComponent<PolygonCollider2D>().tag = Costants.TAG_OBJ_COLLIDER_PHYSICS;

        dust = transform.Find("Dust").gameObject;
        defaultColor = new Color(1, 1, 1, 1);
        actualColor = defaultColor;
        //actualColor = obj.GetComponent<SpriteRenderer>().color;
    }

    public override void setPosition(Vector3 coordinates, int z_index)
    {
        gameObject.transform.position = new Vector3(coordinates.x, coordinates.y, -(float)z_index/10);
        selector.GetComponent<SpriteRenderer>().sortingOrder = z_index;
        obj.GetComponent<SpriteRenderer>().sortingOrder = z_index;
        dust.GetComponent<SpriteRenderer>().sortingOrder = z_index;
        
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

    public override void setName(string objectName, string spriteName)
    {
        _name = objectName;
        objSprites = Resources.LoadAll<Sprite>("Levels/" + GameManager.getCurrentLevel().getLevelNumber() + "/Objects/" + spriteName);
        updateObjectSprite();

        selector.GetComponent<SpriteRenderer>().sprite = objSprites[0];
        selector.AddComponent<PolygonCollider2D>();

        GetComponent<RectTransform>().sizeDelta = selector.GetComponent<SpriteRenderer>().bounds.size;
        dust.GetComponent<RectTransform>().sizeDelta = dust.GetComponent<SpriteRenderer>().bounds.size;
        
        /*dust.GetComponent<RectTransform>().offsetMin = new Vector2(-0.6f, 0);
        dust.GetComponent<RectTransform>().offsetMax = new Vector2(0.6f, 0.6f);*/

      /*  BoxCollider2D selectionCollider = gameObject.AddComponent<BoxCollider2D>();
        selectionCollider.tag = Costants.TAG_OBJ_COLLIDER_SELECTION;

        float min = +100000;
        foreach (Vector2 point in physicsCollider.GetPath(0))
            if (point.y < min)
                min = point.y;

        selectionCollider.offset = new Vector2(0, (selectionCollider.size.y/2 - Math.Abs(min)) / 2);
        selectionCollider.size = new Vector2(selectionCollider.size.x, selectionCollider.size.y - (selectionCollider.size.y / 2 - Math.Abs(min)));*/
    }
    
    void FixedUpdate()
    {
        selector.transform.position = obj.transform.position;
    }

    private void updateObjectSprite()
    {
        PolygonCollider2D physicsCollider = obj.GetComponent<PolygonCollider2D>();
        int i = (int)((100 - integrity) * (objSprites.Length - 1) / 100);
        if (i >= 0 && i < objSprites.Length && i != currentObjSprite)
        {
            currentObjSprite = i;
            obj.GetComponent<SpriteRenderer>().sprite = objSprites[currentObjSprite];
            currentDustSprite++;
            if (currentDustSprite >= 0 && currentDustSprite < dustSprites.Length)
                dust.GetComponent<SpriteRenderer>().sprite = dustSprites[currentDustSprite];

            PolygonCollider2D tempCollider = obj.gameObject.AddComponent<PolygonCollider2D>();
            physicsCollider.pathCount = tempCollider.pathCount;
            for (int p = 0; p < tempCollider.pathCount; p++ )
                physicsCollider.SetPath(p, tempCollider.GetPath(p));
            Destroy(tempCollider);
        }
        
    }

    public void enablePhysics()
    {
        isHanging = false;
        isOnSomething = false;
        Vector3 rotation = Vector3.forward * UnityEngine.Random.Range(Costants.OBJ_PHYSICS_ROTATION_BOUND_LEFT, Costants.OBJ_PHYSICS_ROTATION_BOUND_RIGHT);
        obj.transform.Rotate(rotation);
        selector.transform.Rotate(rotation);
        obj.GetComponent<PolygonCollider2D>().isTrigger = false;
        obj.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public override bool attack(int numberOfAttackers)
    {
        base.attack(numberOfAttackers);

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
           // if (UnityEngine.Random.Range(0, 11) < 3)
			//    dropABooster();
            return false;
        }
    }

    public bool getIsOnSomething()
    {
        return isOnSomething;
    }
}
