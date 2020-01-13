using System.IO;
using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic.FileIO;

namespace TestSolution23.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _path = String.Empty; // Путь к csv файлу

        //Диаграмма
        public void LoadChartOne()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            ActivateItemAsync(new FirstChartViewModel(_path), token);
        }
        //Круговая диаграмма
        public void LoadChartTwo()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            ActivateItemAsync(new SecondChartViewModel(_path), token);
        }
        //график 
        public void LoadChartThree()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            ActivateItemAsync(new ThirdChartViewModel(_path), token);
        }
        //открыть файл
        public void BtnOpen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = Path.GetFullPath(openFileDialog.FileName);
            }
        }
        //Путь к файлу
        public string FilePath
        {
            get { return _path; }
            set
            {
                _path = value;
                NotifyOfPropertyChange(()=>FilePath);
            }
        }
    }
}