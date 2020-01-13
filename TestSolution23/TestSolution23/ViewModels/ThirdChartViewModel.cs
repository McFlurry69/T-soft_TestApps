using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;

namespace TestSolution23.ViewModels
{
    public class ThirdChartViewModel : Screen
    {
        public SeriesCollection SeriesCollection { get; set; } //Переменная для передачи значений диаграмме 
        private string _koeff; // Коэффициенты полинома
        private int basis = 3; //количество коэффициентов
        public string[] Labels { get; set; } // Легенда графика
        public Func<double, string> YFormatter { get; set; } // формат легенды
        public string Koeff {
            get { return _koeff; }
            set
            {
                _koeff = value;
                NotifyOfPropertyChange(()=>Koeff);
            }
        }
        /// <summary>
        /// Построение графика функции по точкам
        /// </summary>
        /// <param name="_path">Путь к csv афлу</param>
        public ThirdChartViewModel(string _path)
        {
            if (_path == null) throw new ArgumentNullException(nameof(_path));
            List<AproximationClass> chart = Helper.CsvChartReader(_path);
            ChartValues<int> toAdd = new ChartValues<int>();
            string[] lab = new string[chart.Capacity];
            double[,] xyTable = new double[2, chart.Capacity];
            var matrix = Helper.MakeSystem(xyTable, basis);
            var result = Helper.Gauss(matrix, basis, basis + 1);
            int i = 0;
            
            foreach (var item in chart)
            {
                toAdd.Add((int)item.Y);
                lab[i] = item.X.ToString();
                i++;
                
                xyTable[0, i] = item.X;
                xyTable[1, i] = item.Y;
            }
            
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Chart",
                    Values = toAdd
                }
            };

            for (i = 0; i < basis; i++)
            {
                Koeff += $"Коэффициент {i} = {Math.Round(result[i], 2).ToString()} ";
            }
        }
    }
}
