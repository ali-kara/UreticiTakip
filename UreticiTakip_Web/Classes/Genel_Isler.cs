using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;

namespace UreticiTakip_Web.Classes
{
    public static class Genel_Isler
    {
        private static string GetIP()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
        }
        public static string[] GetFileNames(string path, string filter = null)
        {
            try
            {
                string[] files;

                if (filter == null)
                {
                    files = Directory.GetFiles(path);
                }
                else
                {
                    files = Directory.GetFiles(path, filter);
                }

                for (int i = 0; i < files.Length; i++)
                    files[i] = Path.GetFileName(files[i]);
                return files;
            }
            catch (Exception ex)
            {
                // TODO: Logla
                throw new Exception(ex.ToString());
            }
        }
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string ToCurrency(this decimal decimalValue)
        {
            return $"{decimalValue:C}";
        }
    }
}