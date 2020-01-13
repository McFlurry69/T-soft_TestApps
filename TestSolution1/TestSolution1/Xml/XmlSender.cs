using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ConnectionLibrary;
using TestSolution1.Models;
using TestSolution1.Xml;

namespace TestSolution1
{
    public static class XmlSender
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Отправка xml файла
        /// </summary>
        /// <param name="path">путь, куда отправить</param>
        /// <param name="data">данные для отправки</param>
        public static void SentXmlFile(string path, List<FullInfo> data)
        {
            XmlFile file = new XmlFile();
            file.ParamValues = new List<ParamValue>();
            
            foreach (FullInfo parameters in data)
            {
                double rndParam = rnd.NextDouble()*10;
                rndParam = Math.Round(rndParam, 2);
                ParamValue paramValue = new ParamValue();
                paramValue.ParamName = parameters.ParamName;
                paramValue.Value = rndParam;
                paramValue.ClientName = parameters.ClientName;
                file.ParamValues.Add(paramValue);
            }
            SerializeXmlFile(file, path);
        }

        /// <summary>
        /// Сериализация xml файла
        /// </summary>
        /// <param name="file">файл для сериализации</param>
        /// <param name="path">Путь к файлу</param>
        public static void SerializeXmlFile(XmlFile file, string path)
        {
            XmlSerializer xSer = new XmlSerializer(typeof(XmlFile));
            
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xSer.Serialize(fs, file);
            }
        }

        /// <summary>
        /// Десериализация xml файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>файл класа XmlFile</returns>
        public static XmlFile ReadXmlFile(string path)
        {
            XmlFile file = new XmlFile();

            XmlSerializer serializer = new XmlSerializer(typeof(XmlFile));

            using (StreamReader reader = new StreamReader(path))
            {
                return file = (XmlFile)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Удваение параметров на стророне клиента
        /// </summary>
        /// <param name="pathTo">Путь к файлу</param>
        /// <param name="file">Файл с исходными данными</param>
        /// <returns>Список параметров</returns>
        public static List<ParamValue> EditXmlFile(string pathTo, List<ParamValue> file)
        {
            XmlFile x = new XmlFile();

            x.ParamValues = new List<ParamValue>();

            foreach (var item in file)
            {
                x.ParamValues.Add(new ParamValue
                {
                    Value = item.Value * 2,
                    ClientName = item.ClientName,
                    ParamName = item.ParamName
                });
            }
            
            SerializeXmlFile(x, pathTo);
            return x.ParamValues;
        }
    }
}