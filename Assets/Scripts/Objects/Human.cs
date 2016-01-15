using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Human : LiveObject {

	private string sprayAtkAnimStr = "isSprayAttacking";
	private string gasAtkAnimStr = "isGasAttacking";
	private string bombAtkAnimStr = "isBombAttacking";
	private string gunAtkAnimStr = "isGunAttacking";
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
		BoxCollider2D b = GetComponent<BoxCollider2D>();
		if(b != null){
			b.size = new Vector2(0.35f, 1.5f);
			b.offset = new Vector2(-0.1f, 0.2f);
		}
	}

	protected override void setMovementCoroutine(){
        movementCoroutine = movement(atkAnimStr,walkAnimStr,Costants.HUMAN_WAIT_TIME,Costants.HUMAN_SPEED);
	}
	
	protected override void setAttackCoroutine(){
		int atk = Random.Range(2,5); // random integer number between min [inclusive] and max [exclusive] 
		switch (atk)
		{
			case 1:
				this.atkAnimStr = sprayAtkAnimStr;
				break;
			case 2:
				this.atkAnimStr = gasAtkAnimStr;
				break;
			case 3:
				this.atkAnimStr = bombAtkAnimStr;
				break;
			case 4:
				this.atkAnimStr = gunAtkAnimStr;
				break;
			default:
				Debug.Log("Bug in Human, not a Human attack");
				break;
		}
        attackCoroutine = attackColony(atk);
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
