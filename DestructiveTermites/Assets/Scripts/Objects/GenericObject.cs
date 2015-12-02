using UnityEngine;
using System.Collections;

public class GenericObject : MonoBehaviour {

    public enum Types { Soft, Hard, Live}

    protected Types type;

    public int roomNumber;

    protected float strenghtCoefficient = 0.2f;

    protected float integrity = 100.0f;
    protected float oldIntegrity = 100.0f;

    protected Sprite[] sprites;

    protected Level level = null;

    public void setLevel(Level level)
    {
        this.level = level;
    }

    public void setPosition(int roomNumber, Vector2 coordinates, int z_index)
    {
        this.roomNumber = roomNumber;
        gameObject.transform.position = coordinates;
        GetComponent<SpriteRenderer>().sortingOrder = z_index;
    }

    public virtual void setObjectName(string objectName)
    {
        sprites = Resources.LoadAll<Sprite>("SpriteSheets/" + objectName);
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    void attack(int numberOfAttackers)
    {
        if (integrity > 0)
        {
            integrity -= numberOfAttackers * strenghtCoefficient;
            int i = (int)((100 - integrity) * (sprites.Length - 1) / 100);
            GetComponent<SpriteRenderer>().sprite = sprites[i];
            oldIntegrity = integrity;
        }
        else
            Destroy(gameObject);
    }

    void OnMouseDown()
    {
        attack(100);
    }
}
