using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room{

    public int number = 0;
    public List<GameObject> objects;

    public Room(int number)
    {
        this.number = number;
        objects = new List<GameObject>();
    }

    public void addObject(GameObject gameObject)
    {
        objects.Add(gameObject);
    }

	void Update () {
	
	}
}
