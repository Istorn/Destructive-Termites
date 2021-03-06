﻿using UnityEngine;
using System.Collections;

public class Frog : LiveObject {

	private string atkAnimStr = "isEating";
	private string walkAnimStr = "isJumping";

    protected override void Awake()
    {
        base.Awake();
        movementPath = new ConcurrentQueue<Graph.Node>();
		setMovementCoroutine();
		setAttackCoroutine();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/FrogAnimController"));
	}

	protected override void setMovementCoroutine(){
        movementCoroutine = movement(atkAnimStr,walkAnimStr,Costants.HUMAN_WAIT_TIME,Costants.HUMAN_SPEED);
	}
	
	protected override void setAttackCoroutine(){		
        attackCoroutine = attackColony(5); // can only eat termites (=5)
	}
	
	protected override void setBoxCollider(){
		BoxCollider2D b = GetComponent<BoxCollider2D>();
		if(b != null){
			b.size = new Vector2(1f, 0.7f);
			b.offset = new Vector2(0.18f, -0.86f);
		}
	}
	
    protected override void move()
    {
        base.move(); // calls the father's move method prior to execute the rest of this method
    }

    void Start()
    {
        StartCoroutine(movementCoroutine);
        StartCoroutine(attackCoroutine);
		this.threatType = "Frog";
    }

}
