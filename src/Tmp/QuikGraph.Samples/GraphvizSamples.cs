using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using QuickGraph.Graphviz;
using QuikGraph;
using QuikGraph.Graphviz;

namespace QuickGraph.Samples
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class GraphvizSamples
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void RenderGraphWithGraphviz()
        {
            var edges = new SEdge<int>[] { 
                new SEdge<int>(1, 2), 
                new SEdge<int>(0, 1),
                new SEdge<int>(0, 3),
                new SEdge<int>(2, 3)
            };
            var graph = edges.ToAdjacencyGraph<int, SEdge<int>>();
            Console.WriteLine(graph.ToGraphviz());
        }
    }
}
