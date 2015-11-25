using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System;
using System.Globalization;

public class LevelInitializer : MonoBehaviour {


    public int level = 0;
    private string levelStr = "Assets/Levels/level";
    public Vector2[] cameraBounds;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        levelUp();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void levelUp()
    {
        level++;
        Graph.reset();
        switch (level)
        {
            case 1:
                initGraphLevel1();
                break;
        }

    }

    private void initGraphLevel1()
    {
        Graph.addNode(0, new Vector2(-7.60f, -3.76f), 0);
        Graph.addNode(1, new Vector2( 6.60f, -3.76f), 0);
        Graph.addNode(2, new Vector2(-1.12f, -3.76f), 1);

        Graph.addNode(3, new Vector2( 6.20f,  2.10f), 1);
        Graph.addNode(4, new Vector2(-2.80f,  2.10f), 0);
        Graph.addNode(5, new Vector2(-7.50f,  2.10f), 0);

        Graph.addLink(0, 2, 1);
        Graph.addLink(1, 2, 1);
        Graph.addLink(2, 3, 1);
        Graph.addLink(3, 4, 1);
        Graph.addLink(4, 5, 1);

        GameObject camera = Instantiate(Resources.Load("Prefabs/Main Camera", typeof(GameObject))) as GameObject;
        //camera.GetComponent<Camera>().setCenter(new Vector3(0, -2.9f, -1));
        //camera.GetComponent<Camera>().setBouds(new Vector2(-7.2f, -2.9f), new Vector2(7.2f, 2.0f));
        camera.GetComponent<Camera>().setCenter(new Vector3(0, 0, -1));
        camera.GetComponent<Camera>().setBouds(new Vector2(0, 0), new Vector2(0, 0));


        int[] humanInitialNodeNumbers = {0, 3, 5};
        foreach (int humanInitialNodeNumber in humanInitialNodeNumbers)
        {
            GameObject human = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject))) as GameObject;
            human.GetComponent<Player>().setActualNodeNumber(humanInitialNodeNumber);
        }
    }

    public static void loadLevelXML(string XMLPath)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(XMLPath);

        try
        {
            LevelData.availableTermites = Convert.ToInt32(doc.SelectSingleNode("level/settings/termites").Attributes["quantity"].Value);

            foreach (XmlNode availablePowerUp in doc.SelectNodes("level/settings/availablePowerUp"))
                LevelData.availablePowerUps.Add(Convert.ToInt32(availablePowerUp.Attributes["type"].Value));

            foreach (XmlNode availableThreat in doc.SelectNodes("level/settings/availableThreat"))
                LevelData.availableThreats.Add(Convert.ToInt32(availableThreat.Attributes["type"].Value));

            foreach (XmlNode waypoint in doc.GetElementsByTagName("waypoint"))
            {
                int number = Convert.ToInt32(waypoint.Attributes["number"].Value);
                float x = float.Parse(waypoint.Attributes["x"].Value, CultureInfo.InvariantCulture.NumberFormat);
                float y = float.Parse(waypoint.Attributes["y"].Value, CultureInfo.InvariantCulture.NumberFormat);
                int isOnStairs = Convert.ToInt32(waypoint.Attributes["isOnStairs"].Value);
                Graph.addNode(number, new Vector2(x, y), isOnStairs);
                //Debug.Log(number + "(" + x + "," + y + "):" + isOnStairs);
            }


            foreach (XmlNode link in doc.GetElementsByTagName("link"))
            {
                int node1 = Convert.ToInt32(link.Attributes["node1"].Value);
                int node2 = Convert.ToInt32(link.Attributes["node2"].Value);
                int distance = Convert.ToInt32(link.Attributes["distance"].Value);
                Graph.addLink(node1, node2, distance);
            }

            foreach (XmlNode human in doc.GetElementsByTagName("human"))
            {
                GameObject prefab = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject))) as GameObject;
                prefab.layer = LayerMask.NameToLayer("Persone");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Errore nel file: " + XMLPath + " (" + e.ToString() + ")");
            throw;
        }
    }
}
