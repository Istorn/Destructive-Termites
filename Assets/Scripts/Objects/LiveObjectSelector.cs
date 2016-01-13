using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LiveObjectSelector : MonoBehaviour {

    private IEnumerator selectionCoroutine;
    private GenericObject obj = null;

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
                GameManager.getLevelGUI().objectSelected(obj);
            }
    }
    }
