using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Media.Effects;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;

namespace TestSolution23.ViewModels
{
    public class FirstChartViewModel : Screen
    {
        public SeriesCollection SeriesCollection { get; set; }  //Переменная ля передачи значений диаграмме
        public string[] Labels { get; set; } //Значения Y
        private string _path; //Путь к файлу
        public Func<double, string> Formatter { get; set; } //Формат легенды
        
        /// <summary>
        /// Первое окно представления - диаграмма
        /// </summary>
        /// <param name="path">Путь к файлу csv</param>
        public FirstChartViewModel(string path)
        {
            _path = path;
            List<ChartClass> chart = Helper.CsvMonthReader(_path); // Массив с данными
            ChartValues<int> toAdd = new ChartValues<int>(); //Массив значений графика(ось Х)
            string[] lab = new string[chart.Capacity]; //Массив значений графика(ось Y)
            int i = 0; // счетчик

            //Заполнение массивов для постоения диаграммы
            foreach (var item in chart)
            {
                toAdd.Add(item.Money);
                lab[i] = item.Month;
                i++;
            }
            
            //Присвоение данных и передача на диаграмму
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Months",
                    Values =  toAdd
                }
            };
            Labels = lab;
        }
    }
}
