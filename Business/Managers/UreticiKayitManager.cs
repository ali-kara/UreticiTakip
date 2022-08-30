

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
    public class IslemYili
    {
        public int Yil { get; set; }
        public string YilAdi { get; set; }
        public string ConnectionString { get; }


        public IslemYili(int yil = 0)
        {
            Yil = yil;

            switch (Yil)
            {
                case 2019:
                    ConnectionString = "UreticiTakipDBEntities_2019";
                    break;

                case 2020:
                    ConnectionString = "UreticiTakipDBEntities_2020";
                    break;

                case 2021:
                    ConnectionString = "UreticiTakipDBEntities_2021";
                    break;

                default:
                    ConnectionString = "UreticiTakipDBEntities";
                    break;
            }
        }

        public static List<IslemYili> YillariGetir()
        {
            return new List<IslemYili>()
            {
                new IslemYili()
                {
                    Yil = 2019,
                    YilAdi = "2019",
                },
                new IslemYili()
                {
                    Yil = 2020,
                    YilAdi=  "2020",
                },
                new IslemYili()
                {
                    Yil = 2021,
                    YilAdi=  "2021",
                }
            };
        }
    }

    public class UreticiKayitManager : BaseManager
    {
        public List<ur_toplam> Getir(int URETICI_ID, DateTime dateBaslangic, DateTime dateBitis)
        {
            FloratediyeDBEntities db = new FloratediyeDBEntities();
            List<ur_toplam> list = new List<ur_toplam>();

            list = db.ur_toplam.Where(x => x.ur_no == URETICI_ID.ToString() && x.tarih >= dateBaslangic.Date && x.tarih <= dateBitis.Date).OrderBy(x => x.tarih).ToList();

            return list;
        }

        //public List<KAYIT_BASLIK> KayitBaslikGetir(int URETICI_ID, DateTime dateBaslangic, DateTime dateBitis, int Yil)
        //{
        //    IslemYili IslemYili = new IslemYili(Yil);

        //    if (ConfigurationManager.ConnectionStrings[IslemYili.ConnectionString] == null)
        //    {
        //        throw new Exception("Connection String Bulunamadı.");
        //    }

        //    FloratediyeDBEntities context = new FloratediyeDBEntities(ConfigurationManager.ConnectionStrings[IslemYili.ConnectionString].ConnectionString);

        //    return null;
        //}


        public List<KAYIT_BASLIK> KayitBaslikGetir(int URETICI_ID, DateTime dateBaslangic, DateTime dateBitis, int? _Yil = null)
        {
            List<KAYIT_BASLIK> list = new List<KAYIT_BASLIK>();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UreticiTakipDBEntities"].ConnectionString);


            if (_Yil != null)
            {
                IslemYili IslemYili = new IslemYili(_Yil.Value);

                if (ConfigurationManager.ConnectionStrings[IslemYili.ConnectionString] == null)
                {
                    return list;
                }

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings[IslemYili.ConnectionString].ConnectionString);
            }

            using (connection)
            {
                try
                {
                    connection.Open();

                    string conString = "SELECT id, ur_no, sube, toplam, nak_zarar, odenecek, " +
                        "tarih, koopgid, stopaj, fon, bagkur, hamaliye, nakliye, borsapay, depo_sira_no, il , yedek1_string " +
                        "FROM ur_toplam " +
                        "where " +
                        "ur_no = @ur_no and " +
                        "tarih between @date_baslangic and @date_bitis order by tarih";


                    SqlCommand cmd = new SqlCommand(conString, connection);
                    cmd.Parameters.AddWithValue("@ur_no", URETICI_ID);
                    cmd.Parameters.AddWithValue("@date_baslangic", dateBaslangic.Date);
                    cmd.Parameters.AddWithValue("@date_bitis", dateBitis.Date);

                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        KAYIT_BASLIK kb = new KAYIT_BASLIK()
                        {
                            KAYIT_BASLIK_ID = Convert.ToInt32(read["id"]),
                            URETICI_ID = URETICI_ID,
                            _URETICI_NO = URETICI_ID.ToString(),
                            _SUBE = read["sube"].Equals(DBNull.Value) ? "" : read["sube"].ToString(),
                            TOPLAM = read["toplam"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["toplam"]),
                            NAKLIYE_ZARAR = read["nak_zarar"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["nak_zarar"]),
                            ODENECEK = read["odenecek"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["odenecek"]),
                            ISLEM_TARIHI = Convert.ToDateTime(read["tarih"]),
                            KOOP_GID = read["koopgid"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["koopgid"]),
                            STOPAJ = read["stopaj"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["stopaj"]),
                            FON = read["fon"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["fon"]),
                            BAGKUR = read["bagkur"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["bagkur"]),
                            HAMALIYE = read["hamaliye"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["hamaliye"]),
                            NAKLIYE = read["nakliye"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["nakliye"]),
                            BORSA_PAY = read["borsapay"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(read["borsapay"]),
                            DEPO_SIRA_NO = read["depo_sira_no"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(read["depo_sira_no"]),
                            _IL = read["il"].Equals(DBNull.Value) ? "" : read["il"].ToString(),
                            //ODEME = string.IsNullOrEmpty(read["ODEME"].ToString()) ? "0" : read["ODEME"].ToString(),
                            //URETICI_ODEME_ID = Convert.ToInt32(read["URETICI_ODEME_ID"]),
                            TED_NO = read["yedek1_string"].Equals(DBNull.Value) ? "" : read["yedek1_string"].ToString()
                        };

                        list.Add(kb);
                    }


                    decimal? toplam = 0;
                    int sayac = 0;

                    foreach (var item in list)
                    {
                        decimal? aratoplam = 0;

                        aratoplam += item.KOOP_GID.HasValue ? item.KOOP_GID : 0;
                        aratoplam += item.STOPAJ.HasValue ? item.STOPAJ : 0;
                        aratoplam += item.FON.HasValue ? item.FON : 0;
                        aratoplam += item.BAGKUR.HasValue ? item.BAGKUR : 0;
                        aratoplam += item.HAMALIYE.HasValue ? item.HAMALIYE : 0;
                        aratoplam += item.NAKLIYE.HasValue ? item.NAKLIYE : 0;
                        aratoplam += item.BORSA_PAY.HasValue ? item.BORSA_PAY : 0;

                        toplam += aratoplam;

                        list[sayac].NET = aratoplam;
                        sayac++;
                    }



                }
                catch
                {

                }

                return list;

            }
        }
        public List<KAYIT_DETAY> KayitDetayGetir(int URETICI_ID, string sube, DateTime? tarih, int satis_sira_no, int? _Yil = null)
        {
            List<KAYIT_DETAY> list = new List<KAYIT_DETAY>();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UreticiTakipDBEntities"].ConnectionString);


            if (_Yil != null)
            {
                IslemYili IslemYili = new IslemYili(_Yil.Value);

                if (ConfigurationManager.ConnectionStrings[IslemYili.ConnectionString] == null)
                {
                    return list;
                }

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings[IslemYili.ConnectionString].ConnectionString);
            }

            using (connection)
            {
                try
                {
                    connection.Open();

                    string conString = "select cic_adi,cic_adet,cic_demet, CONVERT(DECIMAL(10,2),satis_fiyat) as satis_fiyat ,toplam_tutar " +
                        "from satis " +
                        "where sube=@sube and tarih=@tarih and uretici_kodu=@uretici_kodu and sira_no=@satis_sira_no";


                    SqlCommand cmd = new SqlCommand(conString, connection);

                    cmd.Parameters.AddWithValue("@sube", sube);
                    cmd.Parameters.AddWithValue("@tarih", tarih.Value.Date);
                    cmd.Parameters.AddWithValue("@uretici_kodu", URETICI_ID);
                    cmd.Parameters.AddWithValue("@satis_sira_no", satis_sira_no);



                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        KAYIT_DETAY kb = new KAYIT_DETAY()
                        {
                            CICEK_ADI = reader["cic_adi"].ToString(),
                            ADET = reader["cic_adet"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(reader["cic_adet"]),
                            DEMET = reader["cic_demet"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(reader["cic_demet"]),
                            ALICI_KODU = (reader["satis_fiyat"].Equals(DBNull.Value) ? "0" : reader["satis_fiyat"].ToString()),
                            ALICI_TUTAR = (reader["toplam_tutar"].Equals(DBNull.Value) ? 0 : decimal.Round(Convert.ToDecimal(reader["toplam_tutar"]), 2, MidpointRounding.AwayFromZero))
                        };

                        list.Add(kb);
                    }
                }
                catch
                {

                }

                return list;
            }
        }
    }
}