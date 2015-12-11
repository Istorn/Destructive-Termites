using UnityEngine;
using System.Collections;

public class BoosterCounter {

    private int count = 1;
    private Booster.Types type;

    public BoosterCounter(Booster.Types type)
    {
        this.type = type;
    }

    public int getCount()
    {
        return count;
    }

    public void collectOne()
    {
        count++;
    }

    public bool useOne()
    {
        count--;
        return (count > 0);
    }
}
