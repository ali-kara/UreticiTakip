using System;
using System.IO;
using System.Web;

namespace Common.Logging
{
    public static class Log 
    {
        //public static string FileLoc { get; set; } = System.Reflection.Assembly.GetExecutingAssembly().Location + @"\Exception_Logs.txt";
        public static string FileLoc { get; set; } = HttpRuntime.AppDomainAppPath + "Exception_Logs.txt";

        

        private static void CheckFileExist()
        {
            if (!File.Exists(FileLoc))
            {
                using (FileStream fs = File.Create(FileLoc))
                {

                }
            }
        }

        public static void Log2Txt(Exception ex)
        {
            CheckFileExist();

            using (StreamWriter sw = File.AppendText(FileLoc))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Dosya Yazma Hatası:      " + ex.ToString());
                sw.WriteLine("--------------------------------------------------------------------------------------------");

                sw.WriteLine(DateTime.Now);
                sw.WriteLine(ex.ToString());
                sw.WriteLine("--------------------------------------------------------------------------------------------");

            }
        }
    }
}
