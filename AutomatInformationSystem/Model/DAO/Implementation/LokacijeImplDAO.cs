using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class LokacijeImplDAO : ILokacijeDAO
    {
        public void deleteLokacija(LokacijaDTO lokacija)
        {
            throw new NotImplementedException();
        }

        public List<LokacijaDTO> GetAllLokacije()
        {
            List<LokacijaDTO> resultList = new List<LokacijaDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from lokacija";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string grad = reader.GetString(1);
                    string adresa = reader.GetString(2);

                    resultList.Add(new LokacijaDTO(id, grad, adresa));
                }
            }
            return resultList;
        }

        public LokacijaDTO GetLokacijaById(int id)
        {
            LokacijaDTO result = null;
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from lokacija where idLokacija=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idLokacije = reader.GetInt32(0);
                    string grad = reader.GetString(1);
                    string adresa = reader.GetString(2);

                    result = new LokacijaDTO(id, grad, adresa);
                }
            }
            return result;
        }

        public void saveLokacija(LokacijaDTO lokacija)
        {
            throw new NotImplementedException();
        }

        public void updateLokacija(LokacijaDTO lokacija)
        {
            throw new NotImplementedException();
        }
    }
}
