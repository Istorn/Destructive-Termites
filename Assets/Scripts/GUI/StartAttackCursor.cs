using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartAttackCursor : MonoBehaviour {

    public Text label;
    private Sprite[] sprites;

    private int spriteIndex = 0;
    public int attackers = 0;
    public int availableAttackers = 0;

    void Awake () {
        sprites = Resources.LoadAll<Sprite>("SpriteSheets/GUI/StartAttackCursor");
	}

    public void setPosition(Vector2 position)
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(position);
    }

    public bool updateCursor()
    {
        if (spriteIndex + 1 < sprites.Length)
        {
            spriteIndex++;
            gameObject.GetComponent<Image>().sprite = sprites[spriteIndex];
            attackers = (spriteIndex + 1) * availableAttackers / sprites.Length;
            label.text = (int)attackers + "";
            return true;
        }
        else
            return false;
    }
}
