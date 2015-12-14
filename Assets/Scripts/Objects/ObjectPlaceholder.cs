using UnityEngine;
using System.Collections;

public class ObjectPlaceholder{
    public int roomNumber;
    public int z_index;
    public Vector3 coordinates;
    public string name;
    public GenericObject.Types type;
    public bool isHanging;
    public float strengthCoefficient;

    public ObjectPlaceholder(int roomNumber, int z_index, Vector3 coordinates, string name, GenericObject.Types type, float strengthCoefficient = 0.05f, bool isHanging = false)
    {
        this.roomNumber = roomNumber;
        this.z_index = z_index;
        this.coordinates = coordinates;
        this.name = name;
        this.type = type;
        this.isHanging = isHanging;
        this.strengthCoefficient = strengthCoefficient;
    }
}