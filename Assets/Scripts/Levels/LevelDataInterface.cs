using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface LevelDataInterface
{
    List<Graph.Node> liveObjectsNodes { get; }

    List<Graph.Connection> liveObjectsLinks { get; }

    Graph.Node[] termitesNodes { get; }

    Graph.Connection[] termitesLinks { get; }

    Vector3[] cameraSettings { get; }

    HumanPlaceholder[] humans { get; }

    ObjectPlaceholder[] objects { get; }

    int availableTermites { get; }

    Vector2[][] floorColliders { get; }

    void initialize();
}