using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;

namespace TestSolution23.ViewModels
{
    public class SecondChartViewModel : Screen
    {
        public SeriesCollection SeriesCollection { get; set; } //Переменная для передачи значений диаграмме
        public Func<ChartPoint, string> PointLabel { get; set; } // Массив легенды
        /// <summary>
        /// Построение круговой диаграммы
        /// </summary>
        /// <param name="_path">Путь к cs файлу</param>
        public SecondChartViewModel(string _path)
        {
            if (_path == null) throw new ArgumentNullException(nameof(_path));
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            List<ChartClass> chart = Helper.CsvMonthReader(_path); // Массив данных для построения

            SeriesCollection = new SeriesCollection();
            foreach (var item in chart)
            {
                //Добавление данных в переменную 
                SeriesCollection.Add(new PieSeries
                {
                    Title = item.Month,
                    Values = new ChartValues<int> {item.Money},
                    DataLabels = true,
                    LabelPoint = PointLabel,
                });
            }
        }
    }
}