using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace TestSolution23
{
    public static class Helper
    {
        /// <summary>
        /// Используется для решения систем линейных алгебраических уравнений методом Гаусса.
        /// </summary>
        /// <param name="matrix">Матрица точек</param>
        /// <param name="rowCount">Количество строк</param>
        /// <param name="colCount">Кличество столбцов</param>
        /// <returns>Решение</returns>
        public static double[] Gauss(double[,] matrix, int rowCount, int colCount)
        {
            int i;
            int[] mask = new int[colCount - 1];
            for (i = 0; i < colCount - 1; i++) mask[i] = i;
            if (GaussDirectPass(ref matrix, ref mask, colCount, rowCount))
            {
                double[] answer = GaussReversePass(ref matrix, mask, colCount, rowCount);
                return answer;
            }
            else return null;
        }
        /// <summary>
        /// Используется для преобразования матрицы к верхнему треугольному виду.
        /// </summary>
        /// <param name="matrix">Матрица точек</param>
        /// <param name="mask">Маска перестановок матрицы</param>
        /// <param name="colCount">Кличество столбцов</param>
        /// <param name="rowCount">Количество строк</param>
        /// <returns></returns>
        private static bool GaussDirectPass(ref double[,] matrix, ref int[] mask, int colCount, int rowCount)
        {
            int i, j, k, maxId, tmpInt;
            double maxVal, tempDouble;
            for (i = 0; i < rowCount; i++)
            {
                maxId = i;
                maxVal = matrix[i, i];
                for (j = i + 1; j < colCount - 1; j++)
                    if (Math.Abs(maxVal) < Math.Abs(matrix[i, j]))
                    {
                        maxVal = matrix[i, j];
                        maxId = j;
                    }

                if (maxVal == 0) return false;
                if (i != maxId)
                {
                    for (j = 0; j < rowCount; j++)
                    {
                        tempDouble = matrix[j, i];
                        matrix[j, i] = matrix[j, maxId];
                        matrix[j, maxId] = tempDouble;
                    }

                    tmpInt = mask[i];
                    mask[i] = mask[maxId];
                    mask[maxId] = tmpInt;
                }

                for (j = 0; j < colCount; j++) matrix[i, j] /= maxVal;
                for (j = i + 1; j < rowCount; j++)
                {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++) matrix[j, k] -= matrix[i, k] * tempMn;
                }
            }

            return true;
        }
        /// <summary>
        /// Используется для нахождения фундаментальной системы решений.
        /// </summary>
        /// <param name="matrix">Матрица точек</param>
        /// <param name="mask">Маска перестановок матрицы</param>
        /// <param name="colCount">Кличество столбцов</param>
        /// <param name="rowCount">Количество строк</param>
        /// <returns>Массив решений</returns>
        private static double[] GaussReversePass(ref double[,] matrix, int[] mask, int colCount, int rowCount)
        {
            int i, j, k;
            for (i = rowCount - 1; i >= 0; i--)
            for (j = i - 1; j >= 0; j--)
            {
                double tempMn = matrix[j, i];
                for (k = 0; k < colCount; k++) matrix[j, k] -= matrix[i, k] * tempMn;
            }

            double[] answer = new double[rowCount];
            for (i = 0; i < rowCount; i++) answer[mask[i]] = matrix[i, colCount - 1];
            return answer;
        }
        
        public static double[,] MakeSystem(double[,] xyTable, int basis)
        {
            double[,] matrix = new double[basis, basis + 1];
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    double sumA = 0, sumB = 0;
                    for (int k = 0; k < xyTable.Length / 2; k++)
                    {
                        sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
                        sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
                    }
                    matrix[i, j] = sumA;
                    matrix[i, basis] = sumB;
                }
            }
            return matrix;
        }
        /// <summary>
        /// Метод преобразует csv файл в лист требуемого формата (месяц, расходы)
        /// </summary>
        /// <param name="path">Путь к csv файлу</param>
        /// <returns>Перечень данных фармата: месяц, расходы за месяц</returns>
        public static List<ChartClass> CsvMonthReader(string path)
        {
            List<ChartClass> months = new List<ChartClass>();
            if (path == null)
                return null;
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields().Where(u => u != "Month;Money").ToArray();

                    foreach (var field in fields)
                    {
                        var d = new ChartClass();
                        string[] row = field.Split(";");
                        foreach (var element in row)
                        {
                            if (int.TryParse(element, out var result))
                            {
                                d.Money = result;
                            }
                            else
                            {
                                d.Month = element;
                            }
                        }
                        months.Add(d);
                    }

                    
                }
            }
            return months;
        }
        /// <summary>
        /// Метод преобразует csv файл в лист точек(для задания с апроксимацией)
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Перечень точек графика</returns>
        public static List<AproximationClass> CsvChartReader(string path)
        {
            List<AproximationClass> dots = new List<AproximationClass>();
            if (path == null)
                return null;
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields().Where(u => u != "X;Y").ToArray();

                    foreach (var field in fields)
                    {
                        var d = new AproximationClass();
                        string[] row = field.Split(";");
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (i % 2 == 0 && int.TryParse(row[i], out var resultX))
                            {
                                d.X = resultX;
                            }

                            if (i % 2 != 0 && int.TryParse(row[i], out var resultY))
                            {
                                d.Y = resultY;
                            }
                        }
                        dots.Add(d);
                    }

                    
                }
            }
            return dots;
        }
    }
}
