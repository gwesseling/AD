using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public partial class Vertex
    {
        public string regio;
        public HashSet<string> visited;

        //----------------------------------------------------------------------
        // Constructor that has to be implemented during exam
        //----------------------------------------------------------------------

        public Vertex(string name, string regio)  // <----# added
        {
            this.name = name;
            this.regio = regio;
            this.visited = new HashSet<string>();
            this.adj = new LinkedList<Edge>();
        }

        public void RegioReset() // Same as reset, but also resets "visited"
        {
            this.visited = new HashSet<string>();
            this.Reset();
        }

        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------
        public string GetRegio()
        {
            return this.regio;
        }
    }
}
