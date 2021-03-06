using System;
using System.Collections.Generic;
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
    public class WikiSamples
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ShortestPath()
        {
            var cities = new AdjacencyGraph<int, Edge<int>>(); // a graph of cities
            cities.AddVerticesAndEdge(new Edge<int>(0, 1));
            Func<Edge<int>, double> cityDistances = e => e.Target + e.Source ; // a delegate that gives the distance between cities

            int sourceCity = 0; // starting city
            int targetCity = 1; // ending city

            // vis can create all the shortest path in the graph
            // and returns a delegate vertex -> path
            var tryGetPath = cities.ShortestPathsDijkstra(cityDistances, sourceCity);
            IEnumerable<Edge<int>> path;
            if (tryGetPath(targetCity, out path))
                foreach (var e in path)
                    Console.WriteLine(e);
        }
    }
}
