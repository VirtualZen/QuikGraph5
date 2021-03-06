using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using QuickGraph.Algorithms;
using QuikGraph;
using QuikGraph.Algorithms;

namespace QuickGraph.Samples
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public partial class GraphCreation
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void EdgeArrayToAdjacencyGraph()
        {
            var edges = new SEdge<int>[] { 
                new SEdge<int>(1, 2), 
                new SEdge<int>(0, 1) 
            };
            var graph = edges.ToAdjacencyGraph<int, SEdge<int>>();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DelegateGraph()
        {
            // a simple adjacency graph representation
            int[][] graph = new int[5][];
            graph[0] = new int[] { 1 };
            graph[1] = new int[] { 2, 3 };
            graph[2] = new int[] { 3, 4 };
            graph[3] = new int[] { 4 };
            graph[4] = new int[] { };

            // interoping with quickgraph
            var g = GraphExtensions.ToDelegateVertexAndEdgeListGraph(
                Enumerable.Range(0, graph.Length),
                v => Array.ConvertAll(graph[v], w => new SEquatableEdge<int>(v, w))
                );

            // it's ready to use!
            foreach (int v in g.TopologicalSort())
                Console.WriteLine(v);
        }
    }
}
