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
            List<string> tipovi = new List<string> { "automat_hrane_info", "automat_kafe_info" };
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                connection.Open();
                foreach (string s in tipovi)
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "select * from "+s;
                    MySqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        DateTime datumPostavljanja = reader.GetDateTime(1);
                        int objekatId = reader.GetInt32(2);
                        string tip = reader.GetString(3);
                        double potrosnja = (double)reader.GetDecimal(4);
                        long serijskiBroj = reader.GetInt64(5);
                        if(s=="automat_hrane_info")
                        {
                            int kapacitet = reader.GetInt32(6);
                            resultList.Add(new AutomatHraneDTO(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj, kapacitet));
                        }
                        else
                        {
                            double kapacitet = (double)reader.GetDecimal(6);
                            resultList.Add(new AutomatKafeDTO(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj, kapacitet));
                        }
                    }
                }
            }
            return resultList;
        }

        public List<AutomatFullInfoDTO> GetAllAutomatiFullInfo()
        {
            List<AutomatFullInfoDTO> resultList = new List<AutomatFullInfoDTO>();
            List<string> tipovi = new List<string> { "automat_hrane_info", "automat_kafe_info" };
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                connection.Open();
                foreach (string s in tipovi)
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "select * from " + s;
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        DateTime datumPostavljanja = reader.GetDateTime(1);
                        int? objekatId;
                        if (reader.IsDBNull(2))
                        {
                            objekatId = null;
                        }
                        else
                        {
                            objekatId = reader.GetInt32(2);
                        }
                        string tip = reader.GetString(3);
                        double potrosnja = (double)reader.GetDecimal(4);
                        long serijskiBroj = reader.GetInt64(5);
                        string nazivObjekta = "";
                        if(!reader.IsDBNull(7))
                        {
                            nazivObjekta = reader.GetString(7);
                        }
                        string grad = "";
                        if(!reader.IsDBNull(8))
                        {
                            grad = reader.GetString(8);
                        }
                        string adresa = "";
                        if(!reader.IsDBNull(9))
                        {
                            adresa = reader.GetString(9);
                        }
                        if (s == "automat_hrane_info")
                        {
                            string kapacitet = reader.GetInt32(6).ToString();
                            resultList.Add(new AutomatFullInfoDTO(id, datumPostavljanja,objekatId,tip,potrosnja,serijskiBroj,kapacitet,nazivObjekta,grad,adresa));
                        }
                        else
                        {
                            string kapacitet = reader.GetDecimal(6).ToString();
                            resultList.Add(new AutomatFullInfoDTO(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj, kapacitet, nazivObjekta, grad, adresa));
                        }
                    }
                    reader.Close();
                }
            }
            return resultList;
        }

        public AutomatDTO GetAutomatById()
        {
            throw new NotImplementedException();
        }

        public void saveAutomat(AutomatDTO automat)
        {
            long id;
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into automat VALUES(@ID, @DatumPostavljanja, @ObjekatId, @Tip, @Potrosnja, @SerijskiBroj)";
                command.Parameters.AddWithValue("@ID", null);
                command.Parameters.AddWithValue("@DatumPostavljanja", automat.DatumPostavljanja);
                command.Parameters.AddWithValue("@ObjekatId", automat.ObjekatID);
                command.Parameters.AddWithValue("@Tip", automat.Tip);
                command.Parameters.AddWithValue("@Potrosnja", automat.Potrosnja);
                command.Parameters.AddWithValue("@SerijskiBroj", automat.SerijskiBroj);
                command.ExecuteNonQuery();
                id = command.LastInsertedId;
                if (automat.Tip == "Hrana")
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into automat_hrane VALUES(@id, @kapacitet)";
                    command.Parameters.AddWithValue("@id", id);
                    AutomatHraneDTO temp = (AutomatHraneDTO)automat;
                    command.Parameters.AddWithValue("@kapacitet", temp.Kapacitet);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into automat_kafe VALUES(@id, @kapacitet)";
                    command.Parameters.AddWithValue("@id", id);
                    AutomatKafeDTO temp = (AutomatKafeDTO)automat;
                    command.Parameters.AddWithValue("@kapacitet", temp.Kapacitet);
                    command.ExecuteNonQuery();
                }

            }
           
        }

        public void updateAutomat(AutomatDTO automat, string kapacitet)
        {
            throw new NotImplementedException();
        }
    }
}
