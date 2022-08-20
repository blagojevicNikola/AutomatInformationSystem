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

        public List<SastojciDTO> GetAllSastojciForAutomat(int id)
        {
            List<SastojciDTO> resultList = new List<SastojciDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select idSastojci, Naziv from(select* from automat_kafe a inner join ak_nudi_k k on a.AUTOMAT_idAutomat= k.idAutomat inner join kafa_od_sastojaka s on k.idProizvod= s.KAFA_PROIZVOD_idProizvod inner join sastojci j on s.SASTOJCI_idSastojci= j.idSastojci where idAutomat = @id) as sadrzani_sastojci";
                command.Parameters.AddWithValue("@id", id);
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

        public List<SastojciDTO> GetAvailableSastojci(int id)
        {
            List<SastojciDTO> resultList = new List<SastojciDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select idSastojci, Naziv from sastojci s left join kafa_od_sastojaka k on s.idSastojci = k.SASTOJCI_idSastojci where idSastojci not in (select SASTOJCI_idSastojci from kafa_od_sastojaka where KAFA_PROIZVOD_idProizvod=@idProizvoda)";
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
