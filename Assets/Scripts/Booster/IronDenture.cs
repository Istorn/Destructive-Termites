using UnityEngine;
using System.Collections;

public class IronDenture : Booster {

    public IronDenture() : base()
    {
        model = Model.IronDenture;
        timeDuration = 30;
        extraEatableMaterials.Add(GenericObject.Model.Hard);
    }
}
