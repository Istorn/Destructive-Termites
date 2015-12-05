using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    private Sprite[] sprites;
    private int i = 0;
    public int attackers = 0;
    public int availableAttackers = 0;
    private bool keepUdating = true;

	// Use this for initialization
	void Awake () {
        sprites = sprites = Resources.LoadAll<Sprite>("SpriteSheets/GUI/Cursor");
	}

    public void setPosition(Vector2 position)
    {
        transform.position = position;
    }

    public bool updateCursor()
    {
        attackers = (i + 1) * availableAttackers / sprites.Length;
        if (i + 1 < sprites.Length)
        {
            i++;
            GetComponent<SpriteRenderer>().sprite = sprites[i];
            return true;
        }
        else
            return false;
    }

    void OnMouseDown()
    {
        StartCoroutine(StartPressing());
    }

    void OnMouseUp()
    {
        keepUdating = false;
    }

    IEnumerator StartPressing()
    {
        yield return new WaitForSeconds(Costants.TIME_TO_WAIT_TO_START_ATTACK);
        while (keepUdating)
        {
            updateCursor();
            yield return new WaitForSeconds(Costants.TIME_TO_WAIT_ADD_TERMITES_TO_ATTACK);
        }
    }
}
