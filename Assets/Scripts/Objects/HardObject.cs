using UnityEngine;
using System.Collections;

public class HardObject : GenericObject {

    void Awake()
    {
        this.type = Types.Hard;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
    }
}
