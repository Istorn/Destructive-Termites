using UnityEngine;
using System.Collections;

public class Wizard : LiveObject {

	private string atkAnimStr = "isCastingASpell";
	private string walkAnimStr = "isWalking";

    protected override void Awake()
    {
        base.Awake();
        movementPath = new ConcurrentQueue<Graph.Node>();
		setMovementCoroutine();
		setAttackCoroutine();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/WizardAnimController"));
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
        attackCoroutine = attackColony(6); // can only cast a spell (=6)
	}
	
    protected override void move()
    {
        base.move(); // calls the father's move method prior to execute the rest of this method
    }

    void Start()
    {
        StartCoroutine(movementCoroutine);
        StartCoroutine(attackCoroutine);
		this.threatType = "Wizard";
    }

}
