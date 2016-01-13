using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ObjectSelector : MonoBehaviour {

    private StartAttackCursor cursor = null;
    private IEnumerator selectionCoroutine;
    private GenericObject obj = null;

    void Awake()
    {
        selectionCoroutine = StartPressing();
    }

    public void setObj(GenericObject obj)
    {
        this.obj = obj;
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            if (GameManager.getLevelGUI().isGameAreaClicked(Input.mousePosition))
            {
                GameManager.getMainGamera().stopMoving();
                GameManager.setIsSelectingObject(true);
                StopCoroutine(selectionCoroutine);
                selectionCoroutine = StartPressing();
                StartCoroutine(selectionCoroutine);
            }
    }
    
    IEnumerator StartPressing()
    {
        GameManager.getLevelGUI().objectSelected(obj);
        if (GameManager.getIsInitialPhase())
        {
            yield return new WaitForSeconds(Costants.OBJ_TIME_TO_START_ATTACK);
            if ((GameManager.getCurrentLevel().getAvailableTermites() > 0))
            {
                cursor = GameManager.getLevelGUI().instantiateStartAttackCursor();
                cursor.availableAttackers = GameManager.getCurrentLevel().getAvailableTermites();
                cursor.setPosition(gameObject.transform.position);
                while (true)
                {
                    if (!cursor.GetComponent<StartAttackCursor>().updateCursor())
                        OnMouseUp();
                    yield return new WaitForSeconds(Costants.OBJ_TIME_TO_ADD_500_ATTACKERS * GameManager.getCurrentLevel().getAvailableTermites() / 500);
                }
            }
        }
    }

    void OnMouseUp()
    {
        StopCoroutine(selectionCoroutine);
        if (cursor)
        {
            int attackers = cursor.GetComponent<StartAttackCursor>().attackers;
            Destroy(cursor.gameObject);

            if (obj.getAttacker() == null)
            {
                Colony colony = GameManager.getLevelGUI().instantiateColony();
                colony.setTarget(obj);
            }
            obj.getAttacker().addTermites(attackers);
            GameManager.getCurrentLevel().decreaseAvailableTermites(attackers);
        }
        GameManager.setIsSelectingObject(false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (obj is EatableObject)
        {
            float distance = GetComponent<SpriteRenderer>().sortingOrder - other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            if (distance > 0 && distance <= 5)
                if (((EatableObject)obj).getIsOnSomething())
                    ((EatableObject)obj).enablePhysics();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (obj is EatableObject)
        {
            if (!collision.gameObject.tag.Equals(Costants.TAG_BACKGROUND))
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
            }
        }
    }
}
