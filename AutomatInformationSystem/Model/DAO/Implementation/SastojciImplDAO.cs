using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class SastojciImplDAO : ISastojciDAO
    {
        public void deleteSastojak(SastojciDTO sastojak)
        {
            throw new NotImplementedException();
        }

        public List<SastojciDTO> GetAllSastojci()
        {
            List<SastojciDTO> resultList = new List<SastojciDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from sastojci";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    
                    resultList.Add(new SastojciDTO(id, naziv));

                }
            }
            return resultList;
        }

        public List<SastojciDTO> GetAvailableSastojci(int id)
        {
            List<SastojciDTO> resultList = new List<SastojciDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select idSastojci, Naziv from sastojci s left join kafa_od_sastojaka k on s.idSastojci = k.SASTOJCI_idSastojci where k.KAFA_PROIZVOD_idProizvod !=@idProizvoda or k.KAFA_PROIZVOD_idProizvod is null";
                command.Parameters.AddWithValue("@idProizvoda", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idSastojka = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    resultList.Add(new SastojciDTO(idSastojka, naziv));

                }
            }
            return resultList;
        }

        public SastojciDTO GetSastojakById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SastojciDTO> GetSelectedSastojci(int id)
        {
            List<SastojciDTO> resultList = new List<SastojciDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select idSastojci, Naziv from sastojci s inner join kafa_od_sastojaka k on s.idSastojci = k.SASTOJCI_idSastojci where k.KAFA_PROIZVOD_idProizvod=@idProizvoda";
                command.Parameters.AddWithValue("@idProizvoda", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idSastojka = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    resultList.Add(new SastojciDTO(idSastojka, naziv));

                }
            }
            return resultList;
        }

        public void saveSastojak(string naziv)
        {
            throw new NotImplementedException();
        }

        public void updateSastojak(SastojciDTO sastojak)
        {
            throw new NotImplementedException();
        }
    }
}
