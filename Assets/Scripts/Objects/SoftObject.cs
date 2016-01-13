using UnityEngine;
using System.Collections;

public class SoftObject: EatableObject {

    protected override void Awake()
    {
        base.Awake();
        this.model = Model.Soft;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
        //selector.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
        obj.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);

        dustSprites = Resources.LoadAll<Sprite>("Levels/Soft dust");
    }
}
