using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace AutomatInformationSystem
{
    public class ZaposleniImplDAO : IZaposleniDAO
    {
        public void deleteZaposleni(ZaposleniDTO zaposleni)
        {
            throw new NotImplementedException();
        }

        public List<ZaposleniDTO> GetAllZaposleni()
        {

            List<ZaposleniDTO> resultList = new List<ZaposleniDTO>();
            using(MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from zaposleni";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int sifra = reader.GetInt32(0);
                    string ime = reader.GetString(1);
                    string prezime = reader.GetString(2);
                    string telefon = reader.GetString(3);
                    DateTime datum = reader.GetDateTime(4);
                    string tip = reader.GetString(5);
                    if(tip=="Radnik")
                    {
                        resultList.Add(new RadnikDTO(sifra, ime, prezime, telefon, datum, tip));
                    }
                    else
                    {
                        resultList.Add(new ServiserDTO(sifra, ime, prezime, telefon, datum, tip));
                    }
                }
            }
            return resultList;
        }

        public ZaposleniDTO GetZaposleniById(int id)
        {
            throw new NotImplementedException();
        }

        public void saveZaposleni(string ime, string prezime, string telefon, DateTime datumRodjenja, string tip)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into zaposleni(Ime,Prezime,Telefon,DatumRodjenja,Tip) VALUES(@Ime,@Prezime,@Telefon,@DatumRodjenja,@Tip)";
                //command.Parameters.AddWithValue("@Sifra", 1);
                command.Parameters.AddWithValue("@Ime", ime);
                command.Parameters.AddWithValue("@Prezime", prezime);
                command.Parameters.AddWithValue("@Telefon", telefon);
                command.Parameters.AddWithValue("@DatumRodjenja", datumRodjenja);
                command.Parameters.AddWithValue("@Tip", tip);
                command.ExecuteNonQuery();
                long id = command.LastInsertedId;
                if (tip == "Radnik")
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into radnik(ZAPOSLENI_Sifra) VALUES(@ZAPOSLENI_Sifra)";
                    command.Parameters.AddWithValue("@ZAPOSLENI_Sifra", id);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into serviser(ZAPOSLENI_Sifra) VALUES(@ZAPOSLENI_Sifra)";
                    command.Parameters.AddWithValue("@ZAPOSLENI_Sifra", id);
                    command.ExecuteNonQuery();
                }

            }
        }

        public void updateZaposleni(ZaposleniDTO zaposleni)
        {
            throw new NotImplementedException();
        }
    }
}
