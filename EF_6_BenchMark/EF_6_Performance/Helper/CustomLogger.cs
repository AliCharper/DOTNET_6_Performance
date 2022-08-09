using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.EF_6_Performance.Helper
{
    public static class CustomLogger
    {
        static Dictionary<DateTime, string> ListOfTimes = new();
        public static void SaveTime(string Message)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fffffff} : {Message}");
            ListOfTimes.Add(DateTime.Now,Message);
        }

        public static void SaveToFile()
        {
            var sb = new StringBuilder();
            ListOfTimes.ToList().ForEach(kvp => sb.AppendLine($"{kvp.Key:HH:mm:ss.fffffff} : {kvp.Value}"));
            var LogWriter = System.IO.File.CreateText(@"C:\temp\BenchMarkLogs.txt");
            LogWriter.Write(sb.ToString());
            LogWriter.Close();
        }

    }
}
