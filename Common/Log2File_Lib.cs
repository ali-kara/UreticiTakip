using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;


namespace UreticiTakip_DAL
{
    public static class Log2File_Lib
    {
        public static string baglan { get; set; } = "Data Source = Data/Logs_DB.db; Version = 3;";
        private static string fileLoc { get; set; } = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\Data/Logs_DB.db");

        public static string LogDosyaKonumGetir()
        {
            return fileLoc;
        }
        //public static List<SubeExceptionLogs> ExceptionGetir()
        //{
        //    List<SubeExceptionLogs> list = new List<SubeExceptionLogs>();
        //    try
        //    {
        //        SQLiteConnection conn = new SQLiteConnection(baglan);
        //        conn.Open();
        //        using (SQLiteDataReader reader = (new SQLiteCommand("SELECT * FROM EXCEPTION_LOGS ORDER BY EXCEPTION_ID DESC", conn)).ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new SubeExceptionLogs()
        //                {
        //                    ExceptionID = Convert.ToInt32(reader["EXCEPTION_ID"].ToString()),
        //                    SubeId = reader["SUBE_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SUBE_ID"]),
        //                    FormAdi = reader["FORM_ADI"].ToString(),
        //                    Message = reader["MESSAGE"].ToString(),
        //                    Stacktrace = reader["STACKTRACE"].ToString(),
        //                    InnerException = reader["INNER_EXCEPTION"].ToString(),
        //                    OlusturmaTarihi = Convert.ToDateTime(reader["OlusturmaTarihi"].ToString()),
        //                    GuncellemeTarihi = Convert.ToDateTime(reader["GuncellemeTarihi"].ToString()),
        //                    SonGuncelleyen = reader["SonGuncelleyen"].ToString(),
        //                });
        //            }
        //        }
        //    } 
        //    catch (Exception exception)
        //    {
        //        Log2Txt(exception, null);
        //    }
        //    return list;
        //}
        public static bool ExceptionSil(int ExceptionId)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(baglan);
                conn.Open();

                SQLiteCommand query = new SQLiteCommand("DELETE FROM EXCEPTION_LOGS WHERE EXCEPTION_ID = @EXCEPTION_ID", conn);

                query.Parameters.AddWithValue("@EXCEPTION_ID", ExceptionId);
                query.ExecuteNonQuery();

                return true;
            }
            catch (Exception exception)
            {
                Log2Txt(exception, null);
                return false;
            }
        }
        public static void Log2File(Exception ex, string FormName = "", int SUBE_ID = 0)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(baglan);
                conn.Open();

                SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO EXCEPTION_LOGS (MESSAGE, STACKTRACE, INNER_EXCEPTION, " +
                    "FORM_ADI, SUBE_ID, OlusturmaTarihi, GuncellemeTarihi, SonGuncelleyen) VALUES (@MESSAGE, @STACKTRACE, " +
                    "@INNER_EXCEPTION, @FORM_ADI, @SUBE_ID, @OlusturmaTarihi, @GuncellemeTarihi, @SonGuncelleyen)", conn);

                insertSQL.Parameters.AddWithValue("@MESSAGE", ex.Message);
                insertSQL.Parameters.AddWithValue("@STACKTRACE", ex.StackTrace);
                insertSQL.Parameters.AddWithValue("@INNER_EXCEPTION", ex.InnerException);
                insertSQL.Parameters.AddWithValue("@FORM_ADI", FormName);
                insertSQL.Parameters.AddWithValue("@SUBE_ID", SUBE_ID);

                SQLiteParameterCollection parameters = insertSQL.Parameters;
                DateTime now = DateTime.Now;

                parameters.AddWithValue("@OlusturmaTarihi", now.ToString());
                parameters.AddWithValue("@GuncellemeTarihi", now.ToString());
                parameters.AddWithValue("@SonGuncelleyen", "ADMIN");

                insertSQL.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Log2Txt(exception, ex);
            }
        }
        public static void Log2Txt(Exception exOfex, Exception ex = null)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLoc = string.Concat(directoryName, "\\Logs\\Log_", DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss"), ".txt");
            Directory.CreateDirectory(string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\Logs"));
            using (FileStream fs = File.Create(fileLoc))
            {
            }
            using (StreamWriter sw = File.AppendText(fileLoc))
            {
                sw.WriteLine(string.Concat(DateTime.Now, " Dosyaya Yazma Hatası:"));
                sw.WriteLine(exOfex.ToString());
                if (ex != null)
                {
                    sw.WriteLine("--------------------------------------------------------------------------------------------");
                    sw.WriteLine(string.Concat(DateTime.Now, " Hata:"));
                    sw.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// İstenen metni Txt dosyasına yazmaya yarar.
        /// </summary>
        /// <param name="Message">İstenen Mesaj parametre olarak gönderilir.</param>
        public static string Log2Txt(string Message,string LogPath = "")
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLoc;

            if (string.IsNullOrEmpty(LogPath))
            {
                fileLoc = string.Concat(directoryName, "\\Logs\\Log_", DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss"), ".txt");

                Directory.CreateDirectory(string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\Logs"));
                using (FileStream fs = File.Create(fileLoc))
                {
                }
            }
            else
            {
                fileLoc = LogPath;
            }

            using (StreamWriter sw = File.AppendText(fileLoc))
            {
                sw.WriteLine("--------------------------------------------------------------------------------------------");
                sw.WriteLine(string.Concat(DateTime.Now) + " :" + Message.ToString());
            }

            return fileLoc;
        }

    }
}