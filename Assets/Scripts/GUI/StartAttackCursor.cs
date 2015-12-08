using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartAttackCursor : MonoBehaviour {

    private Sprite[] sprites;
    private int i = 0;
    public int attackers = 0;
    public int availableAttackers = 0;
    private bool keepUdating = true;

    private GUIStyle style;
    private Rect indicatorRect;
	// Use this for initialization
	void Awake () {
        sprites = sprites = Resources.LoadAll<Sprite>("SpriteSheets/GUI/StartAttackCursor");
        style = new GUIStyle(Resources.Load<GUISkin>("GUI/StartAttackCursor/IndicatorSkin").box);

        
	}

    public void setPosition(Vector2 position)
    {
        transform.position = position;
    }

    public bool updateCursor()
    {
        if (i + 1 < sprites.Length)
        {
            i++;
            GetComponent<SpriteRenderer>().sprite = sprites[i];
            attackers = (i + 1) * availableAttackers / sprites.Length;
            return true;
        }
        else
            return false;
    }

    void OnGUI()
    {
        if (attackers > 0)
        {
            Vector3 indicatorPosition = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, GetComponent<RectTransform>().rect.height) * 0.5f);
            indicatorPosition.x = indicatorPosition.x - (float)Costants.OBJ_CURSOR_INDICATOR_WIDTH / 2;
            indicatorPosition.y = Screen.height - indicatorPosition.y - Costants.OBJ_CURSOR_INDICATOR_HEIGHT + Costants.OBJ_CURSOR_INDICATOR_OFFSET_V;
            indicatorRect = new Rect(indicatorPosition.x, indicatorPosition.y, Costants.OBJ_CURSOR_INDICATOR_WIDTH, Costants.OBJ_CURSOR_INDICATOR_HEIGHT);
            GUI.Box(indicatorRect, attackers + "", style);
        }
    }
}
