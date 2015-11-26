using UnityEngine;
using System.Collections;

public class ObjectSoft: Object {

    void Awake()
    {
        this.type = Types.Soft;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
    }
}
