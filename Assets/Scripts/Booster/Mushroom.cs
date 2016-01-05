using UnityEngine;
using System.Collections;

public class Mushroom : Booster {

    public Mushroom() : base()
    {
        model = Model.Mushroom;
        timeDuration = 30;
        extraEatableMaterials.Add(GenericObject.Model.Live);
    }
}
