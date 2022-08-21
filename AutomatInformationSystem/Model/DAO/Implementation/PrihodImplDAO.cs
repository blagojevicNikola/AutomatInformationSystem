using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class PrihodImplDAO : IPrihodDAO
    {
        public void addPrihod(PrihodDTO prihod)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into puni VALUES(@radnikId,@automatId,@DatumPunenja,@Prihod";
                command.Parameters.AddWithValue("@radnikId", prihod.RadnikID);
                command.Parameters.AddWithValue("@automatId", prihod.AutomatID);
                command.Parameters.AddWithValue("@DatumPunjenja", prihod.DatumPunjenja);
                command.Parameters.AddWithValue("@Prihod", prihod.Cijena);
                connection.Open();
            }
        }

        public List<PrihodDTO> GetAllPrihodByAutomatId(int id)
        {
            List<PrihodDTO> resultList = new List<PrihodDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from prihod_automata where AUTOMAT_idAutomat=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idRadnika = reader.GetInt32(0);
                    int idAutomata = reader.GetInt32(1);
                    DateTime datumPunjenja = reader.GetDateTime(2);
                    double prihod = (double)reader.GetDecimal(4);
                    resultList.Add(new PrihodDTO(idAutomata, idRadnika, datumPunjenja, prihod));
                }
            }
            return resultList;
        }
    }
}
