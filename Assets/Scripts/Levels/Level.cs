using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    private GameObject levelManager = null;

    private LevelDataInterface levelData = null;

    private GameObject background = null;
    private SpriteRenderer backgroundSpriteRenderer = null;
    private SpriteRenderer foregroundSpriteRenderer = null;

    private GameObject foreground = null;

    private MainCamera mainCamera = null;

    public Infobar infoBarScript = null;

    public int availableTermites = 0;
    public int usedTermites = 0;

    public Graph graphLiveObjects = null;
    public Graph graphTermites = null;

    public List<Room> rooms = null;

    public List<Booster> collectedBoosters = null;

    void Awake()
    {
        initVars();

        initGUI();    
    }

    private void initVars()
    {
        rooms = new List<Room>();
        collectedBoosters = new List<Booster>();

        graphLiveObjects = new Graph();
        graphTermites = new Graph();
    }

    private void initGUI()
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

        foregroundSpriteRenderer = foreground.AddComponent<SpriteRenderer>();
        foregroundSpriteRenderer.sortingOrder = Costants.Z_INDEX_FOREGROUND;

        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        mainCamera.setInfoBar(infoBar);
    }

    private void loadGraph()
    {
        graphLiveObjects.reset();

        foreach (Graph.Node node in levelData.liveObjectsNodes)
            graphLiveObjects.addNode(node);

        foreach (Graph.Connection connection in levelData.liveObjectsLinks)
            graphLiveObjects.addLink(connection);
    }

    private void loadObjects()
    {
        int id = 0;
        foreach (ObjectPlaceholder objectPlaceholder in levelData.objects)
        {
            GameObject obj = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
            obj.name = objectPlaceholder.name;
            GenericObject script = null;
            if (objectPlaceholder.type == GenericObject.Types.Soft)
                script = obj.AddComponent<SoftObject>();
            else
                if (objectPlaceholder.type == GenericObject.Types.Hard)
                    script = obj.AddComponent<HardObject>();
                else
                    if (objectPlaceholder.type == GenericObject.Types.Hard)
                        script = obj.AddComponent<HardObject>();
                    else
                        script = obj.AddComponent<GenericObject>();

            script.setLevel(this);
            script.isHanging = objectPlaceholder.isHanging;
            script.setId(id);
            script.setPosition(objectPlaceholder.coordinates, objectPlaceholder.z_index);
            script.setObjectName(objectPlaceholder.name);
            obj.transform.SetParent(this.transform);

            addObjectToRoom(script, objectPlaceholder.roomNumber);
            id++;
        }

        GameObject human = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        Human humanScript = human.AddComponent<Human>();
        humanScript.setLevel(this);
        humanScript.setId(-1);
        humanScript.setPosition(new Vector2(-4, 0), Costants.Z_INDEX_HUMANS);
        humanScript.setObjectName("Chair");
    }

    private void addObjectToRoom(GenericObject obj, int roomNumber)
    {
        Room room = null;
        foreach(Room r in rooms)
            if (r.number == roomNumber)
            {
                room = r;
                break;
            }
        if (room == null)
        {
            room = new Room(roomNumber);
            rooms.Add(room);
        }
        room.addObject(obj);
        obj.setRoom(room);
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

        loadObjects();

        loadFloorColliders();
    }

    public void loadFloorColliders()
    {
        foreach (Vector2[] points in levelData.floorColliders)
        {
            EdgeCollider2D collider = background.AddComponent<EdgeCollider2D>();
            collider.points = points;
        }
    }

    public void collectBooster(Booster booster)
    {
        foreach (Booster b in collectedBoosters)
            if (b.type.Equals(booster.type))
            {
                b.collectOne();
                return;
            }
        collectedBoosters.Add(booster);
    }
}
