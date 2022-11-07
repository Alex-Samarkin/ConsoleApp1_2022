using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DescrStat
    {
        public string Name { get; set; } = "Descriptive statistics";
        public DataColumn DataColumn { get; set; } = new DataColumn();
        private DataColumn sortedColumn = null;
        public int Count => DataColumn.Items.Count;

        public void SortData()
        {
            sortedColumn = new DataColumn(DataColumn);
            sortedColumn.Items.Sort();
        }

        public double Min => sortedColumn.Items[0];
        public double Max => sortedColumn.Items[DataColumn.Items.Count - 1];
        public double Median => sortedColumn.Items[(int)(DataColumn.Items.Count / 2)];

        public double LQ => sortedColumn.Items[(int)(DataColumn.Items.Count / 4)];
        public double HQ => sortedColumn.Items[(int)(DataColumn.Items.Count / 4*3)];

        public double Range => (Max - Min);
        public double IQRange => (HQ - LQ);

        public double Sum()
        {
            double res = 0;
            foreach (double item in sortedColumn.Items)
            {
                res += item;
            }

            return res;
        }
        public double Sum2(double mean=0)
        {
            double res = 0;
            foreach (double item in sortedColumn.Items)
            {
                res += (item-mean)*(item-mean);
            }

            return res;
        }

        public double Mean => Sum() / (double)Count;
        /// <summary>
        /// самостоятельно
        /// </summary>
        // public double Disp => Sum2(Mean)/((double)Count-1.0);
        public double Var
        {
            get
            {
                var m = Mean; 
                return Sum2(m) / ((double)Count - 1.0);
            }
        }

        // public double StdDev => 1;
        public double StdDev => Math.Sqrt(Var);

        /// <summary>
        /// после обсуждения
        /// </summary>
        /// <returns></returns>
        public DataColumn Histogram(int Bins = 0)
        {
            if (Bins < 2)
            {
                Bins = (int)(3.2 * Math.Log(Count) + 1.0);
            }
            double h = Range / (double)(Bins-1);
            DataColumn hist = new DataColumn();
            hist.Name = $"Histogramm of {sortedColumn.Name}";
            for (int i = 0; i < Bins; i++)
            {
                double h0 = Min - h / 2 + h * i;
                double h1 = h0+h;
                int j = 0;
                while (sortedColumn.Items[j]<h1)
                {
                    j++;
                    if(j>= Count) break;
                }
                hist.Add(j);
            }

            hist = hist.Diff();
            return hist;
        }
    }
}
