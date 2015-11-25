using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    private int level;

    private GameObject levelManager = null;

    private LevelDataInterface levelData = null;

    private GameObject background = null;
    private SpriteRenderer backgroundSpriteRenderer = null;

    private GameObject foreground = null;
    private SpriteRenderer foregroundSpriteRenderer = null;

    private Camera camera = null;

    private GameObject infoBox = null;

    void Awake()
    {
        infoBox = Instantiate(Resources.Load("Prefabs/InfoBox", typeof(GameObject))) as GameObject;

        background = new GameObject();
        background.name = "Background";
        background.layer = LayerMask.NameToLayer(Costants.LAYER_BACKGROUND);
        background.transform.parent = gameObject.transform;

        backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sortingOrder = Costants.Z_INDEX_BACKGROUND;

        foreground = new GameObject();
        foreground.name = "Foreground";
        foreground.layer = LayerMask.NameToLayer(Costants.LAYER_FOREGROUND);
        foreground.transform.parent = gameObject.transform;

        foregroundSpriteRenderer = foreground.AddComponent<SpriteRenderer>();
        foregroundSpriteRenderer.sortingOrder = Costants.Z_INDEX_FOREGROUND;

        camera = GameObject.Find("Main Camera").GetComponent<Camera>(); //"); (Instantiate(Resources.Load("Prefabs/Camera", typeof(GameObject))) as GameObject).GetComponent<Camera>();
    }

    public void setLevelManager(GameObject levelManager)
    {
        this.levelManager = levelManager;
    }

    public void setLevel(int level)
    {
        this.level = level;

        levelData = levelManager.GetComponent("LevelData" + level) as LevelDataInterface;

        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + level + "/Background");
        foregroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + level + "/Foreground");

        camera.setCenter(levelData.cameraSettings[0]);
        camera.setBouds(levelData.cameraSettings[1], levelData.cameraSettings[2]);
    }

    public void addCollider(Vector2 offset, Vector2 size)
    {
        BoxCollider2D collider = (BoxCollider2D)gameObject.AddComponent<BoxCollider2D>();
        collider.offset = new Vector2(1, 2);
        collider.size = new Vector3(21, 1.6f);
    }
}
