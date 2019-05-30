using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Agent[] list = new Agent[n];
            Agent agent;
            for (int i = 0; i < n; i++)
            {
                int age, risk;
                age = int.Parse(Console.ReadLine());
                risk = int.Parse(Console.ReadLine());
                agent = new Agent(age, risk);
                list[i] = agent;
            }
            Array.Sort(list);
            int[] minRisk = new int[n];
            minRisk[1] = list[1].Risk;
            if (2 <n)       
            {
                minRisk[2] = list[1].Risk + list[2].Risk;
            }
            if (3<n)
            {
                minRisk[3] = list[3].Risk + list[1].Risk;
            }
            for (int last = 4; last < n; last++)
            {
                minRisk[last] = Math.Min(minRisk[last - 2] + list[last].Risk, minRisk[last - 3] + list[last - 1].Risk + list[last].Risk);
            }
            Console.WriteLine(minRisk[n-1]);          
        }
    }

    class Agent : IComparable
    {
        public int Age { get; set; }
        public int Risk { get; set; }
        public Agent(int age, int risk)
        {
            Age = age;
            Risk = risk;
        }
        public int CompareTo(object obj)
        {
            Agent temp = (Agent)obj;
            if (Age > temp.Age) return 1;
            if (Age < temp.Age) return -1;
            return 0;
        }
    }

}
