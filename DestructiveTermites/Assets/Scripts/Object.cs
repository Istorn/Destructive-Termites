﻿using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

    public enum Types { Soft, Hard, Live}

    protected Types type;

    protected int roomNumber;

    protected float strenghtCoefficient = 0.2f;

    protected float integrity = 100.0f;
    protected float oldIntegrity = 100.0f;

    protected Sprite[] sprites;

    public void setPosition(int roomNumber, Vector2 coordinates)
    {
        this.roomNumber = roomNumber;
        gameObject.transform.position = coordinates; 
    }

    public virtual void setObjectName(string objectName)
    {
        sprites = Resources.LoadAll<Sprite>(objectName);
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
        attack(100);
    }
}
