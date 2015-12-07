using UnityEngine;
using System.Collections;

public interface LevelDataInterface
{
    Graph.Node[] liveObjectsNodes { get; }

    Graph.Connection[] liveObjectsLinks { get; }

    Graph.Node[] termitesNodes { get; }

    Graph.Connection[] termitesLinks { get; }

    Vector3[] cameraSettings { get; }

    HumanPlaceholder[] humans { get; }

    ObjectPlaceholder[] objects { get; }

    int availableTermites { get; }

    Room[] rooms { get; }

    void initialize();
}