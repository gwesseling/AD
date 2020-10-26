using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            this.vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            this.CreateIfNotExist(name);
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            return CreateIfNotExist(name);
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            Vertex from = this.CreateIfNotExist(source);
            Vertex to = this.CreateIfNotExist(dest);

            from.adj.AddFirst(new Edge(to, cost));
        }

        public Vertex CreateIfNotExist(string name) {
            if (vertexMap.ContainsKey(name)) {
                return this.vertexMap[name];
            }

            Vertex v = new Vertex(name);
            this.vertexMap.Add(name, v);
            return v;
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (KeyValuePair<string, Vertex> vm in this.vertexMap) {
                vm.Value.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name) {
            ClearAll();

            Vertex start = vertexMap[name];
            if (start == null) {
                throw new System.Exception();
            }

            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(start);
            start.distance = 0;

            while (q.Count != 0) {
                Vertex v = q.Dequeue();

                foreach (Edge e in v.adj) {
                    Vertex w = e.dest;

                    if (w.distance == INFINITY) {
                        w.distance = v.distance + 1;
                        w.prev = v;
                        q.Enqueue(w);
                    }
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            PriorityQueue<Vertex> pq = new PriorityQueue<Vertex>();

            Vertex start = vertexMap[name];

            if (start == null) {
                throw new System.Exception();
            }

            ClearAll();
            pq.Add(start);
            start.distance = 0;

            int nodeSeen = 0;
            while (!pq.IsEmpty() && nodeSeen < vertexMap.Count) {
                Vertex v = pq.Remove();

                if (v.known) {
                    continue;
                }

                v.known = true;
                nodeSeen++;

                foreach (Edge e in v.adj) {
                    Vertex w = e.dest;
                    double cvw = e.cost;

                    if (cvw < 0) {
                        throw new System.Exception();
                    }

                    if (w.distance > v.distance + cvw) {
                        w.distance = v.distance + cvw;
                        w.prev = v;
                        pq.Add(w);
                    }
                }
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            string s = "";

            foreach (string key in vertexMap.Keys.OrderBy(x => x)) {  
                s += this.vertexMap[key] + "\n"; 
            }

            return s;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------
        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }

    }
}