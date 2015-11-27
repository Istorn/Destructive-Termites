using UnityEngine;
using System.Collections;

public interface LevelDataInterface{

    Graph.Node[] nodes { get; }

    Graph.Connection[] links { get; }

    Vector3[] cameraSettings { get; }

    HumanPlaceholder[] humans { get; }

    int availableTermites { get; }
}
