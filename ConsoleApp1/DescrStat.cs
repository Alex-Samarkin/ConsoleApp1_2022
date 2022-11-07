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
        public double Disp => 1;
        public double StdDev => 1;

        /// <summary>
        /// после обсуждения
        /// </summary>
        /// <returns></returns>
        public DataColumn Histogram()
        {
            return new DataColumn();
        }
    }
}
