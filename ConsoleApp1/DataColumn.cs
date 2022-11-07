using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// колонка данных
    /// </summary>
    public class DataColumn
    {
        #region Fields
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
            while (d < stop)
            {
                Items.Add(d);
                d += step;
            }
        }

        public void Linspace(double start, int N, double stop)
        {
            double step = (stop - start) / N;
            Arange(start, step, stop);
        }

        public void Seq(double start, double step, int N)
        {
            Items.Clear();
            for (int i = 0; i < N; i++)
            {
                Items.Add((double)i * step + start);
            }
        }

        public void Fill(double d, int N) => Seq(d, 0, N);
        public void Zeros(int N) => Fill(0, N);
        public void Ones(int N) => Fill(1, N);
        #endregion

        #region Out to Table
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
            for (int i = Items.Count - n; i < Items.Count; i++)
            {
                sb.AppendLine($"{Items[i]}");
            }
            sb.Append($"End of {Name} last {n} from {Items.Count}");
            return sb.ToString();
        }
        public string Table(int nStart = 5, int nFromEnd = 5)
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

        #region Out to string and to file
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

        public void ToFile(string ext = "txt")
        {
            // если файл открыт в Excel, то будет исключение
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Name);
                foreach (var item in Items)
                {
                    sb.AppendLine($"{item}");
                }
                System.IO.File.WriteAllText($"{Name}.{ext}", sb.ToString());
            }
            catch
            {
                Console.WriteLine("Ошибка создания файла или записи в файл");
            }
        }
        public void ForEach(Action<double> func)
        {
            Items.ForEach(func);
        }


        #endregion

        #region Random data

        /// <summary>
        /// затравка
        /// </summary>
        private int Seed = 0;
        /// <summary>
        /// генератор случайных чисел (стандартный)
        /// </summary>
        private Random r = new Random();

        /// <summary>
        /// заполнить десятичными дробями от 0 до 1
        /// </summary>
        /// <param name="n">объем выборки</param>
        /// <param name="newSeed"></param>
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
        /// <summary>
        /// заполнить целыми числами
        /// </summary>
        /// <param name="n">объем выборки</param>
        /// <param name="newSeed"></param>
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
        /// <summary>
        /// заполнить целыми числами от 0 до максимального числа не включая
        /// </summary>
        /// <param name="MaxValue">максимальное число</param>
        /// <param name="n">объем</param>
        /// <param name="newSeed"></param>
        public void RandomInt(int MaxValue, int n, int newSeed = 0)
        {
            Seed = newSeed;
            Items.Clear();
            r = new Random(Seed);
            for (int i = 0; i < n; i++)
            {
                Items.Add(r.Next(MaxValue));
            }
        }
        /// <summary>
        /// заполнить целыми числами от 0 до MaxValue не включая
        /// вывести на экран псевдографику
        /// </summary>
        /// <param name="MaxValue">максимальное число</param>
        /// <param name="n">объем выборки</param>
        /// <param name="newSeed"></param>
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
                Console.WriteLine(new string('=', j));
            }
        }
        /// <summary>
        /// заполнить целыми числами в диапазоне MinValue (включая) MaxValue (не включая)
        /// </summary>
        /// <param name="MinValue">от</param>
        /// <param name="MaxValue">до</param>
        /// <param name="n">объем</param>
        /// <param name="newSeed"></param>
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
        
        /// <summary>
        /// заполнить равномерно распределенными числами от from и до to
        /// </summary>
        /// <param name="from">от</param>
        /// <param name="to">до</param>
        /// <param name="N">объем</param>
        /// <param name="NewSeed"></param>
        public void RandomUniform(double from, double to, int N, int NewSeed = 0)
        {
            double h = (to - from);
            Items.Clear();
            Seed = NewSeed;
            r = new Random(Seed);
            for (int i = 0; i < N; i++)
            {
                // от from до from+h = to
                double d = from + h * r.NextDouble();
                Items.Add(d);
            }
        }
        
        /// <summary>
        /// генерирует одно число, распределенное по стандартному нормальному закону распределения
        /// </summary>
        /// <returns>нормально распределенное число</returns>
        private double NormalRandomStd()
        {
            /// https://stackoverflow.com/questions/218060/random-gaussian-variables
            /// Jarrett's suggestion of using
            /// a Box-Muller transform
            /// is good for a quick-and-dirty solution.
            /// A simple implementation:
            double u1 = 1.0 - r.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - r.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                   Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            return randStdNormal;
        }
        /// <summary>
        /// заполнить числами, распределенными по нормальному закону распределения
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="sd"></param>
        /// <param name="N"></param>
        /// <param name="NewSeed"></param>
        public void RandomNormal(double mean, double sd, int N, int NewSeed = 0)
        {
            Items.Clear();
            Seed = NewSeed;
            r = new Random(Seed);

            for (int i = 0; i < N; i++)
            {
                double d = NormalRandomStd();
                d = (d*sd)+mean;
                Items.Add(d);
            }
        }
        #endregion

        #region Операторы

        public DataColumn Copy()
        {
            DataColumn res = new DataColumn();
            res.Name = Name;
            double[] a = new double[Items.Count];
            Items.CopyTo(a);
            res.Items.AddRange(a);
            res.Seed = Seed;
            res.r = new Random();
            return res;
        }

        public DataColumn()
        {
        }

        public DataColumn(DataColumn dc)
        {
            Name = dc.Name;
            double[] a = new double[dc.Items.Count];
            dc.Items.CopyTo(a);
            Items.AddRange(a);
            Seed = dc.Seed;
            r = new Random();
        }

        /// <summary>
        /// унарный оператор + возвращает копию колонки
        /// </summary>
        /// <param name="dc">копируемая колонка</param>
        /// <returns>копия колонки</returns>
        public static DataColumn operator +(DataColumn dc) => new DataColumn(dc);

        public static DataColumn operator -(DataColumn dc) => dc*(-1.0);

        /// <summary>
        /// бинарный оператор + возвращает копию колонки и плюсует к ее данным константу
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="x">константа для прибавления</param>
        /// <returns>новая колонка</returns>
        public static DataColumn operator +(DataColumn dc, double x)
        {
            DataColumn res = new DataColumn(dc);
            for (int i = 0; i < dc.Items.Count; i++)
            {
                res.Items[i] += x;
            }
            return res;
        }

        public static DataColumn operator *(DataColumn dc, double x)
        {
            DataColumn res = new DataColumn(dc);
            for (int i = 0; i < dc.Items.Count; i++)
            {
                res.Items[i] *= x;
            }
            return res;
        }
        public static DataColumn operator /(DataColumn dc, double x) =>dc*(1.0/x);

        /// <summary>
        /// применение к колонке функции одного переменного
        /// 
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public DataColumn ApplyFunc(Func<double, double> func)
        {
            DataColumn res = new DataColumn(this);
            for (int i = 0; i < res.Items.Count; i++)
            {
                res.Items[i] = func(res.Items[i]);
            }
            return res;

        }

        public DataColumn Diff(int delta = 1)
        {
            DataColumn res = new DataColumn(this);
            for (int i = delta; i < res.Items.Count; i++)
            {
                res.Items[i] -= Items[i-delta];
            }
            return res;
        }

        public DataColumn MA(int window = 6)
        {
            DataColumn res = new DataColumn(this);
            for (int i = 0; i < res.Items.Count - window; i++)
            {
                double sum = 0;
                for (int j = 0; j < window; j++)
                {
                    sum += res.Items[i + j];
                }
                res.Items[i] = sum/(double)window;
            }

            double ma = res.Items[res.Items.Count - window - 1];
            for (int i = res.Items.Count - window; i < res.Items.Count - window; i++)
            {
                res.Items[i] = ma;
            }
            return res;
        }
        #endregion

    }


}
