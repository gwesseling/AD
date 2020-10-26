using System;
using System.Collections.Generic;

namespace AD
{
    public partial class Graph
    {
        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------
        public void RegioClearAll() // Calls Vertex.RegionReset() for all vertices
        {
            foreach (KeyValuePair<string, Vertex> v in this.vertexMap) {
                v.Value.RegioReset();
            }
        }

        public string AllPaths()
        {
            string s = "";

            foreach (KeyValuePair<string, Vertex> kv in this.vertexMap) {
                Vertex v = kv.Value;
                s += v.name;

                while (v.prev != null) {
                    s += $"<-{v.prev.name}";
                    v = v.prev;
                }

                s += ";";
            }

            return s;
        }

        public void AddUndirectedEdge(string source, string dest, double cost)
        {
            this.AddEdge(source, dest, cost);
            this.AddEdge(dest, source, cost);
        }


        public void AddVertex(string name, string regio)
        {
            this.vertexMap.Add(name, new Vertex(name, regio));
        }


        public void RegioDijkstra(string name)
        {
            PriorityQueue<Vertex> pq = new PriorityQueue<Vertex>();

            Vertex start = this.vertexMap[name];

            if (start == null) {
                throw new System.Exception();
            }

            RegioClearAll();
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

                    if (w.visited.Contains(v.regio)) {
                        continue;
                    }

                    // !v.visited.Contains(w.regio) !w.visited.Contains(v.regio)
                    if ((w.distance > v.distance + cvw)) {
                        if ((v.regio == w.regio || !v.visited.Contains(w.regio))) {
                            // w.visited.Add(v.regio);

                            foreach (string s in v.visited) {
                                w.visited.Add(s);
                            }

                            w.distance = v.distance + cvw;
                            w.prev = v;
                            pq.Add(w);
                        }
                    }
                }
            }
        }
    }
}
