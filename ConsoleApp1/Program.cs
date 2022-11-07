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
            Console.WriteLine(dc.Table());
            //
            dc.RandomIntPrint(120,1000);
            Console.ReadLine();
            //
            dc.Name = "uniform";
            dc.RandomUniform(0,100,1000);
            dc.ToFile("csv");
            //
            dc.Name = "normal";
            dc.RandomNormal(-2, 3, 1000, 100);
            dc = dc+2;
            dc.ToFile("csv");

            DataColumn dc2 = dc.ApplyFunc(Math.Abs)+0.1;

            dc2 = dc2.ApplyFunc(Math.Log);

            dc2.Name = "abs_log_dc";
            dc2.ToFile("csv");

            DescrStat ds = new DescrStat();
            ds.DataColumn = dc2;
            ds.SortData();
            Console.WriteLine($"Min {ds.Min} Max {ds.Max} Median {ds.Median} Mean {ds.Mean} StdDev {ds.StdDev}");
            Console.ReadLine();
            DataColumn h = ds.Histogram();
            h.ToFile("csv");
        }
    }
}
