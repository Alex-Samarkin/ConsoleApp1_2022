using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// колонка данных
    /// </summary>
    public class DataColumn
    {
        /// <summary>
        /// имя колонки 
        /// </summary>
        public string Name { get; set; } = "Data1";

        /// <summary>
        /// данные в колонке (реализованы в виде списка десятичных дробей)
        /// на этом этапе создается лист, в котором нет данных
        /// </summary>
        public List<double> Items { get; set; } = new List<double>();

        /// <summary>
        /// добавление переменной
        /// </summary>
        /// <param name="d">переменная, которая добавляется к списку</param>
        public void Add(double d) => Items.Add(d);

        /// <summary>
        /// заполнить интервал от start до stop с шагом step
        /// </summary>
        /// <param name="start">начальное значение (включительно)</param>
        /// <param name="step">шаг</param>
        /// <param name="stop">конечное значение (не включая)</param>
        public void Arange(double start, double step, double stop)
        {
            Items.Clear();
            double d = start;
            while (d<stop)
            {
                Items.Add(d);
                d += step;
            }
        }

        public void Linspace(double start, int N, double stop)
        {
            double step = (stop-start) / N;
            Arange(start,step,stop);
        }

        public void Seq(double start, double step, int N)
        {
            Items.Clear();
            for (int i = 0; i < N; i++)
            {
                Items.Add((double)i*step+start);
            }
        }

        public void Fill(double d, int N) => Seq(d, 0, N);
        public void Zeros(int N) => Fill(0, N);
        public void Ones(int N) => Fill(1, N);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            foreach (double d in Items)
            {
                sb.AppendLine($"{d}");
            }
            return sb.ToString();
        }
    }
}
