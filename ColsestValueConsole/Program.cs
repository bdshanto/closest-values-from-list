using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ColsestValueConsole
{
  //Find the closest values from list by summation or exact single value
  //Scenario 1: 85, 35, 25, 45, 16, 100
  // Scenario2: 55, 75, 26, 55, 99
  // Scenario 3: 99, 15, 66, 75, 85, 88, 5
  // the expected output of above scenarios are as below
  // Scenario 1: 100
  // Scenario 2: 75, 26 (i.e. 75+26=101)
  // Scenario 3: 85, 15 (i.e. 85+15=100)
  class Program
  {
    public static void Main(string[] args)
    {
      int targetValue = 100;
      var test1 = new List<double> { 85, 35, 25, 45, 16, 100 };
      var test2 = new List<double> { 55, 75, 26, 55, 99 };
      var test3 = new List<double> { 99, 15, 66, 75, 85, 88, 5 };
      var test4 = new List<double> { 1, 1, 1, 1, 1, 1, 5 };

      WriteLine("Find the closest values from list by summation or exact single value  ");

      FindClosest(test1, targetValue);
      FindClosest(test2, targetValue);
      FindClosest(test3, targetValue);
      FindClosest(test4, targetValue);

      ReadKey();


    }

    static void FindClosest(List<double> data, double value)
    {
      Combination(data, out var combinations);
      Print(MinValue(combinations).Where(c => c.Item3 >= value).ToList());
    }


    static void Combination(IReadOnlyList<double> data, out List<Tuple<double, double, double>> tuples)
    {
      tuples = null ?? new List<Tuple<double, double, double>>();
      for (var i = 0; i < data.Count - 1; i++)
      {
        for (var j = data.Count - 1; j >= i; j--)
        {
          if (i == j) continue;
          var sum = data[i] + data[j];
          var tuple = Tuple.Create(data[i], data[j], sum);
          tuples.Add(tuple);
        }
      }
    }

    static IOrderedEnumerable<Tuple<double, double, double>> MinValue(List<Tuple<double, double, double>> combination)
    {
      return combination.OrderBy(c => c.Item3);
    }

    static void Print(List<Tuple<double, double, double>> tuples)
    {
      if (tuples.Count <= 0) WriteLine("Case: pair sum couldn't fill up the target value");
      if (tuples.Count > 0) Write("Case: {0},\t {1},\t Target Value: {2} \n", tuples[0].Item1, tuples[0].Item2, tuples[0].Item3);

    }

  }
}