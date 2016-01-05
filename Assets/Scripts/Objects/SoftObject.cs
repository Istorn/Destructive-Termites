using UnityEngine;
using System.Collections;

public class SoftObject: GenericObject {

    protected override void Awake()
    {
        base.Awake();
        this.model = Model.Soft;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
    }
}
