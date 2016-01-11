using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    private int levelNumber = 0;

    public int usedTermites = 0;

    private LevelData levelData = null;

    private Graph graphLiveObjects = null;

    private Graph graphTermites = null;

    public List<Room> rooms = null;

    public List<Booster> collectedBoosters = null;

    public ConcurrentQueue<GenericObject> alertObjectsQueue = null;

    private int availableTermites;

    void Awake()
    {
        alertObjectsQueue = new ConcurrentQueue<GenericObject>();

        rooms = new List<Room>();
        collectedBoosters = new List<Booster>();

        graphLiveObjects = new Graph();
        graphTermites = new Graph();
    }

    public int getLevelNumber()
    {
        return levelNumber;
    }

    public void decreaseAvailableTermites(int usedTermites)
    {
        availableTermites -= usedTermites;
    }

    public void setLevelData(LevelData levelData, int number)
    {

        this.levelNumber = number;
        this.levelData = levelData;

        GameManager.setCurrentLevel(this);

        GameManager.getMainGamera().initalize(levelData.cameraCenter);

        initBackground();

        initForeground();

        initRooms();

        initLiveObjectsGraph();
        
        initObjects();

        initHumans();
		initFrogs();
    }

    public int getAvailableTermites()
    {
        int avail = 0;
        if (levelData)
            avail = levelData.availableTermites;
        return avail;
    }

    private void initBackground()
    {
        GameObject background = new GameObject();
        background.name = "Background";
        background.layer = LayerMask.NameToLayer(Costants.LAYER_BACKGROUND);
        background.transform.parent = gameObject.transform;
        background.tag = Costants.TAG_BACKGROUND;

        SpriteRenderer backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sortingOrder = Costants.Z_INDEX_BACKGROUND;

        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + levelNumber + "/Background");

        initFloorColliders(background);
    }

    private void initFloorColliders(GameObject background)
    {
        foreach (Vector2[] points in levelData.floorColliders)
        {
            EdgeCollider2D collider = background.AddComponent<EdgeCollider2D>();
            collider.points = points;
        }
    }

    private void initForeground()
    {
        GameObject foreground = new GameObject();
        foreground.name = "Foreground";
        foreground.layer = LayerMask.NameToLayer(Costants.LAYER_FOREGROUND);
        foreground.transform.parent = gameObject.transform;

        
        SpriteRenderer foregroundSpriteRenderer = foreground.AddComponent<SpriteRenderer>();
        foregroundSpriteRenderer.sortingOrder = Costants.Z_INDEX_FOREGROUND;

        foregroundSpriteRenderer.sprite = Resources.Load<Sprite>("Levels/" + levelNumber + "/Foreground");

        BoxCollider2D box = foreground.AddComponent<BoxCollider2D>();


        Vector2 bottomLeft = new Vector2(-box.size.x / 2, -box.size.y / 2 - GameManager.getLevelGUI().getBottomBarBottomCoord());
        Vector2 bottomRight = new Vector2(box.size.x / 2, -box.size.y / 2 - GameManager.getLevelGUI().getBottomBarBottomCoord());
        Vector2 topLeft = new Vector2(-box.size.x / 2, box.size.y / 2);
        Vector2 topRight = new Vector2(box.size.x / 2, box.size.y / 2);

        EdgeCollider2D collider = foreground.AddComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[2];
        points[0] = topRight;
        points[1] = topLeft;
        collider.points = points;

        collider = foreground.AddComponent<EdgeCollider2D>();
        points = new Vector2[2];
        points[0] = topLeft;
        points[1] = bottomLeft;
        collider.points = points;

        collider = foreground.AddComponent<EdgeCollider2D>();
        points = new Vector2[2];
        points[0] = bottomLeft;
        points[1] = bottomRight;
        collider.points = points;

        collider = foreground.AddComponent<EdgeCollider2D>();
        points = new Vector2[2];
        points[0] = bottomRight;
        points[1] = topRight;
        collider.points = points;

        Destroy(box);
    }

    private void initLiveObjectsGraph()
    {
        graphLiveObjects.reset();

        foreach (Graph.Node node in levelData.liveObjectsNodes)
            graphLiveObjects.addNode(node);

        foreach (Graph.Connection connection in levelData.liveObjectsLinks)
            graphLiveObjects.addLink(connection);
    }

    public Graph getGraphLiveObjects()
    {
        return graphLiveObjects;
    }

    private void initHumans()
    {
        GameObject human = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        human.name = "Human0";
        Human humanScript = human.AddComponent<Human>();
        humanScript.setId(-1);
        humanScript.setPosition(new Vector2(-11.50f, -4.10f), Costants.Z_INDEX_HUMANS);
        humanScript.actualNodeNumber = 2;
        humanScript.setObjectName("Chair", "");
    }
	
    private void initFrogs()
    {
        GameObject frog = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
        frog.name = "Frog0";
        Frog frogScript = frog.AddComponent<Frog>();
        frogScript.setId(-1);
        frogScript.setPosition(new Vector2(-11.50f, -4.10f), Costants.Z_INDEX_FROGS);
        frogScript.actualNodeNumber = 2;
        frogScript.setObjectName("Chair", "");
    }

    private void initObjects()
    {
        int id = 0;
        foreach (ObjectPlaceholder objectPlaceholder in levelData.objects)
        {
            GameObject obj = Instantiate(Resources.Load("Prefabs/Object", typeof(GameObject))) as GameObject;
            obj.name = objectPlaceholder.getPathName();
            GenericObject script = null;
            if (objectPlaceholder.getModel().Equals(GenericObject.Model.Soft))
                script = obj.AddComponent<SoftObject>();
            else
                if (objectPlaceholder.getModel().Equals(GenericObject.Model.Hard))
                    script = obj.AddComponent<HardObject>();
                else
                    if (objectPlaceholder.getModel().Equals(GenericObject.Model.Hard))
                        script = obj.AddComponent<HardObject>();
                    else
                        script = obj.AddComponent<GenericObject>();

            script.setProperties(objectPlaceholder.getIsOnSomething(), objectPlaceholder.getIsHanging(), objectPlaceholder.getIsHorizontallyFlipped(), objectPlaceholder.getStrengthCoefficient());
            script.setId(id);
            script.setPosition(objectPlaceholder.getCoordinates(), objectPlaceholder.getZIndex());
            script.setObjectName(objectPlaceholder.getName(), objectPlaceholder.getPathName());
            obj.transform.SetParent(this.transform);

            addObjectToRoom(script, objectPlaceholder.getRoomNumber());
            id++;
        }
    }

    private void initRooms()
    {
        int r = 0;
        for (int room = 0; room < levelData.rooms.Count; room = room + 2)
        {
            rooms.Add(new Room(r));
            GameManager.getLevelGUI().initRoomIndicator(levelData.rooms[room], levelData.rooms[room + 1], r);
            r++;
        }
    }

    private void addObjectToRoom(GenericObject obj, int roomNumber)
    {
        rooms[roomNumber].addObject(obj);
        obj.setRoom(rooms[roomNumber]);
    }    

    public void dropBooster(Booster booster)
    {
        collectedBoosters.Add(booster);
    }
}
