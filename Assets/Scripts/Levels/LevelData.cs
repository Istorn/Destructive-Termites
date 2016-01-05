using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelData : MonoBehaviour
{
    protected List<Graph.Node> _liveObjectsNodes;

    protected List<Graph.Connection> _liveObjectsLinks;

    protected Graph.Node[] _termitesNodes;

    protected Graph.Connection[] _termitesLinks;

    protected Vector3 _cameraCenter;

    protected HumanPlaceholder[] _humans;

    protected List<ObjectPlaceholder> _objects;

    protected int _availableTermites;

    protected Vector2[][] _floorColliders;

    public virtual void initialize()
    {
    }

    // Property implementation:
    public List<Graph.Node> liveObjectsNodes
    {
        get { return _liveObjectsNodes; }
    }

    public List<Graph.Connection> liveObjectsLinks
    {
        get { return _liveObjectsLinks; }
    }

    public Graph.Node[] termitesNodes
    {
        get { return _termitesNodes; }
    }

    public Graph.Connection[] termitesLinks
    {
        get { return _termitesLinks; }
    }

    public Vector3 cameraCenter
    {
        get { return _cameraCenter; }
    }

    public HumanPlaceholder[] humans
    {
        get { return _humans; }
    }

    public List<ObjectPlaceholder> objects
    {
        get { return _objects; }
    }

    public int availableTermites
    {
        get { return _availableTermites; }
    }

    public Vector2[][] floorColliders
    {
        get { return _floorColliders; }
    }
}
