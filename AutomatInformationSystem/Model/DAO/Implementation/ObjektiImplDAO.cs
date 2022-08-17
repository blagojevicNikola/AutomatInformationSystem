using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ObjektiImplDAO : IObjektiDAO
    {
        public void deleteObjekat(int id)
        {
            throw new NotImplementedException();
        }

        public List<ObjekatDTO> GetAllObjekti()
        {
            List<ObjekatDTO> resultList = new List<ObjekatDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from objekat";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    int vlasnikId = reader.GetInt32(2);
                    int lokacijaId = reader.GetInt32(3);
                    int ugovorId = reader.GetInt32(4);

                    resultList.Add(new ObjekatDTO(id, naziv, vlasnikId, lokacijaId, ugovorId));
                }
            }
            return resultList;
        }

        public ObjekatDTO GetObjekatById(int id)
        {
            throw new NotImplementedException();
        }

        public void saveObjekat(ObjekatDTO objekat)
        {
            throw new NotImplementedException();
        }

        public void updateObjekat(ObjekatDTO objekat)
        {
            throw new NotImplementedException();
        }
    }
}
