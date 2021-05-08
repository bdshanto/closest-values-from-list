using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ChildParent;
using static System.Console;

namespace Try
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            long givenValue = 50000;
            long valueForEachNode = 1500;
            long maxChildOfEachNode = 3;

            var totalNodeCount = Convert.ToInt64(Math.Floor((double)(givenValue / valueForEachNode)));

            IndependentNodes(totalNodeCount, out var singleNodes, valueForEachNode);
            AssignThroughNodes(singleNodes, out var result, maxChildOfEachNode);

        }

        private static void AssignThroughNodes(IReadOnlyCollection<NmLeaderSrM> singleNodes, out List<NmLeaderSrM> result, long maxChildOfEachNode)
        {
            result = new List<NmLeaderSrM>();
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
                    getSingleNode.PlacementId = currentRootParent.Id;
                    currentRootParent?.Associates.Add(getSingleNode);
                }

                if (currentRootParent?.Associates.Count != maxChildOfEachNode) continue;
                {
                    currentRootCounter++;
                    currentRootParent.IsDownNodeConnected = true;
                    result.Add(currentRootParent);
                    currentRootParent = singleNodes.FirstOrDefault(sn => sn.Id == currentRootCounter);
                }
            }

            result.Add(currentRootParent);
        }

        private static void IndependentNodes(long loopThrough, out List<NmLeaderSrM> singleNodes, long valueForEachNode)
        {
            singleNodes = new List<NmLeaderSrM>();
            // Single increment
            for (var i = 1; i <= loopThrough; i++)
            {
                singleNodes.Add(new NmLeaderSrM
                {
                    Id = i,
                    Unit = valueForEachNode,
                    Associates = new List<NmLeaderSrM>()
                });
            }

            var isLastValueContain = singleNodes.Any(n => n.Id == loopThrough);
            if (!isLastValueContain)
            {
                singleNodes.Add(
                    new NmLeaderSrM { Id = loopThrough, Unit = valueForEachNode, Associates = new List<NmLeaderSrM>() });
            }
        }

        /*public record Node
        {
            public long Id { get; set; }
            public long ParentId { get; set; }
            public long Value { get; set; }
            public bool IsUpNodeConnected { get; set; }
            public bool IsDownNodeConnected { get; set; }
            public List<Node> Nodes { get; set; }
            public bool IsRootNode { get; set; }

            public Node()
            {
                Nodes = new List<Node>();
            }
        }*/
    }
}