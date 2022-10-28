using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataGen
    {
        public DataColumn DC { get; set; } = new DataColumn() { Name = "Auto generated" };

        #region FillDC 
        public void Arange(double start, double step, double stop)
        {
            DC.Items.Clear();
            double d = start;
            while (d < stop)
            {
                DC.Items.Add(d);
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
            DC.Items.Clear();
            for (int i = 0; i < N; i++)
            {
                DC.Items.Add((double)i * step + start);
            }

        }
        public void Fill(double d, int N) => Seq(d, 0, N);
        public void Zeros(int N) => Fill(0, N);
        public void Ones(int N) => Fill(1, N);
        #endregion

        #region RandomData

        public int Seed { get; set; } = 0;
        public Random Random { get; set; } = new Random();
        public void ResetRandom(int NewSeed = 0)
        {
            Seed = NewSeed;
            Random = new Random(Seed);
        }

        public void NextDouble(int N, int? NewSeed = null)
        {
            DC.Items.Clear();
            if (NewSeed!=null)
            {
                ResetRandom((int)NewSeed);
            }

            for (int i = 0; i < N; i++)
            {
                DC.Add(Random.NextDouble());
            }
        }
        public void Next(int N, int? NewSeed = null)
        {
            DC.Items.Clear();
            if (NewSeed != null)
            {
                ResetRandom((int)NewSeed);
            }

            for (int i = 0; i < N; i++)
            {
                DC.Add(Random.Next());
            }
        }
        public void Next(int MaxValue, int N, int? NewSeed = null)
        {
            DC.Items.Clear();
            if (NewSeed != null)
            {
                ResetRandom((int)NewSeed);
            }

            for (int i = 0; i < N; i++)
            {
                DC.Add(Random.Next(MaxValue));
            }
        }
        public void Next(int MinValue, int MaxValue, int N, int? NewSeed = null)
        {
            DC.Items.Clear();
            if (NewSeed != null)
            {
                ResetRandom((int)NewSeed);
            }

            for (int i = 0; i < N; i++)
            {
                DC.Add(Random.Next(MinValue,MaxValue));
            }
        }

        #endregion

    }
}
