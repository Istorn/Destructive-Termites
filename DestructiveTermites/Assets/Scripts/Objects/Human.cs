using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Human : LiveObject {

    private float alertPercentage = 0f;
    private float WAIT_TIME = 3;
    private int actualNodeNumber = 11;

    public override void setObjectName(string objectName)
    {
        base.setObjectName(objectName);
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/HumanAnimatorController"));
    }

    protected override void move()
    {
        base.move();
    }


    void Start()
    {
        StartCoroutine(YourFunctionName());
    }

    IEnumerator YourFunctionName()
    {
        while (alertPercentage == 0)
        {
            if (!isMoving)
                StartCoroutine(movement());
            yield return new WaitForSeconds(WAIT_TIME);
        }
    }

    IEnumerator movement()
    {
        isMoving = true;
        animator.SetBool("isWalking", true);
        int endNode = 0;
        do
        {
            endNode = Random.Range(0, level.graphLiveObjects.nodes.Count);
        }
        while ((endNode == actualNodeNumber) || (level.graphLiveObjects.findNode(endNode).type.Equals(Graph.Node.Type.Generic)));

        List<Graph.Node> path = level.graphLiveObjects.getPath(actualNodeNumber, endNode);

        while (path.Count > 1)
        {
            Graph.Node start = path[0];
            Graph.Node end = path[1];

            gameObject.GetComponent<SpriteRenderer>().sortingOrder = start.getZIndex(end);

            //Debug.Log(start.number + "(" + start.coordinates + ")->" + end.number + "(" + end.coordinates + ")");
            int sign = System.Math.Sign(end.coordinates.x - start.coordinates.x);
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x) * sign, transform.localScale.y, transform.localScale.z);
            path.RemoveAt(0);
            yield return StartCoroutine(MoveObject(transform, start, end, Costants.HUMAN_SPEED));
        }
        actualNodeNumber = endNode;
        animator.SetBool("isWalking", false);
        isMoving = false;
    }

    IEnumerator MoveObject(Transform thisTransform, Graph.Node start, Graph.Node end, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(start.coordinates, end.coordinates, i);
            yield return null;
        }
    }
}
