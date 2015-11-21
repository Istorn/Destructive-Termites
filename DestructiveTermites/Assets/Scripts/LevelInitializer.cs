using UnityEngine;
using System.Collections;
using System.Xml;
using System;
using System.Globalization;

public class LevelInitializer : MonoBehaviour {

    public int level = 1;
    private string levelStr = "Assets/Levels/level";

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        loadLevelXML(levelStr + level + ".xml");
	}
	
	// Update is called once per frame
	void Update () {
	
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
