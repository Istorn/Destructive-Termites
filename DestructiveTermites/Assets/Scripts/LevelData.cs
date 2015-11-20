using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;
using System.Globalization;


 public class LevelData {

    public static int NUMERO_DI_COPIE_MAX = 1;
    public static int NUMERO_DI_COPIE_MIN = 10;
    public static float HUMAN_SPEED = 2.5f;
    public static int availableTermites = 0;
    public static List<int> availablePowerUps = new List<int>();
    public static List<int> availableThreats = new List<int>();

    public static void provaXML(string XMLPath)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(XMLPath);

        try {
            availableTermites = Convert.ToInt32(doc.SelectSingleNode("level/settings/termites").Attributes["quantity"].Value);

            foreach(XmlNode availablePowerUp in doc.SelectNodes("level/settings/availablePowerUp"))
                availablePowerUps.Add(Convert.ToInt32(availablePowerUp.Attributes["type"].Value));

            foreach (XmlNode availableThreat in doc.SelectNodes("level/settings/availableThreat"))
                availableThreats.Add(Convert.ToInt32(availableThreat.Attributes["type"].Value));

            string aPU = "";
            foreach (int i in availableThreats)
                aPU = aPU + "," + i;
            Debug.Log(aPU);

            foreach (XmlNode waypoint in doc.GetElementsByTagName("waypoint"))
            {
                int number = Convert.ToInt32(waypoint.Attributes["number"].Value);
                float x = float.Parse(waypoint.Attributes["x"].Value, CultureInfo.InvariantCulture.NumberFormat);
                float y = float.Parse(waypoint.Attributes["y"].Value, CultureInfo.InvariantCulture.NumberFormat);
                int isOnStairs = Convert.ToInt32(waypoint.Attributes["isOnStairs"].Value);
                Graph.addNode(number, new Vector3(x, y, 0), isOnStairs);
            }

            foreach (XmlNode link in doc.GetElementsByTagName("link"))
            {
                int node1 = Convert.ToInt32(link.Attributes["node1"].Value);
                int node2 = Convert.ToInt32(link.Attributes["node2"].Value);
                int distance = Convert.ToInt32(link.Attributes["distance"].Value);
                Graph.addLink(node1, node2, distance);
            }
        } catch (Exception e) {
            Debug.Log("Errore nel file: " + XMLPath);

         throw;
        }

        /*XmlNodeList settings = doc.GetElementsByTagName("settings");
        foreach(XmlNode node in settings)
        {
            string name = node.Name;
            foreach (XmlAttribute attribute in node.Attributes)
            {
                string attr = attr[]
            }
            string text = node.Attributes
            Debug.Log(text);
        }*/
        //string text = node.InnerText;

        //string attr = node.Attributes["theattributename"].InnerText;
    }
}
