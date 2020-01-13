using System;
using Microsoft.Extensions.Configuration;


namespace ConnectionLibrary
{
    public static class Helper
    {
        /// <summary>
        /// Получение строки подключения из json файла
        /// </summary>
        /// <param name="name"></param>
        /// <returns>строку подключения</returns>
        public static string CnnVal(string name)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString(name);
        }
    }
}
