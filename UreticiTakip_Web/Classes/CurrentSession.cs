using Entities.Models;
using System;
using System.Web;


namespace UreticiTakip_Web.Classes
{
    public enum SessionKeys
    {
        UreticiId,
        Uretici,
        Kullanici,
        FilterDate_Start,
        FilterDate_End,
        UreticiOdemeler,
        SecilenYil,
        Sofor,
        SoforKodu,
        NakliyeBolge,
        NakliyePlaka,
        Exception,
        Admin,
        MezatGorevlisi
    }

    public class CurrentSession
    {
        public static URETICILER Uretici
        {
            get
            {
                URETICILER a = Get<URETICILER>(SessionKeys.Uretici);

                if (a == default(URETICILER))
                {
                    return null;
                }
                else
                {
                    return a;
                }
            }
        }

        public static int UreticiID
        {
            get
            {
                URETICILER Uretici = Get<URETICILER>(SessionKeys.Uretici);

                if (Uretici == null)
                {
                    return 0;
                }
                else
                {
                    return Uretici.URETICI_ID;
                }
            }
        }

        


        public static DateTime FilterDate_Start
        {
            get
            {
                DateTime date = (DateTime)Get(SessionKeys.FilterDate_Start);

                
                // Normal görüntülemede kontrol amaçlı idi ama gecmiş kayıtlar problem çıkardı.
                //if (date.Year != DateTime.Now.Year)
                //{
                //    date = DateTime.Now;
                //}

                return date;
            }
        }

        public static DateTime FilterDate_End
        {
            get
            {
                DateTime date = (DateTime)Get(SessionKeys.FilterDate_End);

                // Normal görüntülemede kontrol amaçlı idi ama gecmiş kayıtlar problem çıkardı.
                //if (date.Year != DateTime.Now.Year)
                //{
                //    date = DateTime.Now;
                //}

                return date;
            }
        }



        public static void Set<T>(SessionKeys key, T obj)
        {
            HttpContext.Current.Session[key.ToString()] = obj;
        }

        public static object Get(SessionKeys key)
        {
            if (HttpContext.Current.Session[key.ToString()] != null)
            {
                return HttpContext.Current.Session[key.ToString()];
            }

            return null;
        }

        public static T Get<T>(SessionKeys key)
        {
            if (HttpContext.Current.Session[key.ToString()] != null)
            {
                return (T)HttpContext.Current.Session[key.ToString()];
            }

            return default(T);
        }

        public static void Remove(SessionKeys key)
        {
            if (HttpContext.Current.Session[key.ToString()] != null)
            {
                HttpContext.Current.Session.Remove(key.ToString());
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}