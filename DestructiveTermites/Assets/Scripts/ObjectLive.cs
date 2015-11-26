using UnityEngine;
using System.Collections;

public class ObjectLive : Object {

    private Animator animator;

    void Awake()
    {
        this.type = Types.Live;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_LIVE_OBJECTS);
        animator = gameObject.AddComponent<Animator>();
    }

    public override void setObjectName(string objectName)
    {
        Debug.Log("EREDITATO");
        base.setObjectName(objectName);
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/HumanAnimatorController"));
    }
}
