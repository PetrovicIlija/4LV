using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prvi
{
    class Adapter : IAnalytics
    {
        private Analyzer3rdParty analyticsService;
        public Adapter(Analyzer3rdParty service)
        {
            this.analyticsService = service;
        }
        private double[][] ConvertData(Dataset dataset)
        {
            double[][] data = new double[dataset.GetData().Count][];
            List<double> sublist;
            for (int i = 0; i < dataset.GetData().Count; i++)
            {
                sublist = dataset.GetData().ElementAt(i);
                data[i] = new double[sublist.Count];
                for (int j = 0; j < sublist.Count; j++)
                {
                    data[i][j] = sublist[j];
                }
            }
            return data;
        }
        public double[] CalculateAveragePerColumn(Dataset dataset)
        {
            double[][] data = this.ConvertData(dataset);
            return this.analyticsService.PerColumnAverage(data);
        }
        public double[] CalculateAveragePerRow(Dataset dataset)
        {
            double[][] data = this.ConvertData(dataset);
            return this.analyticsService.PerRowAverage(data);
        }
    }

}
