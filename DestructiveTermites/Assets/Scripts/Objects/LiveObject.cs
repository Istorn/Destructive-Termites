﻿using UnityEngine;
using System.Collections;

public class LiveObject : GenericObject {

    protected Animator animator;

    protected bool isMoving = false;

    void Awake()
    {
        this.type = Types.Live;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_LIVE_OBJECTS);
        animator = gameObject.AddComponent<Animator>();
    }

    protected virtual void move()
    {
    }
}
