using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataColumn dc = new DataColumn();
            dc.Seq(0,0.1,500);
            // output and waiting for Enter key
            Console.WriteLine(dc.ToString());
            Console.WriteLine(dc.Head());
            Console.WriteLine(dc.Tail());
            Console.WriteLine(dc.Table());
            dc.ForEach(x=>Console.Write(x=x*x));
            Console.WriteLine();
            Console.WriteLine(dc.Table());
            Console.ReadLine();
        }
    }
}
