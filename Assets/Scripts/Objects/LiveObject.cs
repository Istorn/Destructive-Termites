﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class LiveObject : GenericObject {

    public enum Model {
        [Category("HUMAN")]
        Human = 0,
        [Category("FROG")]
        Frog = 1,
        [Category("WIZARD")]
        Wizard = 2
    }

    protected Animator animator;
    protected bool isMoving = false;
    protected bool isAttacking = false;
    public enum atkType {Spray = 1, Gas = 2, Bomb = 3, Gun = 4, Eat = 5, Spell = 6};
    protected IEnumerator movementCoroutine = null;
    protected IEnumerator attackCoroutine = null;
	protected string threatType = null;
	protected Colony target;
    protected GenericObject targetObject = null;	
    protected const float alertLevelThreshold = 0.1F; // IS IN RANGE 0-1.	
    protected float alertPercentage = 0f;	
    public int actualNodeNumber = 0;
    protected ConcurrentQueue<Graph.Node> movementPath;
	
    protected override void Awake(){
        base.Awake();
        this.model = GenericObject.Model.Live;
        gameObject.layer = LayerMask.NameToLayer(Costants.LAYER_LIVE_OBJECTS);
		animator = obj.AddComponent<Animator>();
		// obj.AddComponent<BoxCollider2D>();
    }

    protected virtual void move(){}
    protected virtual void setMovementCoroutine(){}
    protected virtual void setAttackCoroutine(){}
	protected virtual void setBoxCollider(){}
	
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
        obj.GetComponent<SpriteRenderer>().sortingOrder = start.getZIndex(end);
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
	
    protected IEnumerator attackColony(int atkType){
        while (true)
        { 
            if (GameManager.getCurrentLevel().alertObjectsQueue.Count > 0 && !isAttacking)
            {
                isAttacking = true;
				switch (atkType)
				{
					case 1:
						Debug.Log("Spray attack");
						break;
					case 2:
						Debug.Log("Gas attack");
						break;
					case 3:
						Debug.Log("Bomb attack");
						break;
					case 4:
						Debug.Log("Gun attack");
						break;
					case 5:
						Debug.Log("frog eating");
						break;
					case 6:
						Debug.Log("it's a spell");
						break;
					default:
						Debug.Log("Bug in LiveObject, not an attack");
						break;
				}
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

    public override void setPosition(Vector3 coordinates, int z_index){
        gameObject.transform.position = new Vector3(coordinates.x, coordinates.y, -(float)z_index / 10);
        obj.GetComponent<SpriteRenderer>().sortingOrder = z_index;
    }

	
    public override void setName(string objectName, string spriteName)
    {
       /* _name = objectName;
        objSprites = Resources.LoadAll<Sprite>("Levels/" + GameManager.getCurrentLevel().getLevelNumber() + "/Objects/" + spriteName);
        updateObjectSprite();

        selector.GetComponent<SpriteRenderer>().sprite = objSprites[0];
        selector.AddComponent<PolygonCollider2D>();

        GetComponent<RectTransform>().sizeDelta = selector.GetComponent<SpriteRenderer>().bounds.size;
        dust.GetComponent<RectTransform>().sizeDelta = dust.GetComponent<SpriteRenderer>().bounds.size;
        */
        /*dust.GetComponent<RectTransform>().offsetMin = new Vector2(-0.6f, 0);
        dust.GetComponent<RectTransform>().offsetMax = new Vector2(0.6f, 0.6f);*/

        /*  BoxCollider2D selectionCollider = gameObject.AddComponent<BoxCollider2D>();
          selectionCollider.tag = Costants.TAG_OBJ_COLLIDER_SELECTION;

          float min = +100000;
          foreach (Vector2 point in physicsCollider.GetPath(0))
              if (point.y < min)
                  min = point.y;

          selectionCollider.offset = new Vector2(0, (selectionCollider.size.y/2 - Math.Abs(min)) / 2);
          selectionCollider.size = new Vector2(selectionCollider.size.x, selectionCollider.size.y - (selectionCollider.size.y / 2 - Math.Abs(min)));*/
    }
}
