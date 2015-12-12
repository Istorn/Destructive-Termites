﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Room{

    public int number = 0;
    public List<GenericObject> objects;

    public Room(int number)
    {
        this.number = number;
        objects = new List<GenericObject>();
    }

    public void addObject(GenericObject gameObject)
    {
        objects.Add(gameObject);
    }

    public GenericObject getOtherObject(GenericObject obj)
    {
        IEnumerable<GenericObject> others = from o in objects
                                            let distance = Vector2.Distance(obj.gameObject.transform.position, o.gameObject.transform.position)
                                            where o.id != obj.id
                                            orderby distance
                                            select (GenericObject)o;
        if (others.Count() == 0)
            return null;
        else
            return others.First();
    }

    public GenericObject getObject(Vector2 position)
    {
        IEnumerable<GenericObject> others = from o in objects
                                            let distance = Vector2.Distance(position, o.gameObject.transform.position)
                                            orderby distance
                                            select (GenericObject)o;
        if (others.Count() == 0)
            return null;
        else
            return others.First();
    }

    public void removeObject(GenericObject obj)
    {
        Debug.Log("PRIMA: " + objects.Count);
        int i = 0;
        for (i = 0; i < objects.Count; i++)
            if (objects[i].id == obj.id)
                break;
        objects.RemoveAt(i);
        Debug.Log("DOPO:" + objects.Count);
    }
}
