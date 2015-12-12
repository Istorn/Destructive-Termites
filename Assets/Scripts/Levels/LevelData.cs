﻿using UnityEngine;
using System.Collections;

public class LevelData : MonoBehaviour, LevelDataInterface
{
    protected Graph.Node[] _liveObjectsNodes;

    protected Graph.Connection[] _liveObjectsLinks;

    protected Graph.Node[] _termitesNodes;

    protected Graph.Connection[] _termitesLinks;

    protected Vector3[] _cameraSettings;

    protected HumanPlaceholder[] _humans;

    protected ObjectPlaceholder[] _objects;

    protected int _availableTermites;

    protected Vector2[][] _floorColliders;

    public virtual void initialize()
    {
    }

    // Property implementation:
    public Graph.Node[] liveObjectsNodes
    {
        get { return _liveObjectsNodes; }
    }

    public Graph.Connection[] liveObjectsLinks
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

    public Vector3[] cameraSettings
    {
        get { return _cameraSettings; }
    }

    public HumanPlaceholder[] humans
    {
        get { return _humans; }
    }

    public ObjectPlaceholder[] objects
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