using System;
using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class Vertex : IVertex
    {
        public string name;
        public LinkedList<Edge> adj;
        public double distance;
        public Vertex prev;
        public bool known;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        /// <summary>
        ///    Creates a new Vertex instance.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public Vertex(string name)
        {
            this.name = name;
            this.adj = new LinkedList<Edge>();
            this.Reset();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public string GetName()
        {
            return this.name;
        }
        public LinkedList<Edge> GetAdjacents()
        {
            return this.adj;
        }

        public double GetDistance()
        {
            return this.distance;
        }

        public Vertex GetPrevious()
        {
            return this.prev;
        }

        public bool GetKnown()
        {
            return this.known;
        }

        public void Reset()
        {
            this.prev = null;
            this.distance = Double.MaxValue;
            this.known = false;
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Vertex to its string representation.
        ///    <para>Output will be like : name (distance) [ adj1 (cost) adj2 (cost) .. ]</para>
        ///    <para>Adjecents are ordered ascending by name. If no distance is
        ///    calculated yet, the distance and the parantheses are omitted.</para>
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns> 
        public override string ToString()
        {
            string s = this.name + (this.distance != Double.MaxValue ? $"({this.distance})" : "") + "[";

            foreach (Edge e in adj.OrderBy(x => x.dest.name)) {
                s += $"{e.dest.name}({e.cost})";

            }   

            s += "]";

            return s;
        }
    }
}