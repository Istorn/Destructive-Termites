using UnityEngine;
using System.Collections;

public class ObjectPlaceholder{
    private int roomNumber;
    private int z_index;
    private Vector3 coordinates;
    private string pathName;
    private string name;
    private GenericObject.Model model;
    private bool isOnSomething;
    private bool isHanging;
    private bool isHorizontallyFlipped;
    private float strengthCoefficient;
    

    public ObjectPlaceholder(int nRoom, int z_index, Vector3 coord, string pathName, string name, GenericObject.Model model, float sCoeff = 0.05f, bool isOnSomething = false, bool isHanging = false, bool isHFlipped = false)
    {
        this.roomNumber = nRoom;
        this.z_index = z_index;
        this.coordinates = coord;
        this.pathName = pathName;
        this.name = name;
        this.model = model;
        this.isHanging = isHanging;
        this.isOnSomething = isOnSomething;
        this.strengthCoefficient = sCoeff;
        this.isHorizontallyFlipped = isHFlipped;
    }

    public int getRoomNumber()
    {
        return roomNumber;
    }

    public int getZIndex()
    {
        return z_index;
    }

    public Vector3 getCoordinates()
    {
        return coordinates;
    }

    public string getName()
    {
        return name;
    }

    public string getPathName()
    {
        return pathName;
    }
    
    public GenericObject.Model getModel()
    {
        return model;
    }
    
    public float getStrengthCoefficient()
    {
        return strengthCoefficient;
    }

    public bool getIsOnSomething()
    {
        return isOnSomething;
    }

    public bool getIsHanging()
    {
        return isHanging;
    }

    public bool getIsHorizontallyFlipped()
    {
        return isHorizontallyFlipped;
    }
}