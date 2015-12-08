using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColonyCursor : MonoBehaviour {

    public int attackers = 0;
    private GUIStyle style;
    private Rect indicatorRect;

    private Sprite[] sprites = null;
	// Use this for initialization
	void Awake () {
        style = new GUIStyle(Resources.Load<GUISkin>("GUI/StartAttackCursor/IndicatorSkin").box);
        sprites = sprites = Resources.LoadAll<Sprite>("GUI/AttackCursor");
        GetComponent<SpriteRenderer>().sprite = sprites[0];
	}

    public void setPosition(Vector2 position, Vector3 size)
    {
        transform.position = position;
        GetComponent<RectTransform>().sizeDelta = size;
    }

    void OnGUI()
    {
        if (attackers > 0)
        {
            Vector3 indicatorPosition = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, GetComponent<RectTransform>().rect.height) * 0.5f);
            indicatorPosition.x = indicatorPosition.x - (float)Costants.OBJ_CURSOR_INDICATOR_WIDTH/ 2;
            indicatorPosition.y = Screen.height - indicatorPosition.y - Costants.OBJ_CURSOR_INDICATOR_HEIGHT + Costants.OBJ_CURSOR_INDICATOR_OFFSET_V;
            indicatorRect = new Rect(indicatorPosition.x, indicatorPosition.y, Costants.OBJ_CURSOR_INDICATOR_WIDTH, Costants.OBJ_CURSOR_INDICATOR_HEIGHT);
            GUI.Box(indicatorRect, attackers + "", style);
        }
    }
}
