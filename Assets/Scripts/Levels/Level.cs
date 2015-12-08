using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    private GameObject levelManager = null;

    private LevelDataInterface levelData = null;

    private GameObject background = null;
    private SpriteRenderer backgroundSpriteRenderer = null;

    private GameObject foreground = null;
    private SpriteRenderer foregroundSpriteRenderer = null;

    private MainCamera mainCamera = null;

    public Infobar infoBarScript = null;

    public int availableTermites = 0;
    public int usedTermites = 0;

    public Graph graphLiveObjects = null;
    public Graph graphTermites = null;

    public Room[] rooms = null;
    void Awake()
    {
        graphLiveObjects = new Graph();
        graphTermites = new Graph();

        loadGUI();    
    }

    private void loadGUI()
    {
        GameObject infoBar = Instantiate(Resources.Load("Prefabs/InfoBar", typeof(GameObject))) as GameObject;
        infoBar.name = "InfoBar";
        infoBarScript = infoBar.GetComponent<Infobar>();

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

        //foregroundSpriteRenderer = foreground.AddComponent<SpriteRenderer>();
        //foregroundSpriteRenderer.sortingOrder = Costants.Z_INDEX_FOREGROUND;

        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>(); //"); (Instantiate(Resources.Load("Prefabs/Camera", typeof(GameObject))) as GameObject).GetComponent<Camera>();
        mainCamera.setInfoBar(infoBar);
    }

    private void loadGraph()
    {
        graphLiveObjects.reset();

        foreach (Graph.Node node in levelData.liveObjectsNodes)
            graphLiveObjects.addNode(node);

        foreach (Graph.Connection connection in levelData.liveObjectsLinks)
            graphLiveObjects.addLink(connection);


        foreach(ObjectPlaceholder objectPlaceholder in levelData.objects)
        {
            GameObject obj = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
            GenericObject script = null;
            if (objectPlaceholder.type == GenericObject.Types.Soft)
                script = obj.AddComponent<SoftObject>();
            else
                if (objectPlaceholder.type == GenericObject.Types.Hard)
                    script = obj.AddComponent<HardObject>();
                else
                    script = obj.AddComponent<LiveObject>();

            script.setLevel(this);
            script.setPosition(objectPlaceholder.roomNumber, objectPlaceholder.coordinates, objectPlaceholder.z_index);
            script.setObjectName(objectPlaceholder.name);
            obj.transform.SetParent(this.transform);
        }
       /* GameObject chair = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        SoftObject chairScript = chair.AddComponent<SoftObject>();
        chairScript.setLevel(this);
        chairScript.setPosition(0, new Vector2(0, 2), Costants.Z_INDEX_HUMANS);
        chairScript.setObjectName("Chair");

        GameObject batDrawer = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        HardObject batDrawerScript = batDrawer.AddComponent<HardObject>();
        batDrawerScript.setLevel(this);
        batDrawerScript.setPosition(0, new Vector2(3, -3), Costants.Z_INDEX_HUMANS);
        batDrawerScript.setObjectName("Bat drawer");

        GameObject batSink = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        HardObject batSinkScript = batSink.AddComponent<HardObject>();
        batSinkScript.setLevel(this);
        batSinkScript.setPosition(0, new Vector2(-3, -4), Costants.Z_INDEX_HUMANS);
        batSinkScript.setObjectName("Bat sink");

        GameObject batTub = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        HardObject batTubScript = batTub.AddComponent<HardObject>();
        batTubScript.setLevel(this);
        batTubScript.setPosition(0, new Vector2(5, 2.5f), Costants.Z_INDEX_HUMANS);
        batTubScript.setObjectName("Bat tub");

        GameObject human = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        Human humanScript = human.AddComponent<Human>();
        humanScript.setLevel(this);
        humanScript.setPosition(0, new Vector2(-4, 0), Costants.Z_INDEX_HUMANS);
        humanScript.setObjectName("Chair");

        Debug.Log("TYPE: " + humanScript.getType());

        rooms[0].addObject(human);*/

    }

    public void setLevelManager(GameObject levelManager)
    {
        this.levelManager = levelManager;
    }

    public void setLevel(int level)
    {
        levelData = levelManager.GetComponent("Level" + level + "Data") as LevelDataInterface;
        levelData.initialize();

        rooms = levelData.rooms;

        availableTermites = levelData.availableTermites;

        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + level + "/Background");
        //foregroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + level + "/Foreground");

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
