using UnityEngine;
using System.Collections;

public class Boost
{

    public Booster.Types type;

    public Colony owner = null;
    public double activationTime = 0;
    public float timeDuration = 5;
    public GenericObject.Types extraEatableMaterial; 

    public void setType(Booster.Types type)
    {

        this.type = type;

        switch (this.type)
        {
            case Booster.Types.IronDenture:
                this.extraEatableMaterial = GenericObject.Types.Hard;
                break;
            case Booster.Types.Mushroom:
                this.extraEatableMaterial = GenericObject.Types.Live;
                break;
            default:
                break;
        }

    }
}
