using UnityEngine;
using System.Collections;

public class ObjectHard : Object {

    void Awake()
    {
        this.type = Types.Hard;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
    }
}
