using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Human : LiveObject {

	private string sprayAtkAnimStr = "isSprayAttacking";
	// private string gasAtkAnimStr = "isGasAttacking";
	// private string bombAtkAnimStr = "isBombAttacking";
	// private string gunAtkAnimStr = "isGunAttacking";
	private string walkAnimStr = "isWalking";
	private string atkAnimStr;

    protected override void Awake()
    {
        base.Awake();
        movementPath = new ConcurrentQueue<Graph.Node>();
		this.atkAnimStr = sprayAtkAnimStr; // defaut attack is spray
		setMovementCoroutine();
		setAttackCoroutine();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/OliAnimatorController"));
    }

	protected override void setMovementCoroutine(){
        movementCoroutine = movement(atkAnimStr,walkAnimStr,Costants.HUMAN_WAIT_TIME,Costants.HUMAN_SPEED);
	}
	
	protected override void setAttackCoroutine(){		
        attackCoroutine = attackColony();
	}
	
    protected override void move()
    {
        base.move(); // calls the father's move method prior to execute the rest of this method
    }

    void Start()
    {
        StartCoroutine(movementCoroutine);
        StartCoroutine(attackCoroutine);
		this.threatType = "Human";
    }
}
