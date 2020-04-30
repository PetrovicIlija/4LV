using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace drugi
{
    class Analyzer3rdParty
    {
        public double[] PerRowAverage(double[][] data)
        {
            int rowCount = data.Length;
            double[] results = new double[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                results[i] = data[i].Average();
            }
            return results;
        }
        public double[] PerColumnAverage(double[][] data)
        {
            int columnCount = data.GroupBy(row => row.Length).Single().Key;
            double[] results = new double[columnCount];
            double columnSum;
            for (int j = 0; j < columnCount; j++)
            {
                columnSum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    columnSum += data[i][j];
                }
                results[j] = columnSum / data.Length;
            }
            return results;
        }
    }
}
