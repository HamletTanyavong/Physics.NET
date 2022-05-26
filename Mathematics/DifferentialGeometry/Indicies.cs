using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.NET.Mathematics.DifferentialGeometry;
using Physics.NET.Mathematics.DifferentialGeometry.Metrics;

namespace Physics.NET.Mathematics.DifferentialGeometry
{
    /// <summary>
    /// Indicies with delimiters '^' and '_'.
    /// </summary>
    public class Indicies : ITensor
    {
        public int Rank { get; set; }
        private string[,] IndexArray { get; set; }

        public Indicies(params string[] indicies)
        {
            Rank = indicies.Length;
            IndexArray = new string[2, Rank];

            for (int i = 0; i < Rank; i++)
            {
                if (indicies[i][0] is '^')
                {
                    IndexArray[0, i] = indicies[i][1..];
                }
                else
                {
                    IndexArray[1, i] = indicies[i][1..];
                }
            }
        }

        public Indicies(string[,] indicies)
        {
            Rank = indicies.GetLength(1);
            IndexArray = indicies;
        }

        public void Raise<T>(T metric, string index)
            where T : IMetric
        {

        }

        public void Lower<T>(T metric, string index)
            where T : IMetric
        {

        }

        public string this[int index1, int index2]
        {
            get => IndexArray[index1, index2];
            set => IndexArray[index1, index2] = value;
        }
    }
}
