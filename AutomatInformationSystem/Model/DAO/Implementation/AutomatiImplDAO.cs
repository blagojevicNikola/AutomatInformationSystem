using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatiImplDAO : IAutomatDAO
    {
        public void deleteAutomat(AutomatDTO automat)
        {
            throw new NotImplementedException();
        }

        public List<AutomatDTO> GetAllAutomati()
        {
            List<AutomatDTO> resultList = new List<AutomatDTO>();
            List<string> tipovi = new List<string> { "Kafa", "Hrana" };
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from automat";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime datumPostavljanja = reader.GetDateTime(1);
                    int objekatId = reader.GetInt32(2);
                    string tip = reader.GetString(3);
                    double potrosnja = (double)reader.GetDecimal(4);
                    long serijskiBroj = reader.GetInt64(5);
                    
                    if (tip == "Kafa")
                    {
                        resultList.Add(new AutomatKafeDTO(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj,potrosnja));
                    }
                    else
                    {
                    }
                }
            }
            return resultList;
        }

        public AutomatDTO GetAutomatById()
        {
            throw new NotImplementedException();
        }

        public void saveAutomat(AutomatDTO automat, string kapacitet)
        {
            throw new NotImplementedException();
        }

        public void updateAutomat(AutomatDTO automat, string kapacitet)
        {
            throw new NotImplementedException();
        }
    }
}
