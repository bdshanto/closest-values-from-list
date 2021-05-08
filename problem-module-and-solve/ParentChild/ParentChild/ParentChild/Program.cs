using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static System.Console;

namespace ParentChild
{
    class Program
    {
        static void Main1(string[] args)
        {
            // var ar = args;
            // var msg = "Hello world";
            // WriteLine($"{msg} \n" + " ");
            // var givenValue = 14;
            // var maxLimitValue = 2;
            // var maxNode = 4;
            // var possibleChildren = Math.Floor((double)(givenValue / maxLimitValue));

            // PossibleNodes(out var allChilds, possibleChildren);
            //var result= Combination(allChilds, maxNode);


            int inputBal = 14;
            NodeList ls = new NodeList();
            for (int i = 0; i < inputBal; i++)
            {
                int sum = i + 2;
                if (sum <= 14)
                {
                    ls.Add(sum);
                }

            }
        }

        static List<NmLeaderSrM> Combination(List<NmLeaderSrM> combinations, int maxNode)
        {
            var finalCombinations = new List<NmLeaderSrM>();



            return combinations;
        }

        static void PossibleNodes(out List<NmLeaderSrM> allChilds, double possibleChildren)
        {
            allChilds = new List<NmLeaderSrM>();

            for (int i = 0; i < possibleChildren; i++)
            {
                allChilds.Add(new NmLeaderSrM
                {
                    Id = i,
                    Name = "n_" + i,
                });
            }
        }
        class NmLeaderSrM
        {//wait

            public long Id { get; set; }
            public string Name { get; set; }

            public long? ReferralId { get; set; }
            public long? PlacementId { get; set; }


            public virtual NmLeaderSrM Referral { get; set; }
            public virtual NmLeaderSrM Placement { get; set; }

            public virtual ICollection<NmLeaderSrM> ReferredLeaders { get; set; } = new List<NmLeaderSrM>();
            public virtual ICollection<NmLeaderSrM> Associates { get; set; } = new List<NmLeaderSrM>();


        }

        public class Node
        {
            public int Value { get; set; }
            public Node[] Nexts { get; set; } = null;

        }
        public class NodeList
        {
            public int Size = 0;
            Node Head = null;
            Node Tail = null;

            // Default LinkedList add approach ; => AddLast
            public void Add(int param)
            {
                // For every : Cases 
                Node node = new Node();
                node.Value = param;

                // => O(1)
                if (Head == null)
                {
                    // exe only first time when head is null

                    Node[] nodes = new Node[4];
                    Head = node;

                    Tail = node;
                    Tail.Nexts = nodes;
                    Size++;
                }
                else
                {
                    int count = 0;
                    Node currentNode = Head;
                    while (currentNode.Nexts[count] != null)
                    {
                        count++;
                        if (currentNode == null)
                        {
                            break;
                        };
                        currentNode = currentNode?.Nexts[count];
                       
                        
                    }
                    Tail.Nexts[count] = node;
                    Size++;
                  
                    //while (Tail.Nexts[count] == null)
                    //{
                      

                    //}


                    //for (int i = 0; i < 4; i++)
                    //{
                    //    if (Tail.Nexts[i] == null)
                    //    {
                    //        Tail.Nexts[i] = node;
                    //        Size++;
                    //    }
                    //}

                }
            }

            public void ReadAll()
            {
                Node currentNode = Tail;
                int count = 0;

                while (currentNode != null)
                {
                    WriteLine(currentNode.Value.ToString());
                    currentNode = currentNode.Nexts[count];
                    count++;
                }
            }


        }



    }

}
