using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime
{
    // todo move serialization to a separate file
    // todo use cell class
    // todo scan the scene for cells
    // todo draw debug tools
    public class GraphScanner
    {
        public enum ConnectionStraightness {FOUR, EIGHT}
        public ConnectionStraightness ConnectionStrategy { get; set; }
        public int2 Cells { get; set; }
        public Vector2 CellSize { get; set; }
        public Vector3 StartPosition { get; set; }
        public LayerMask LayerMask { get; set; }
        public Graph Graph { get; set; }

        public void Scan()
        {
            Graph = new Graph() {
                Size = Cells,
            };
            
            for (int x = 0; x < Cells.x; x++)
            {
                for (int y = 0; y < Cells.y; y++)
                {
                    int2 position = new int2(x, y);
                    Graph.Nodes.Add(position);
                    foreach (int4 edge in GetConnections(position))
                    {
                        Graph.Edges.Add(edge);
                    }
                }
            }
        }

        private HashSet<int4> GetConnections(int2 from)
        {
            HashSet<int4> hashSet = new HashSet<int4>();

            if (ConnectionStrategy is ConnectionStraightness.FOUR or ConnectionStraightness.EIGHT)
            {
                hashSet.Add(new int4(from.x, from.y, from.x - 1, from.y));
                hashSet.Add(new int4(from.x, from.y, from.x + 1, from.y));
                hashSet.Add(new int4(from.x, from.y, from.x, from.y - 1));
                hashSet.Add(new int4(from.x, from.y, from.x, from.y + 1));
            }

            if (ConnectionStrategy == ConnectionStraightness.EIGHT)
            {
                hashSet.Add(new int4(from.x, from.y, from.x - 1, from.y - 1));
                hashSet.Add(new int4(from.x, from.y, from.x - 1, from.y + 1));
                hashSet.Add(new int4(from.x, from.y, from.x + 1, from.y - 1));
                hashSet.Add(new int4(from.x, from.y, from.x + 1, from.y + 1));
            }

            return hashSet;
        }
    }
}