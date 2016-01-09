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

    private IEnumerator movementCoroutine = null;
    private IEnumerator attackCoroutine = null;

    protected override void Awake()
    {
        base.Awake();
        movementPath = new ConcurrentQueue<Graph.Node>();
		this.atkAnimStr = sprayAtkAnimStr; // defaut attack is spray
		setMovementCoroutine();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/OliAnimatorController"));
    }

	protected void setMovementCoroutine(){
        movementCoroutine = movement(atkAnimStr,walkAnimStr,Costants.HUMAN_WAIT_TIME,Costants.HUMAN_SPEED);
	}
	
	protected void setAttackCoroutine(){		
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
    }

    private IEnumerator attackColony()
    {
        while (true)
        { 
            if (GameManager.getCurrentLevel().alertObjectsQueue.Count > 0 && !isAttacking)
            {
                isAttacking = true;
                StopCoroutine(movementCoroutine);//pointer to movementCoroutine goes null
				setMovementCoroutine();
                targetObject = (GenericObject)GameManager.getCurrentLevel().alertObjectsQueue.Dequeue();
                int target = GameManager.getCurrentLevel().getGraphLiveObjects().findNearestNode(targetObject.getRoom().number, targetObject.gameObject.transform.position);
                List<Graph.Node> path = GameManager.getCurrentLevel().getGraphLiveObjects().getPath(actualNodeNumber, target);
                path.RemoveAt(path.Count - 1);
                movementPath.Clear();
                foreach (Graph.Node n in path)
                    movementPath.Enqueue(n);
                StartCoroutine(movementCoroutine);
            }
            yield return new WaitForSeconds(Costants.COLONY_ATTACK_FREQUENCY);
        }
    }
}
