using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        public NmLeaderSrM Get()
        {
            long givenValue = 50000;
            long valueForEachNode = 1500;
            long maxChildOfEachNode = 3;

            var totalNodeCount = Convert.ToInt64(Math.Floor((double)(givenValue / valueForEachNode)));

            IndependentNodes(totalNodeCount, out var singleNodes, valueForEachNode);
            AssignThroughNodes(singleNodes, out var result, maxChildOfEachNode);
            var data = result[0];
            return data;

        }

        private static void AssignThroughNodes(IReadOnlyCollection<NmLeaderSrM> singleNodes, out List<NmLeaderSrM> result, long maxChildOfEachNode)
        {
            result = new List<NmLeaderSrM>();
            var currentRootCounter = 1; // always start from index 1 or first id
            var id = currentRootCounter + 1; // leave first node through all
            var currentRootParent = singleNodes.First();

            while (id <= singleNodes.Count)
            {
                var getSingleNode = singleNodes.FirstOrDefault(sn => sn.LoopThroughId == id);
                if (getSingleNode is not null && currentRootParent is not null)
                {
                    id++;
                    getSingleNode.IsUpNodeConnected = true;
                    getSingleNode.PlacementId = currentRootParent.LoopThroughId;
                    currentRootParent?.Associates.Add(getSingleNode);
                }

                if (currentRootParent?.Associates.Count != maxChildOfEachNode) continue;
                {
                    currentRootCounter++;
                    currentRootParent.IsDownNodeConnected = true;
                    result.Add(currentRootParent);
                    currentRootParent = singleNodes.FirstOrDefault(sn => sn.LoopThroughId == currentRootCounter);
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
                    LoopThroughId = i,
                    Unit = valueForEachNode,
                    Associates = new List<NmLeaderSrM>()
                });
            }

            var isLastValueContain = singleNodes.Any(n => n.LoopThroughId == loopThrough);
            if (!isLastValueContain)
            {
                singleNodes.Add(
                    new NmLeaderSrM { LoopThroughId = loopThrough, Unit = valueForEachNode, Associates = new List<NmLeaderSrM>() });
            }
        }

        public class Node
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
        }

        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
    }
}
