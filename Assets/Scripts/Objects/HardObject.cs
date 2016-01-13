using UnityEngine;
using System.Collections;

public class HardObject : EatableObject {

    protected override void Awake()
    {
        base.Awake();
        this.model = Model.Hard;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
        //selector.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);
        obj.layer = LayerMask.NameToLayer(Costants.LAYER_SOFT_HARD_OBJECTS);

        dustSprites = Resources.LoadAll<Sprite>("Levels/Hard dust");
    }
}
