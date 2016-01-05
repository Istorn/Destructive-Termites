using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Human : LiveObject {

    private float alertPercentage = 0f;
    public int actualNodeNumber = 0;
    private bool isAttacking = false;

    private IEnumerator movementCoroutine = null;
    private IEnumerator attackCoroutine = null;

    private GenericObject targetObject = null;

    private ConcurrentQueue<Graph.Node> movementPath;
    protected override void Awake()
    {
        base.Awake();
        movementPath = new ConcurrentQueue<Graph.Node>();
        movementCoroutine = movement();
        attackCoroutine = attackColony();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/OliAnimatorController"));
    }

    protected override void move()
    {
        base.move();
    }


    void Start()
    {
        StartCoroutine(movementCoroutine);
        StartCoroutine(attackCoroutine);
    }

    IEnumerator movement()
    {
        while (true)
        {
            bool move = true;
            if (movementPath.Count < 2)
            {
                if (isAttacking)
                {
                    animator.SetBool("isSprayAttacking", true);
                    if (targetObject.getAttacker())
                    {
                        targetObject.getAttacker().attack();
                        move = false;
                        yield return new WaitForSeconds(Costants.HUMAN_WAIT_TIME);
                    }
                    else
                    {
                        animator.SetBool("isWalking", true);
                        animator.SetBool("isSprayAttacking", false);
                        isAttacking = false;
                    }
                        
                }
                if (move)
                {
                    movementPath.Clear();
                    animator.SetBool("isWalking", false);
                    int endNode = findDestination();
                    List<Graph.Node> path = GameManager.getCurrentLevel().getGraphLiveObjects().getPath(actualNodeNumber, endNode);
                    foreach (Graph.Node n in path)
                        movementPath.Enqueue(n);
                    yield return new WaitForSeconds(Costants.HUMAN_WAIT_TIME);
                    animator.SetBool("isWalking", true);
                }
            }
            if (move)
            {
                StartCoroutine(stepMovement());
                yield return new WaitForSeconds(Costants.HUMAN_SPEED);
            }

        }
    }

    IEnumerator stepMovement()
    {
        Graph.Node start = movementPath.Dequeue();
        Graph.Node end = movementPath.Peek();
        actualNodeNumber = end.number;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = start.getZIndex(end);
        int sign = System.Math.Sign(end.coordinates.x - start.coordinates.x) >= 0? 1: -1;
        transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x) * sign, transform.localScale.y, transform.localScale.z);
        yield return StartCoroutine(MoveObject(transform, start, end, Costants.HUMAN_SPEED));
    }

    IEnumerator MoveObject(Transform thisTransform, Graph.Node start, Graph.Node end, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(start.coordinates, end.coordinates, i);
            yield return null;
        }
    }

    private int findDestination()
    {
        int endNode = 0;
        do
        {
            endNode = Random.Range(0, GameManager.getCurrentLevel().getGraphLiveObjects().nodes.Count);
        }
        while ((endNode == actualNodeNumber) || (GameManager.getCurrentLevel().getGraphLiveObjects().findNode(endNode).type.Equals(Graph.Node.Type.Generic)));
        return endNode;
    }

    private IEnumerator attackColony()
    {
        while (true)
        { 
            if (GameManager.getCurrentLevel().alertObjectsQueue.Count > 0 && !isAttacking)
            {
                isAttacking = true;
                StopCoroutine(movementCoroutine);
                movementCoroutine = movement();
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
