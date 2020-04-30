using System;
using System.IO;
using System.Text;

namespace drugi
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.Append("0.1, 0.2, 0.3, 0.4, 0.5\n1.1, 1.2, 1.3, 1.4, 1.5\n2.1, 2.2, 2.3, 2.4, 2.5");
            File.AppendAllText("C:\\users\\ilija\\test.csv", csvContent.ToString());
            Dataset dataset = new Dataset("C:\\users\\ilija\\test.csv");
            Analyzer3rdParty analyzer = new Analyzer3rdParty();
            IAnalytics analytics = new Adapter(analyzer);
            double[] columnAverages = analytics.CalculateAveragePerColumn(dataset);
            double[] rowAverages = analytics.CalculateAveragePerRow(dataset);
            for (int i = 0; i < columnAverages.Length; i++)
            {
                Console.WriteLine(columnAverages[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < rowAverages.Length; i++)
            {
                Console.WriteLine(rowAverages[i]);
            }
        }
    }
}
