using System;
using System.Collections.Generic;

namespace ChildParent
{
    class Program
    {
        static void Main1(string[] args)
        {
            var givenValue = 14;
            var maxValue = 2;
            var totalNode = givenValue / maxValue;

            var nmLeaderList = new List<NmLeaderSrM>();

            for (int i = 0; i < totalNode; i++)
            {
                nmLeaderList.Add(new NmLeaderSrM
                {
                    Id = i, Name = "n" + i,
                });
            }


            Console.WriteLine("Hello World!");
        }
        
        static void Combination(){
    
        }
    }
 
  
    
   
    
}
