using Common.Utilities.Results;
using Entities;
using Entities.Log.Models;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Managers
{
    public class UreticiManager : BaseManager<URETICILER, FloratediyeDBEntities>
    {
        public List<URETICILER> UreticileriSehreGoreGetir(string Sehir)
        {
            List<URETICILER> list = GetList(x => x.IL == Sehir);

            return list;
        }
        public List<Country> UreticiSehirleriGetir()
        {
            List<Country> list = GetIEnum().GroupBy(x => x.IL)
                .Select(x =>
                new Country
                {
                    CountryName = x.Key.ToString()
                })
                .ToList();

            list = list.Where(x => !string.IsNullOrWhiteSpace(x.CountryName))
                .Distinct()
                .ToList();

            return list;
        }

        public URETICILER Login(string URETICI_NO, string Parola)
        {
            URETICILER uretici = Get(x => x.URETICI_NO == URETICI_NO && x.Parola == Parola);
            return uretici;
        }

        public URETICILER GetById(string URETICI_NO)
        {
            URETICILER uretici = Get(x => x.URETICI_NO == URETICI_NO);
            return uretici;
        }

        //List<URETICILER> list { get; set; }
        //URETICILER uretici { get; set; }

        //public List<URETICILER> GetAll()
        //{
        //    list = new List<URETICILER>();

        //    using (connection)
        //    {
        //        connection.Open();

        //        string conString = "SELECT * FROM URETICILER WHERE URETICI_NO = @URETICI_NO";

        //        SqlCommand cmd = new SqlCommand(conString, connection);

        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            uretici = new URETICILER();
        //            uretici = Uretici_Parse(reader);

        //            list.Add(uretici);
        //        }

        //        while (reader.Read())
        //        {
        //            list.Add(new URETICILER
        //            {
        //                ADI = (string.IsNullOrEmpty(reader["ADI"].ToString()) ? "" : reader["ADI"].ToString()),
        //                SOYADI = (string.IsNullOrEmpty(reader["SOYADI"].ToString()) ? "" : reader["SOYADI"].ToString()),
        //                ADRES = (string.IsNullOrEmpty(reader["ADRES"].ToString()) ? "" : reader["ADRES"].ToString()),
        //                BAGKUR_NO = (string.IsNullOrEmpty(reader["BAGKUR_NO"].ToString()) ? "" : reader["BAGKUR_NO"].ToString()),
        //                CEP_TELEFONU = (string.IsNullOrEmpty(reader["CEP_TELEFONU"].ToString()) ? "" : reader["CEP_TELEFONU"].ToString()),
        //                DOGUM_YERI = (string.IsNullOrEmpty(reader["DOGUM_YERI"].ToString()) ? "" : reader["DOGUM_YERI"].ToString()),
        //                EMAIL = (string.IsNullOrEmpty(reader["EMAIL"].ToString()) ? "" : reader["EMAIL"].ToString()),
        //                IL = (string.IsNullOrEmpty(reader["IL"].ToString()) ? "" : reader["IL"].ToString()),
        //                SonGuncelleyen = (string.IsNullOrEmpty(reader["SonGuncelleyen"].ToString()) ? "" : reader["SonGuncelleyen"].ToString()),
        //                Parola = (string.IsNullOrEmpty(reader["Parola"].ToString()) ? "" : reader["Parola"].ToString()),
        //                TCKIMLIK_NO = (string.IsNullOrEmpty(reader["TCKIMLIK_NO"].ToString()) ? "" : reader["TCKIMLIK_NO"].ToString()),
        //                URETICI_NO = (string.IsNullOrEmpty(reader["URETICI_NO"].ToString()) ? "" : reader["URETICI_NO"].ToString()),
        //                Pasif = (reader["Pasif"].Equals(DBNull.Value) ? false : Convert.ToBoolean(reader["Pasif"])),
        //                DOGUM_TARIHI = reader["DOGUM_TARIHI"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["DOGUM_TARIHI"]),
        //                GuncellemeTarihi = reader["GuncellemeTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["GuncellemeTarihi"]),
        //                OlusturmaTarihi = reader["OlusturmaTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["OlusturmaTarihi"]),
        //                URETICI_ID = Convert.ToInt32(reader["URETICI_ID"].ToString()),
        //            });
        //        }

        //        return list;
        //    }
        //}

        //public URETICILER GetById(string URETICI_NO)
        //{
        //    using (connection)
        //    {
        //        connection.Open();

        //        string conString = "SELECT * FROM URETICILER WHERE URETICI_NO = @URETICI_NO";

        //        SqlCommand cmd = new SqlCommand(conString, connection);

        //        cmd.Parameters.AddWithValue("@URETICI_NO", URETICI_NO);

        //        reader = cmd.ExecuteReader();

        //        URETICILER ur = Uretici_Parse(reader);

        //        return ur;
        //    }
        //}



        //public URETICILER Login(string URETICI_NO, string Parola)
        //{
        //    using (connection)
        //    {
        //        connection.Open();

        //        string conString = "SELECT * FROM URETICILER WHERE URETICI_NO = @URETICI_NO";

        //        if (Parola != "")
        //        {
        //            conString += " and Parola = @Parola";
        //        }


        //        SqlCommand cmd = new SqlCommand(conString, connection);


        //        cmd.Parameters.AddWithValue("@URETICI_NO", URETICI_NO);
        //        if (Parola != "")
        //        {
        //            cmd.Parameters.AddWithValue("@Parola", Parola);
        //        }

        //        reader = cmd.ExecuteReader();
        //        URETICILER ur = Uretici_Parse(reader);

        //        return ur;
        //    }
        //}

        //URETICILER Uretici_Parse(SqlDataReader reader)
        //      {
        //          URETICILER ur = null;

        //          while (reader.Read())
        //          {
        //              ur = new URETICILER()
        //              {
        //                  ADI = (string.IsNullOrEmpty(reader["ADI"].ToString()) ? "" : reader["ADI"].ToString()),
        //                  SOYADI = (string.IsNullOrEmpty(reader["SOYADI"].ToString()) ? "" : reader["SOYADI"].ToString()),
        //                  ADRES = (string.IsNullOrEmpty(reader["ADRES"].ToString()) ? "" : reader["ADRES"].ToString()),
        //                  BAGKUR_NO = (string.IsNullOrEmpty(reader["BAGKUR_NO"].ToString()) ? "" : reader["BAGKUR_NO"].ToString()),
        //                  CEP_TELEFONU = (string.IsNullOrEmpty(reader["CEP_TELEFONU"].ToString()) ? "" : reader["CEP_TELEFONU"].ToString()),
        //                  DOGUM_YERI = (string.IsNullOrEmpty(reader["DOGUM_YERI"].ToString()) ? "" : reader["DOGUM_YERI"].ToString()),
        //                  EMAIL = (string.IsNullOrEmpty(reader["EMAIL"].ToString()) ? "" : reader["EMAIL"].ToString()),
        //                  IL = (string.IsNullOrEmpty(reader["IL"].ToString()) ? "" : reader["IL"].ToString()),
        //                  SonGuncelleyen = (string.IsNullOrEmpty(reader["SonGuncelleyen"].ToString()) ? "" : reader["SonGuncelleyen"].ToString()),
        //                  Parola = (string.IsNullOrEmpty(reader["Parola"].ToString()) ? "" : reader["Parola"].ToString()),
        //                  TCKIMLIK_NO = (string.IsNullOrEmpty(reader["TCKIMLIK_NO"].ToString()) ? "" : reader["TCKIMLIK_NO"].ToString()),
        //                  URETICI_NO = (string.IsNullOrEmpty(reader["URETICI_NO"].ToString()) ? "" : reader["URETICI_NO"].ToString()),
        //                  Pasif = (reader["Pasif"].Equals(DBNull.Value) ? false : Convert.ToBoolean(reader["Pasif"])),
        //                  DOGUM_TARIHI = reader["DOGUM_TARIHI"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["DOGUM_TARIHI"]),
        //                  GuncellemeTarihi = reader["GuncellemeTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["GuncellemeTarihi"]),
        //                  OlusturmaTarihi = reader["OlusturmaTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["OlusturmaTarihi"]),
        //                  URETICI_ID = Convert.ToInt32(reader["URETICI_ID"].ToString()),
        //                  Yetki = (string.IsNullOrEmpty(reader["Parola"].ToString()) ? "" : reader["Yetki"].ToString()),
        //              };
        //          }

        //          return ur;
        //      }

    }
}
