using UnityEngine;
using System.Collections;

public class LevelData1: MonoBehaviour, LevelDataInterface {

    private Graph.Node[] _nodes = { //PIANO 0 - STANZA 0
                                    new Graph.Node( 0, 0, new Vector2(-5.50f, -2.60f), Graph.Node.Type.Main),
                                    new Graph.Node( 1, 0, new Vector2(-5.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 2, 0, new Vector2(-4.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 3, 0, new Vector2(-4.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 4, 0, new Vector2(-3.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 5, 0, new Vector2(-3.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 6, 0, new Vector2(-2.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 7, 0, new Vector2(-2.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 8, 0, new Vector2(-1.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node( 9, 0, new Vector2(-1.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(10, 0, new Vector2(-0.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(11, 0, new Vector2( 0.00f, -2.60f), Graph.Node.Type.Main),
                                    new Graph.Node(12, 0, new Vector2( 0.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(13, 0, new Vector2( 1.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(14, 0, new Vector2( 1.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(15, 0, new Vector2( 2.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(16, 0, new Vector2( 2.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(17, 0, new Vector2( 3.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(18, 0, new Vector2( 3.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(19, 0, new Vector2( 4.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(20, 0, new Vector2( 4.50f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(21, 0, new Vector2( 5.00f, -2.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(22, 0, new Vector2( 5.50f, -2.60f), Graph.Node.Type.Main),
                                    //SCALA PIANO 0 - 1
                                    new Graph.Node(23, 0, new Vector2( 0.50f, -2.10f), Graph.Node.Type.Generic),
                                    new Graph.Node(24, 0, new Vector2( 1.00f, -1.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(25, 0, new Vector2( 1.50f, -1.10f), Graph.Node.Type.Generic),
                                    new Graph.Node(26, 0, new Vector2( 2.00f, -0.60f), Graph.Node.Type.Generic),
                                    new Graph.Node(27, 0, new Vector2( 2.50f, -0.10f), Graph.Node.Type.Generic),
                                    new Graph.Node(28, 0, new Vector2( 3.00f,  0.40f), Graph.Node.Type.Generic),
                                    new Graph.Node(29, 0, new Vector2( 3.50f,  1.10f), Graph.Node.Type.Generic),
                                    //PIANO 1 - STANZA 1
                                    new Graph.Node(30, 1, new Vector2( 4.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(31, 1, new Vector2( 4.50f,  1.30f), Graph.Node.Type.Main),
                                    new Graph.Node(32, 1, new Vector2( 5.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(33, 1, new Vector2( 5.50f,  1.30f), Graph.Node.Type.Main),
                                    new Graph.Node(34, 1, new Vector2( 4.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(35, 1, new Vector2( 3.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(36, 1, new Vector2( 3.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(37, 1, new Vector2( 2.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(38, 1, new Vector2( 2.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(39, 1, new Vector2( 1.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(40, 1, new Vector2( 1.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(41, 1, new Vector2( 0.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(42, 1, new Vector2( 0.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(43, 1, new Vector2(-0.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(44, 1, new Vector2(-1.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(45, 1, new Vector2(-1.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(46, 1, new Vector2(-2.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(47, 1, new Vector2(-2.50f,  1.30f), Graph.Node.Type.Main),
                                    //PIANO 1 - STANZA 2
                                    new Graph.Node(48, 2, new Vector2(-3.00f,  1.30f), Graph.Node.Type.Main),
                                    new Graph.Node(49, 2, new Vector2(-3.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(50, 2, new Vector2(-4.00f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(51, 2, new Vector2(-4.50f,  1.30f), Graph.Node.Type.Generic),
                                    new Graph.Node(52, 2, new Vector2(-5.00f,  1.30f), Graph.Node.Type.Main) };

    private Graph.Connection[] _links = { new Graph.Connection( 0,  1, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 1,  2, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 2,  3, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 3,  4, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 4,  5, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 5,  6, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 6,  7, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 7,  8, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 8,  9, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection( 9, 10, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(10, 11, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(11, 12, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(12, 13, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(13, 14, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(14, 15, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(15, 16, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(16, 17, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(17, 18, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(18, 19, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(19, 20, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(20, 21, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(21, 22, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),

                                          new Graph.Connection(11, 23, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(23, 24, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(24, 25, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(25, 26, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(26, 27, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(27, 28, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(28, 29, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(29, 30, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(30, 31, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),

                                          new Graph.Connection(31, 32, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(32, 33, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),

                                          new Graph.Connection(31, 34, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(34, 35, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(35, 36, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(36, 37, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(37, 38, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(38, 39, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          new Graph.Connection(39, 40, 1, Costants.Z_INDEX_LIVE_OVER_FOREGROUND),
                                          
                                          new Graph.Connection(40, 41, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(41, 42, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(42, 43, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(43, 44, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(44, 45, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(45, 46, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(46, 47, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(47, 48, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(48, 49, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(49, 50, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(50, 51, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND),
                                          new Graph.Connection(51, 52, 1, Costants.Z_INDEX_LIVE_BEHIND_FOREGROUND) };

    private Vector3[] _cameraSettings = { new Vector3(0, -0.625f, -1), new Vector2(0, 0), new Vector2(0,0) };

    private HumanPlaceholder[] _humans = { }; //new HumanPlaceholder(0, false, new Vector2())

    private int _availableTermites = 500;

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

    public int availableTermites
    {
        get { return _availableTermites; }
    }
}
