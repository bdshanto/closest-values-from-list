using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static System.Console;

namespace Try
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            const int loopThrough = 11;
            IndependentNodes(loopThrough, out var singleNodes);
            AssignThroughNodes(singleNodes, out var result);

        }

        private static void AssignThroughNodes(IReadOnlyCollection<Node> singleNodes, out List<Node> result)
        {
            result = new List<Node>();
            var currentRootCounter = 1; // always start from index 1 or first id
            var id = currentRootCounter + 1; // leave first node through all
            var currentRootParent = singleNodes.First();

            while (id <= singleNodes.Count)
            {
                var getSingleNode = singleNodes.FirstOrDefault(sn => sn.Id == id);
                if (getSingleNode is not null && currentRootParent is not null)
                {
                    id++;
                    getSingleNode.IsUpNodeConnected = true;
                    getSingleNode.ParentId = currentRootParent.Id;
                    currentRootParent?.Nodes.Add(getSingleNode);
                }
                
                if (currentRootParent?.Nodes.Count != 4) continue;
                {
                    currentRootCounter++;
                    currentRootParent.IsDownNodeConnected = true;
                    result.Add(currentRootParent);
                    currentRootParent = singleNodes.FirstOrDefault(sn => sn.Id == currentRootCounter);
                }
            }
            
            result.Add(currentRootParent);
        }

        private static void IndependentNodes(int loopThrough, out List<Node> singleNodes)
        {
            singleNodes = new List<Node>();
            // Single increment
            for (var i = 1; i <= loopThrough; i++)
            {
                singleNodes.Add(new Node
                {
                    Id = i,
                    Value = i,
                    Nodes = new List<Node>()
                });
            }

            var isLastValueContain = singleNodes.Any(n => n.Value == loopThrough);
            if (!isLastValueContain)
            {
                singleNodes.Add(
                    new Node {Id = 1 + singleNodes.Last().Id, Value = loopThrough, Nodes = new List<Node>()});
            }
        }

        public record Node
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public int Value { get; set; }
            public bool IsUpNodeConnected { get; set; }
            public bool IsDownNodeConnected { get; set; }
            public List<Node> Nodes { get; set; }
            public bool IsRootNode { get; set; }

            public Node()
            {
                Nodes = new List<Node>();
            }
        }
    }
}