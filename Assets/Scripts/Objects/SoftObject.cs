using UnityEngine;
using System.Collections;

public class SoftObject: GenericObject {

    protected override void Awake()
    {
        base.Awake();
        this.type = Types.Soft;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
    }
}
