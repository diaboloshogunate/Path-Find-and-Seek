using NUnit.Framework;
using Runtime;
using Unity.Mathematics;
using UnityEngine;

namespace Tests.Runtime
{
    public class GraphScannerTest
    {
        [Test]
        public void GraphScannerTestSimplePasses()
        {
            GraphScanner scanner = new GraphScanner();
            scanner.Cells = new int2(5, 5);
            scanner.StartPosition = new Vector3(0,0,0);
            scanner.CellSize = new Vector2(1,1);
            scanner.LayerMask = LayerMask.NameToLayer("Default");
            scanner.ConnectionStrategy = GraphScanner.ConnectionStraightness.FOUR;
            scanner.Scan();

            Graph graph = scanner.Graph;
            int expectedCellCount = scanner.Cells.x * scanner.Cells.y;
            int expectedEdgeCount = expectedCellCount * 4;

            Assert.AreEqual(scanner.Cells, graph.Size);
            Assert.AreEqual(expectedCellCount, graph.Nodes.Count);
            Assert.AreEqual(expectedEdgeCount, graph.Edges.Count);
            Assert.IsTrue(graph.Nodes.Contains(new int2(0,0)));
            Assert.IsTrue(graph.Nodes.Contains(new int2(4,4)));
            Assert.IsFalse(graph.Nodes.Contains(new int2(-1,0)));
            Assert.IsFalse(graph.Nodes.Contains(new int2(0,-1)));
            Assert.IsFalse(graph.Nodes.Contains(new int2(5,0)));
            Assert.IsFalse(graph.Nodes.Contains(new int2(0,5)));
            Assert.IsTrue(graph.Edges.Contains(new int4(0,0,1,0)));
            Assert.IsTrue(graph.Edges.Contains(new int4(0,0,0,1)));
            Assert.IsTrue(graph.Edges.Contains(new int4(0,0,-1,0)));
            Assert.IsTrue(graph.Edges.Contains(new int4(0,0,0,-1)));
            Assert.IsFalse(graph.Edges.Contains(new int4(0,0,0,0)));
        }
    }
}