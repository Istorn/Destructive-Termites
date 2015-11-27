using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Classe Singleton condivisa da tutti gli oggetti per in movimento per gestire gli spostamenti autonomi
public static class Graph {

    //Lista dei nodi di riferimento nella mappa
    public static List<Node> nodes = new List<Node>();

    //Aggiunge un nodo al grafo
    public static void addNode(int nodeNumber, int roomNumber, Vector2 coordinates, Node.Type type)
    {
        Node node = new Node(nodeNumber, roomNumber, coordinates, type);
        addNode(node);
    }

    public static void addNode(Node node)
    {
        nodes.Add(node);
    }

    public static void addLink(Connection connection)
    {
        addLink(connection.nodeNumber1, connection.nodeNumber2, connection.distance, connection.z_index);
    }

    //Aggiunge un collegamento pesato tra due nodi nel grafo
    public static void addLink(int nodeNumber1, int nodeNumber2, int distance, int z_index)
    {
        Node node1 = null;
        Node node2 = null;
        for (int i = 0; i < nodes.Count; i++)
        {
            Node node = nodes[i];
            if (node.number == nodeNumber1)
                node1 = node;
            else
                if (node.number == nodeNumber2)
                    node2 = node;
        }
        node1.addNeighbor(new Neighbor(node2, distance, z_index));
        node2.addNeighbor(new Neighbor(node1, distance, z_index));
    }

    //Dato un identificativo per il nodo, lo cerca nel grafo e restituisce il nodo stesso
    public static Node findNode(int number)
    {
        foreach(Node n in nodes)
            if (number == n.number)
                return n;
        return null;
    }
    
    //Resetta il grafo, cancellandone nodi e link
    public static void reset()
    {
        foreach (Node node in nodes)
        {
            node.neighbors.Clear();
        }
        nodes.Clear();
    }

    //Restituisce il percordo minimo (Calcolato tramite l'algoritmo di Dijkstra) tra due nodi
    public static List<Node> getPath(int startNodeNumber, int endNodeNumber)
    {

        //Recupero il nodo iniziale e quello finale
        Node u = findNode(startNodeNumber);                                 
        Node endNode = findNode(endNodeNumber);

        //Definisco gli array per le distanze e i nodi precedenti
        double[] distances = new double[nodes.Count];
        Node[] previous = new Node[nodes.Count];
        
        //Li inizializzo
        foreach (Node n in nodes)                                           
        {
            // Distanza iniziale sconosciuta dalla sorgente a v
            distances[n.number] = double.PositiveInfinity;
            // Nodo precedente in un percorso ottimale dalla sorgente    
            previous[n.number] = null;                                     
        }

        // Distanza dalla sorgente alla sorgente
        distances[startNodeNumber] = 0;

        // Tutti i nodi nel grafo sono non ottimizzati e quindi stanno in Q
        List<Node> Q = new List<Node>(nodes);                               

        while (Q.Count > 0)                                                 
        {
            //All'inizio uso u = startNode, poi cerco il vertice in Q con minole dist[]
            if (u == null)
            {
                u = Q[0];
                double minDist = (double)distances[u.number];
                foreach (Node n in Q)                                        
                {
                    double dist = (double)distances[n.number];
                    if (dist < minDist)
                    {
                        minDist = dist;
                        u = n;
                    }
                }
            }
            //Se il nodo con minore distanza è il nodo finale termino
            if (u.number == endNode.number)
                break;
            else
            {
                //Rimuovo u da Q
                Q.Remove(u);
                //Se tutti i vertici rimanenti sono inaccessibili dal nodo sorgente termino
                if (distances[u.number] == double.PositiveInfinity)
                    break;                                                       
                //Ricalcolo le distanze dei vicini di u
                foreach (Neighbor v in u.neighbors)                               
                    if (Q.IndexOf(v.node) >= 0)
                    {
                        double alt = distances[u.number] + u.getDistance(v.node);
                        if (alt < distances[v.node.number])                          
                        {
                            distances[v.node.number] = alt;
                            previous[v.node.number] = u;
                            //decrease-key v in Q;                                     // Riordina v nella coda
                        }
                    }
            }
            u = null;
        }
        u = endNode;
        //Calcolo il percorso scandando Previuous[] al rovescio
        List<Node> path = new List<Node>();
        while (previous[u.number] != null)                                   
        {
            path.Insert(0, u);
            u = previous[u.number];                                         
        }
        path.Insert(0, findNode(startNodeNumber));
        return path;
    }

    //Classe Nodo
    public class Node
    {
        public enum Type { Main, Generic };

        public int number;
        public int roomNumber;
        public Type type;
        public Vector2 coordinates;
        public List<Neighbor> neighbors;

        //Costruttore
        public Node(int number, int roomNumber, Vector2 coordinates, Type type)
        {
            this.number = number;
            this.roomNumber = roomNumber;
            this.coordinates = coordinates;
            this.type = type;
            neighbors = new List<Neighbor>();
        }

        public int getZIndex(Node node)
        {
            foreach(Neighbor n in neighbors)
                if (n.node.number == node.number)
                    return n.z_index;
            return -1;
        }

        //Aggiunge un vicino al nodo
        public void addNeighbor(Neighbor neighbor)
        {
            neighbors.Add(neighbor);
        }

        //Recupera la distanza tra il nodo e un dato vicino
        public int getDistance(Node node)
        {
            foreach (Neighbor n in neighbors)
                if (n.node.number == node.number)
                    return n.distance;
            return 0;
        }
    }

    //Classe per la gestione dei nodi vicini ad un altro
    public class Neighbor
    {
        public Node node;
        public int z_index;
        public int distance;

        //Costruttore
        public Neighbor(Node neighbor, int distance, int z_index)
        {
            this.node = neighbor;
            this.distance = distance;
            this.z_index = z_index;
        }
    }

    public class Connection
    {
        public int nodeNumber1;
        public int nodeNumber2;
        public int distance;
        public int z_index;

        public Connection(int nodeNumber1, int nodeNumber2, int distance, int z_index)
        {
            this.nodeNumber1 = nodeNumber1;
            this.nodeNumber2 = nodeNumber2;
            this.distance = distance;
            this.z_index = z_index;
        }
    }
}
