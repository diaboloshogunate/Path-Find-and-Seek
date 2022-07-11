using System.Collections.Generic;
using Unity.Mathematics;

namespace Runtime
{
    public class Graph
    {
        public int2 Size { get; set; }
        public HashSet<int2> Nodes { get; set; } = new HashSet<int2>();
        public HashSet<int4> Edges { get; set; } = new HashSet<int4>();
    }
}