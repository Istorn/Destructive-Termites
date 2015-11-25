using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    private Animator animator;

    private int actualNodeNumber;

    private bool isMoving = false;

    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Persone");
        animator = GetComponent<Animator>();
        StartCoroutine(YourFunctionName());
    }

    private void updatePosition()
    {
        Vector2 coordinates = Graph.findNode(actualNodeNumber).coordinates;
        transform.position = coordinates;
    }

    IEnumerator YourFunctionName()
    {
        while (true)
        {
            if (!isMoving)
            {
                StartCoroutine(move());
            }
            yield return new WaitForSeconds(3);
        }
    }



    IEnumerator move()
    {
        isMoving = true;
        animator.SetBool("isWalking", true);
        int endNode = 0;
        do
        {
            endNode = Random.Range(0, 5);
        }
        while (endNode == actualNodeNumber);
        //Graph graph = Costanti.generateGraph();
        List<Graph.Node> path = Graph.getPath(actualNodeNumber, endNode);
        //path.AddRange(graph.getPath(2, 4));

        while (path.Count > 1)
        {
            Graph.Node start = path[0];
            Graph.Node end = path[1];
            //Debug.Log(start.number + "(" + start.coordinates + ")->" + end.number + "(" + end.coordinates + ")");
            int sign = System.Math.Sign(end.coordinates.x - start.coordinates.x);
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x) * sign, transform.localScale.y, transform.localScale.z);
            path.RemoveAt(0);
            yield return StartCoroutine(MoveObject(transform, start, end, LevelData.HUMAN_SPEED)); 
        }
        actualNodeNumber = endNode;
        animator.SetBool("isWalking", false);
        isMoving = false;
    }

    IEnumerator MoveObject(Transform thisTransform, Graph.Node start, Graph.Node end, float time)
    {
        //ann.Play("Walking");
        //if (end.type == 1)
        animator.SetBool("isOnStairs", (end.type == 1) && (start.type == 1));
       // else
        //    animator.SetBool("isOnStairs", end.type == 1);
        //an.SetBool("isOnStairs", end.type == 1);
        //Debug.Log(an.GetBool("isOnStairs").ToString());
        //an.enabled = false;
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(start.coordinates, end.coordinates, i);
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "LiveObject")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public void setActualNodeNumber(int actualNodeNumber)
    {
        this.actualNodeNumber = actualNodeNumber;
        updatePosition();  
    }
}
