using UnityEngine;
using System.Collections;

public class HumanPlaceholder
{
    public int roomNumber;
    public bool isMale;
    public Vector2 coordinates;

    public HumanPlaceholder(int roomNumber, bool isMale, Vector2 coordinates)
    {
        this.roomNumber = roomNumber;
        this.isMale = isMale;
        this.coordinates = coordinates;
    }
}