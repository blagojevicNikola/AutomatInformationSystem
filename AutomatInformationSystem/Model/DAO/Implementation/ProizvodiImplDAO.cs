using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ProizvodiImplDAO : IProizvodDAO
    {
        public void deleteProizvod(int id, string tip)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                connection.Open();

                if (tip == "Hrana")
                {
                    command.Parameters.Clear();
                    command.CommandText = "delete from hrana where PROIZVOD_idProizvod=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.Parameters.Clear();
                    command.CommandText = "delete from kafa where PROIZVOD_idProizvod=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    command.CommandText = "delete from kafa_od_sastojaka where KAFA_PROIZVOD_idProizvod=@id";
                    command.Parameters.AddWithValue("@id", id);
                }
                command.Parameters.Clear();
                command.CommandText = "delete from proizvod where idProizvod=@id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<ProizvodDTO> GetAllProizvod()
        {
            List<ProizvodDTO> resultList = new List<ProizvodDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from proizvod";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    string tip = reader.GetString(2);
                    if (tip == "Hrana")
                    {
                        resultList.Add(new HranaDTO(id, naziv, tip));
                    }
                    else
                    {
                        resultList.Add(new KafaDTO(id, naziv, tip));
                    }
                }
            }
            return resultList;
        }

        public ProizvodDTO GetProizvodById(int id)
        {
            throw new NotImplementedException();
        }

        public long saveProizvod(string naziv, string tip, List<SastojciDTO> sastojci)
        {
            long id;
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into proizvod(Naziv, Tip) VALUES(@Naziv,@Tip)";
                //command.Parameters.AddWithValue("@Sifra", 1);
                command.Parameters.AddWithValue("@Naziv", naziv);
                command.Parameters.AddWithValue("@Tip", tip);
                command.ExecuteNonQuery();
                id = command.LastInsertedId;
                if (tip == "Hrana")
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into hrana(PROIZVOD_idProizvod) VALUES(@PROIZVOD_idProizvod)";
                    command.Parameters.AddWithValue("@PROIZVOD_idProizvod", id);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into kafa(PROIZVOD_idProizvod) VALUES(@PROIZVOD_idProizvod)";
                    command.Parameters.AddWithValue("@PROIZVOD_idProizvod", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    command.CommandText = "insert into kafa_od_sastojaka(SASTOJCI_idSastojci, KAFA_PROIZVOD_idProizvod) VALUES(@idSastojci, @idProizvod)";
                    foreach(SastojciDTO s in sastojci)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@idSastojci", s.ID);
                        command.Parameters.AddWithValue("@idProizvod", id);
                        command.ExecuteNonQuery();
                    }
                }

            }
            return id;
        }

        public void updateProizvod(int id, string naziv,string tip, List<int> addSastojci, List<int> removeSastojci)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                connection.Open();

                
                command.CommandText = "update proizvod set Naziv=@naziv where idProizvod=@id";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Naziv", naziv);
                command.ExecuteNonQuery();
                if(tip=="Kafa")
                {
                    command.CommandText = "insert into kafa_od_sastojaka VALUES(@idSastojka, @idProizvoda)";
                    foreach (int s in addSastojci)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@idSastojka", s);
                        command.Parameters.AddWithValue("@idProizvoda", id);
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "delete from kafa_od_sastojaka where SASTOJCI_idSastojci=@idSastojka and KAFA_PROIZVOD_idProizvod=@idProizvoda";
                    foreach(int s in removeSastojci)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@idSastojka", s);
                        command.Parameters.AddWithValue("@idProizvoda", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
