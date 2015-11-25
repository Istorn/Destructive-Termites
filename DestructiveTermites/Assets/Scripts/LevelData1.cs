using UnityEngine;
using System.Collections;

public class LevelData1: MonoBehaviour, LevelDataInterface {

    private Graph.Node[] _nodes = { new Graph.Node(0, 0, new Vector2(-7.60f, -3.76f), 0),
                                  new Graph.Node(1, 0, new Vector2( 6.60f, -3.76f), 0),
                                  new Graph.Node(2, 0, new Vector2(-1.12f, -3.76f), 1),
                                  new Graph.Node(3, 1, new Vector2( 6.20f,  2.10f), 1),
                                  new Graph.Node(4, 1, new Vector2(-2.80f,  2.10f), 0),
                                  new Graph.Node(5, 2, new Vector2(-7.50f,  2.10f), 0)};

    private Graph.Connection[] _links = { new Graph.Connection(0, 2, 1),
                                        new Graph.Connection(1, 2, 1),
                                        new Graph.Connection(2, 3, 1),
                                        new Graph.Connection(3, 4, 1),
                                        new Graph.Connection(4, 5, 1)};

    private Vector3[] _cameraSettings = { new Vector3(0, -0.4f, -1), new Vector2(0,0), new Vector2(0,0) };

    private HumanPlaceholder[] _humans = { }; //new HumanPlaceholder(0, false, new Vector2())


    // Property implementation:
    public Graph.Node[] nodes
    {
        get { return _nodes; }
    }

    public Graph.Connection[] links
    {
        get { return _links; }
    }

    public Vector3[] cameraSettings
    {
        get { return _cameraSettings; }
    }
    
    public HumanPlaceholder[] humans
    {
        get { return _humans; }
    }
}
