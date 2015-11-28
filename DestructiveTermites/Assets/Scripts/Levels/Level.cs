using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    private GameObject levelManager = null;

    private LevelDataInterface levelData = null;

    private GameObject background = null;
    private SpriteRenderer backgroundSpriteRenderer = null;

    private GameObject foreground = null;
    private SpriteRenderer foregroundSpriteRenderer = null;

    private MainCamera mainCamera = null;

    private GameObject infoBox = null;

    private int availableTermites = 0;

    public Graph graphLiveObjects = null;
    public Graph graphTermites = null;

    void Awake()
    {
        graphLiveObjects = new Graph();
        graphTermites = new Graph();

        loadGUI();    
    }

    private void loadGUI()
    {
        infoBox = Instantiate(Resources.Load("Prefabs/InfoBox", typeof(GameObject))) as GameObject;
        infoBox.name = "InfoBox";

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

        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>(); //"); (Instantiate(Resources.Load("Prefabs/Camera", typeof(GameObject))) as GameObject).GetComponent<Camera>();
    }

    private void loadGraph()
    {
        graphLiveObjects.reset();

        foreach (Graph.Node node in levelData.liveObjectsNodes)
            graphLiveObjects.addNode(node);

        foreach (Graph.Connection connection in levelData.liveObjectsLinks)
            graphLiveObjects.addLink(connection);

        GameObject provaObj = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        Human script = provaObj.AddComponent<Human>();
        script.setLevel(this);
        script.setPosition(0, new Vector2(1, 1), Costants.Z_INDEX_HUMANS);
        script.setObjectName("Chair");
    }

    public void setLevelManager(GameObject levelManager)
    {
        this.levelManager = levelManager;
    }

    public void setLevel(int level)
    {
        levelData = levelManager.GetComponent("Level" + level + "Data") as LevelDataInterface;
        levelData.initialize();

        availableTermites = levelData.availableTermites;

        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + level + "/Background");
        foregroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + level + "/Foreground");

        mainCamera.setCenter(levelData.cameraSettings[0]);
        mainCamera.setBouds(levelData.cameraSettings[1], levelData.cameraSettings[2]);

        loadGraph();

    }

    public void addCollider(Vector2 offset, Vector2 size)
    {
        BoxCollider2D collider = (BoxCollider2D)gameObject.AddComponent<BoxCollider2D>();
        collider.offset = new Vector2(1, 2);
        collider.size = new Vector3(21, 1.6f);
    }
}
