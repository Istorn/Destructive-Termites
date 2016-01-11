using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LiveObject : GenericObject {

    protected Animator animator;
    protected bool isMoving = false;
    protected bool isAttacking = false;
    protected IEnumerator movementCoroutine = null;
    protected IEnumerator attackCoroutine = null;
	protected string threatType = null;
	protected Colony target;
    protected GenericObject targetObject = null;	
    protected const float alertLevelThreshold = 0.1F; // IS IN RANGE 0-1.	
    protected float alertPercentage = 0f;	
    public int actualNodeNumber = 0;
    protected ConcurrentQueue<Graph.Node> movementPath;
	
    protected override void Awake()
    {
        base.Awake();
        this.model = Model.Live;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_LIVE_OBJECTS);
        animator = gameObject.AddComponent<Animator>();
    }

    protected virtual void move(){}
    protected virtual void setMovementCoroutine(){}
    protected virtual void setAttackCoroutine(){}
	
	protected IEnumerator movement(string AtkAnimStr, string walkAnimStr, float objectWaitingTime, float objectSpeed){
        while (true)
        {
            bool move = true;
            if (movementPath.Count < 2)
            {
                if (isAttacking)
                {
                    animator.SetBool(AtkAnimStr, true);
                    if (targetObject.getAttacker())
                    {
                        targetObject.getAttacker().attack();
                        move = false;
                        yield return new WaitForSeconds(objectWaitingTime);
                    }
                    else
                    {
                        animator.SetBool(walkAnimStr, true);
                        animator.SetBool(AtkAnimStr, false);
                        isAttacking = false;
                    }
                }
                if (move)
                {
                    movementPath.Clear();
                    animator.SetBool(walkAnimStr, false);
                    int endNode = findDestination();
                    List<Graph.Node> path = GameManager.getCurrentLevel().getGraphLiveObjects().getPath(actualNodeNumber, endNode);
                    foreach (Graph.Node n in path)
                        movementPath.Enqueue(n);
                    yield return new WaitForSeconds(objectWaitingTime);
                    animator.SetBool(walkAnimStr, true);
                }
            }
            if (move)
            {
                StartCoroutine(stepMovement(objectSpeed));
                yield return new WaitForSeconds(objectSpeed);
            }
        }
    }
	
	private int findDestination(){
        int endNode = 0;
        do
        {
            endNode = Random.Range(0, GameManager.getCurrentLevel().getGraphLiveObjects().nodes.Count);
        }
        while ((endNode == actualNodeNumber) || (GameManager.getCurrentLevel().getGraphLiveObjects().findNode(endNode).type.Equals(Graph.Node.Type.Generic)));
        return endNode;
    }
	
	IEnumerator stepMovement(float objectSpeed){
        Graph.Node start = movementPath.Dequeue();
        Graph.Node end = movementPath.Peek();
        actualNodeNumber = end.number;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = start.getZIndex(end);
        int sign = System.Math.Sign(end.coordinates.x - start.coordinates.x) >= 0? 1: -1;
        transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x) * sign, transform.localScale.y, transform.localScale.z);
        yield return StartCoroutine(MoveObject(transform, start, end, objectSpeed));
    }
	
	IEnumerator MoveObject(Transform thisTransform, Graph.Node start, Graph.Node end, float time){
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(start.coordinates, end.coordinates, i);
            yield return null;
        }
    }
	
    protected IEnumerator attackColony()
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
		
	private void setTarget(Colony col){
		this.target = col;
	}
	
	private float getAlertLevel(){
		// int destroyable = nbDestroyableItems;
		// return (destroyable /(destroyable+nbDestroyedItems) ); // 0 if house destroyed, 1 if house new
		
		int destroyable = 5;
		return (destroyable /(destroyable+1) ); // 0 if house destroyed, 1 if house new
	}
		
	public Colony getTarget(){
		return target;
	}
	
	public string getThreatType(){
		return this.threatType;
	}
}
