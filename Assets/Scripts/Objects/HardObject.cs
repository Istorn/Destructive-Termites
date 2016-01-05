using UnityEngine;
using System.Collections;

public class HardObject : GenericObject {

    protected override void Awake()
    {
        base.Awake();
        this.model = Model.Hard;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
    }
}
