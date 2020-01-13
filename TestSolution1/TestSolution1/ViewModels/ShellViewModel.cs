using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Caliburn.Micro;
using ConnectionLibrary;
using TestSolution1.Models;
using TestSolution1.Xml;

namespace TestSolution1.ViewModels
{
    public class ShellViewModel : Screen
    {
        private static DataAccess da = new DataAccess(); // создание экземяра класса доступа к бд
        private string _clientsInfo = String.Empty;
        private string _paramsInfo = String.Empty;
        private string pathToClient = System.IO.Path.Combine(Environment.CurrentDirectory, @"client.xml"); //путь к файлу "посылаемому" клиенту
        private string pathToServer = System.IO.Path.Combine(Environment.CurrentDirectory, @"server.xml"); //путь к файлу "посылаемому" серверу 
        private List<ParamValue> _readedFromServer = new List<ParamValue>(); // список парамеров, считываемых с сервера
        private List<ParamValue> _readedFromClient = new List<ParamValue>(); // список парамеров, считываемых с клиента
        private List<FullInfo> _allParams = new List<FullInfo>(); //локальная переменная для храенеия параметров


        /// <summary>
        /// Получение данных о клиентах и параметрах, запуск обмена данных
        /// </summary>
        public ShellViewModel()
        {
            int numOfClients = da.GetListOfClients().Count;
            int numOfParams = da.GetListOfParams().Count;
            ClientsInfo = numOfClients != 0 ? $"Количество клиентов: {numOfClients.ToString()}" : "Клиенты отутствуют"; 
            ParamsInfo = numOfParams != 0 ? $"Количество параметров: {numOfParams.ToString()}" : "Параметры отсутствуют";
            AllParams = da.GetFullInfo();
            Change();
        }
        /// <summary>
        /// Отправлять данные с сервера, считывать данные от клиентов
        /// </summary>
        public async void Change()
        {
            Task.Run(async() =>
            {
                while (true)
                {
                    XmlSender.SentXmlFile(pathToServer, AllParams);
                    ReadedFromServer = XmlSender.ReadXmlFile(pathToServer).ParamValues;
                    XmlSender.EditXmlFile(pathToClient, ReadedFromServer);
                    ReadedFromClient = XmlSender.ReadXmlFile(pathToClient).ParamValues;
                    await Task.Delay(5000);
                }
            });
        }

        public string ClientsInfo { get; set; }

        public string ParamsInfo { get; set; }

        public List<FullInfo> AllParams { get; set; }

        public List<ParamValue> ReadedFromServer
        {
            get { return _readedFromServer; }
            set
            {
                _readedFromServer = value;
                NotifyOfPropertyChange();
            }
        }
        
        public List<ParamValue> ReadedFromClient
        {
            get { return _readedFromClient; }
            set
            {
                _readedFromClient = value;
                NotifyOfPropertyChange();
            }
        }

    }
}