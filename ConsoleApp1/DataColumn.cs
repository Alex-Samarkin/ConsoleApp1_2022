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
        #region MyRegion
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
        #endregion

        #region Fill
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
        #endregion

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

        #region Table
        public string Head(int n = 5)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Start of {Name} first {n} from {Items.Count}");
            for (int i = 0; i < n; i++)
            {
                sb.AppendLine($"{Items[i]}");
            }
            return sb.ToString();
        }
        public string Tail(int n = 5)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = Items.Count-n; i < Items.Count; i++)
            {
                sb.AppendLine($"{Items[i]}");
            }
            sb.Append($"End of {Name} last {n} from {Items.Count}");
            return sb.ToString();
        }
        public string Table(int nStart=5, int nFromEnd=5)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('=', 24));
            sb.AppendLine(Head(nStart));
            sb.AppendLine("...");
            sb.AppendLine(Tail(nFromEnd));
            sb.AppendLine(new string('=', 24));
            return sb.ToString();
        }
        #endregion

        public void ForEach(Action<double> func)
        {
            Items.ForEach(func);
        }

        private int Seed = 0;
        private Random r = new Random();

        public void Random(int n, int newSeed = 0)
        {
            Seed = newSeed;
            Items.Clear();
            r = new Random(Seed);
            for (int i = 0; i < n; i++)
            {
                Items.Add(r.NextDouble());
            }
        }
        public void RandomInt(int n, int newSeed = 0)
        {
            Seed = newSeed;
            Items.Clear();
            r = new Random(Seed);
            for (int i = 0; i < n; i++)
            {
                Items.Add(r.Next());
            }
        }
        public void RandomInt(int MaxValue,int n, int newSeed = 0)
        {
            Seed = newSeed;
            Items.Clear();
            r = new Random(Seed);
            for (int i = 0; i < n; i++)
            {
                Items.Add(r.Next(MaxValue));
            }
        }
        public void RandomIntPrint(int MaxValue, int n, int newSeed = 0)
        {
            Seed = newSeed;
            Items.Clear();
            r = new Random(Seed);
            for (int i = 0; i < n; i++)
            {
                int j = r.Next(MaxValue);
                Items.Add(j);
                Console.Write($"{i,4} {j,4} |");
                Console.WriteLine(new string('=',j));
            }
        }
        public void RandomInt(int MinValue, int MaxValue, int n, int newSeed = 0)
        {
            Seed = newSeed;
            Items.Clear();
            r = new Random(Seed);
            for (int i = 0; i < n; i++)
            {
                Items.Add(r.Next(MinValue, MaxValue));
            }
        }


    }
}
