using Entities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Managers
{


    public class SubeManager : BaseManager
    {
        List<SubeSatis> list { get; set; }

        public List<SubeSatis> GetAll()
        {
            list = new List<SubeSatis>();

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UreticiTakipDBEntities"].ConnectionString))
            {
                connection.Open();

                string conString = "SELECT * FROM SubeSatis";

                SqlCommand cmd = new SqlCommand(conString, connection);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new SubeSatis
                    {
                        SubeID = Convert.ToInt32(reader["SubeID"].ToString()),
                        SubeAdi = (string.IsNullOrEmpty(reader["SubeAdi"].ToString()) ? "" : reader["SubeAdi"].ToString()),
                        SubeKisaAdi = (string.IsNullOrEmpty(reader["SubeKisaAdi"].ToString()) ? "" : reader["SubeKisaAdi"].ToString()),
                        Aciklama = (string.IsNullOrEmpty(reader["Aciklama"].ToString()) ? "" : reader["Aciklama"].ToString()),
                        KalanKoliSayisi = string.IsNullOrEmpty(reader["KalanKoliSayisi"].ToString()) ? 0 : Convert.ToInt32(reader["KalanKoliSayisi"]),                        
                        SatilanKoliSayisi = string.IsNullOrEmpty(reader["SatilanKoliSayisi"].ToString()) ? 0 : Convert.ToInt32(reader["SatilanKoliSayisi"]),
                        ToplamKoliSayisi = string.IsNullOrEmpty(reader["ToplamKoliSayisi"].ToString()) ? 0 : Convert.ToInt32(reader["ToplamKoliSayisi"]),
                        Ortalama = string.IsNullOrEmpty(reader["Ortalama"].ToString()) ? 0 : Convert.ToDecimal(reader["Ortalama"]),
                        ToplamTutar = string.IsNullOrEmpty(reader["ToplamTutar"].ToString()) ? 0 : Convert.ToDecimal(reader["ToplamTutar"]),
                        MusteriSayisi = string.IsNullOrEmpty(reader["MusteriSayisi"].ToString()) ? 0 : Convert.ToInt32(reader["MusteriSayisi"]),
                        Tarih = string.IsNullOrEmpty(reader["Tarih"].ToString()) ? default : Convert.ToDateTime(reader["Tarih"]),
                    });
                }

                return list;
            }
        }
    }
}
