using Entities;
using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Managers
{
    public class SoforlerManager : BaseManager<Soforler, FloratediyeDBEntities>
    {
        //List<Soforler> list { get; set; }
        //Soforler sofor { get; set; }



        //public List<Soforler> GetAll()
        //{
        //    list = new List<Soforler>();

        //    using (connection)
        //    {
        //        connection.Open();

        //        string conString = "SELECT * FROM Soforler";

        //        SqlCommand cmd = new SqlCommand(conString, connection);

        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            list.Add(new Soforler
        //            {
        //                SoforID = Convert.ToInt32(reader["SoforID"].ToString()),
        //                Adi = (string.IsNullOrEmpty(reader["Adi"].ToString()) ? "" : reader["Adi"].ToString()),
        //                Soyadi = (string.IsNullOrEmpty(reader["Soyadi"].ToString()) ? "" : reader["Soyadi"].ToString()),
        //                Bolge = (string.IsNullOrEmpty(reader["Bolge"].ToString()) ? "" : reader["Bolge"].ToString()),
        //                Kodu = (string.IsNullOrEmpty(reader["Kodu"].ToString()) ? "" : reader["Kodu"].ToString()),
        //                Plaka = (string.IsNullOrEmpty(reader["Plaka"].ToString()) ? "" : reader["Plaka"].ToString()),
        //                Sehir = (string.IsNullOrEmpty(reader["Sehir"].ToString()) ? "" : reader["Sehir"].ToString()),
        //                Parola = (string.IsNullOrEmpty(reader["Parola"].ToString()) ? "" : reader["Parola"].ToString()),
        //                SonGuncelleyen = (string.IsNullOrEmpty(reader["SonGuncelleyen"].ToString()) ? "" : reader["SonGuncelleyen"].ToString()),
        //                Pasif = (reader["Pasif"].Equals(DBNull.Value) ? false : Convert.ToBoolean(reader["Pasif"])),
        //                GuncellemeTarihi = reader["GuncellemeTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["GuncellemeTarihi"]),
        //                OlusturmaTarihi = reader["OlusturmaTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["OlusturmaTarihi"])
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


        public Soforler Login(string Kodu, string Parola)
        {
            Soforler sofor = Get(x => x.Kodu == Kodu && x.Parola == Parola);
            return sofor;
        }






        //public Soforler Login(string Kodu, string Parola)
        //{
        //using (connection)
        //{
        //    connection.Open();

        //    string conString = "SELECT * FROM Soforler WHERE Kodu = @Kodu and Parola = @Parola";


        //    SqlCommand cmd = new SqlCommand(conString, connection);


        //    cmd.Parameters.AddWithValue("@Kodu", Kodu);
        //    cmd.Parameters.AddWithValue("@Parola", Parola);

        //    reader = cmd.ExecuteReader();

        //    Soforler sofor = null;


        //    while (reader.Read())
        //    {
        //        sofor = new Soforler
        //        {
        //            SoforID = Convert.ToInt32(reader["SoforID"].ToString()),
        //            Adi = (string.IsNullOrEmpty(reader["Adi"].ToString()) ? "" : reader["Adi"].ToString()),
        //            Soyadi = (string.IsNullOrEmpty(reader["Soyadi"].ToString()) ? "" : reader["Soyadi"].ToString()),
        //            Bolge = (string.IsNullOrEmpty(reader["Bolge"].ToString()) ? "" : reader["Bolge"].ToString()),
        //            Kodu = (string.IsNullOrEmpty(reader["Kodu"].ToString()) ? "" : reader["Kodu"].ToString()),
        //            Plaka = (string.IsNullOrEmpty(reader["Plaka"].ToString()) ? "" : reader["Plaka"].ToString()),
        //            Sehir = (string.IsNullOrEmpty(reader["Sehir"].ToString()) ? "" : reader["Sehir"].ToString()),
        //            Parola = (string.IsNullOrEmpty(reader["Parola"].ToString()) ? "" : reader["Parola"].ToString()),
        //            SonGuncelleyen = (string.IsNullOrEmpty(reader["SonGuncelleyen"].ToString()) ? "" : reader["SonGuncelleyen"].ToString()),
        //            Pasif = (reader["Pasif"].Equals(DBNull.Value) ? false : Convert.ToBoolean(reader["Pasif"])),
        //            GuncellemeTarihi = reader["GuncellemeTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["GuncellemeTarihi"]),
        //            OlusturmaTarihi = reader["OlusturmaTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["OlusturmaTarihi"]),
        //            Nakliyeci = (string.IsNullOrEmpty(reader["Nakliyeci"].ToString()) ? "" : reader["Nakliyeci"].ToString()),
        //        };

        //    }


        //    return sofor;
        //}
        //}

        Soforler Sofor_Parse(SqlDataReader reader)
        {
            Soforler sofor = null;

            while (reader.Read())
            {
                sofor = new Soforler
                {
                    SoforID = Convert.ToInt32(reader["SoforID"].ToString()),
                    Adi = (string.IsNullOrEmpty(reader["Adi"].ToString()) ? "" : reader["Adi"].ToString()),
                    Soyadi = (string.IsNullOrEmpty(reader["Soyadi"].ToString()) ? "" : reader["Soyadi"].ToString()),
                    Bolge = (string.IsNullOrEmpty(reader["Bolge"].ToString()) ? "" : reader["Bolge"].ToString()),
                    Kodu = (string.IsNullOrEmpty(reader["Kodu"].ToString()) ? "" : reader["Kodu"].ToString()),
                    Plaka = (string.IsNullOrEmpty(reader["Plaka"].ToString()) ? "" : reader["Plaka"].ToString()),
                    Sehir = (string.IsNullOrEmpty(reader["Sehir"].ToString()) ? "" : reader["Sehir"].ToString()),
                    Parola = (string.IsNullOrEmpty(reader["Parola"].ToString()) ? "" : reader["Parola"].ToString()),
                    SonGuncelleyen = (string.IsNullOrEmpty(reader["SonGuncelleyen"].ToString()) ? "" : reader["SonGuncelleyen"].ToString()),
                    Pasif = (reader["Pasif"].Equals(DBNull.Value) ? false : Convert.ToBoolean(reader["Pasif"])),
                    GuncellemeTarihi = reader["GuncellemeTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["GuncellemeTarihi"]),
                    OlusturmaTarihi = reader["OlusturmaTarihi"].Equals(DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["OlusturmaTarihi"])
                };
            }

            return sofor;
        }
    }
}
