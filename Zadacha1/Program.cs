using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line="", line1 = "";
            StreamReader tr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            while (!tr.EndOfStream)
            {
                line = tr.ReadLine();
                line1 = tr.ReadLine();
            }
            tr.Close();
            string[] s = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = Convert.ToInt32(line);
            List<int> ages = new List<int>();
            List<int> riskes = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (Convert.ToInt32(s[i]) >= 5000) ages.Add(Convert.ToInt32(s[i]));
                else riskes.Add(Convert.ToInt32(s[i]));
            }
            List<Agent> list = new List<Agent>();
            Agent agent;
            for (int i = 0; i < n; i++)
            {
                int age, risk;
                age = ages[i];
                risk = riskes[i];
                agent = new Agent(age, risk);
                list.Add(agent);
            }
            list.Sort();         
            int[] minRisk = new int[n];
            minRisk[1] = list[1].Risk;
            if (2 < n)
            {
                minRisk[2] = list[1].Risk + list[2].Risk;
            }
            if (3 < n)
            {
                minRisk[3] = list[3].Risk + list[1].Risk;
            }
            for (int last = 4; last < n; last++)
            {
                minRisk[last] = Math.Min(minRisk[last - 2] + list[last].Risk, minRisk[last - 3] + list[last - 1].Risk + list[last].Risk);
            }
            sw.WriteLine(minRisk[n - 1]);
            sw.Close();
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
