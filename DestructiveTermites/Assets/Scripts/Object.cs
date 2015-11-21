using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

    public enum ObjectType {Soft, Hard, Live};
    
    public ObjectType tipology = ObjectType.Soft;

    public float strenghtCoefficient = 0.0f;

    public float integrity = 100.0f;
    private float oldIntegrity = 100.0f;

    public string objectName = "Chair";

    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        sprites = Resources.LoadAll<Sprite>(objectName);
	}
	
	// Update is called once per frame
	void Update () {
        if (integrity > 0)
        {
            if (oldIntegrity != integrity)
            {
                int i = (int)((100- integrity) * (sprites.Length - 1) / 100);
                GetComponent<SpriteRenderer>().sprite = sprites[i];
                oldIntegrity = integrity;
            }
        }
        else
            Destroy(gameObject);
	}

    void attack(int numberOfAttackers)
    {
        if (integrity > 0)
            integrity -= numberOfAttackers * strenghtCoefficient;
    }

    void OnMouseDown()
    {
        attack(100);
    }  
}
