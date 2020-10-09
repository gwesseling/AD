using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace AD {
    public partial class Path : IComparable<Path> {

        public Vertex dest; // w
        public double cost; // d(w)

        public Path(Vertex d, double c) {
            this.dest = d;
            this.cost = c;
        }

        public int CompareTo([AllowNull] Path other) {
            double otherCost = other.cost;

            return this.cost < otherCost ? -1 : this.cost > otherCost ? 1 : 0;
        }
    }
}
