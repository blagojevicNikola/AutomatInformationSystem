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
        public void deleteAutomat(int id, string tip) 
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                connection.Open();

                if (tip=="Hrana")
                {
                    command.Parameters.Clear();
                    command.CommandText = "try_delete_automat_hrane_procedure";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdAutomat", id);
                    command.Parameters["@pIdAutomat"].Direction = System.Data.ParameterDirection.Input;
                    //command.CommandText = "delete from automat_hrane where AUTOMAT_idAutomat=@idAutomat";
                    //command.Parameters.AddWithValue("@idAutomat", id);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.Parameters.Clear();
                    command.CommandText = "try_delete_automat_kafe_procedure";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdAutomat", id);
                    command.Parameters["@pIdAutomat"].Direction = System.Data.ParameterDirection.Input;
                    //command.CommandText = "delete from automat_kafe where AUTOMAT_idAutomat=@idAutomat";
                    //command.Parameters.AddWithValue("@idAutomat", id);
                    command.ExecuteNonQuery();
                }
                //command.Parameters.Clear();
                //command.CommandText = "delete from automat where idAutomat=@idAutomat";
                //command.Parameters.AddWithValue("@idAutomat", id);
                //command.ExecuteNonQuery();
            }
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
                        double ukupanPrihod = (double)reader.GetDecimal(7);
                        if(s=="automat_hrane_info")
                        {
                            int kapacitet = reader.GetInt32(6);
                            resultList.Add(new AutomatHraneDTO(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj, kapacitet, ukupanPrihod));
                        }
                        else
                        {
                            double kapacitet = (double)reader.GetDecimal(6);
                            resultList.Add(new AutomatKafeDTO(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj, kapacitet, ukupanPrihod));
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
                        if(!reader.IsDBNull(8))
                        {
                            nazivObjekta = reader.GetString(8);
                        }
                        string grad = "";
                        if(!reader.IsDBNull(9))
                        {
                            grad = reader.GetString(9);
                        }
                        string adresa = "";
                        if(!reader.IsDBNull(10))
                        {
                            adresa = reader.GetString(10);
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

        public AutomatDTO GetAutomatById(int id, string tip)
        {
            AutomatDTO result = null;
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                if(tip=="Hrana")
                {
                    command.CommandText = "select * from automat_hrane_info where idAutomat=@id";
                    command.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader =command.ExecuteReader();
                    while(reader.Read())
                    {
                        int idAutomata = reader.GetInt32(0);
                        DateTime datumPost = reader.GetDateTime(1);
                        int? objectId;
                        if(reader.IsDBNull(2))
                        {
                            objectId = null;
                        }
                        else
                        {
                            objectId = reader.GetInt32(2);
                        }
                        string tipAutomata = reader.GetString(3);
                        double potrosnja = (double)reader.GetDecimal(4);
                        long serijskiBroj = reader.GetInt64(5);
                        int kapacitet = reader.GetInt32(6);
                        double ukupanPrihod = (double)reader.GetDecimal(7);
                        result = new AutomatHraneDTO(idAutomata, datumPost, objectId, tipAutomata, potrosnja, serijskiBroj, kapacitet, ukupanPrihod);
                    }
                }
                else
                {
                    command.CommandText = "select * from automat_kafe_info where idAutomat=@id";
                    command.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int idAutomata = reader.GetInt32(0);
                        DateTime datumPost = reader.GetDateTime(1);
                        int? objectId;
                        if (reader.IsDBNull(2))
                        {
                            objectId = null;
                        }
                        else
                        {
                            objectId = reader.GetInt32(2);
                        }
                        string tipAutomata = reader.GetString(3);
                        double potrosnja = (double)reader.GetDecimal(4);
                        long serijskiBroj = reader.GetInt64(5);
                        double kapacitet = (double)reader.GetDecimal(6);
                        double ukupanPrihod = (double)reader.GetDecimal(7);
                        result = new AutomatKafeDTO(idAutomata, datumPost, objectId, tipAutomata, potrosnja, serijskiBroj, kapacitet, ukupanPrihod);
                    }
                }
                return result;
            }
        }

        public void saveAutomat(AutomatDTO automat)
        {
            long id;
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into automat(idAutomat,DatumPostavljanja,OBJEKAT_idObjekat,Tip,Potrosnja,SerijskiBroj) VALUES(@ID, @DatumPostavljanja, @ObjekatId, @Tip, @Potrosnja, @SerijskiBroj)";
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

        public void updateAutomat(AutomatDTO automat)
        {
            
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "update automat set DatumPostavljanja=@datumPostavljanja, OBJEKAT_idObjekat=@objekatId, Tip=@tip, Potrosnja=@potrosnja, SerijskiBroj=@serijskiBroj where idAutomat=@id";
                command.Parameters.AddWithValue("@ID", automat.ID);
                command.Parameters.AddWithValue("@DatumPostavljanja", automat.DatumPostavljanja);
                command.Parameters.AddWithValue("@ObjekatId", automat.ObjekatID);
                command.Parameters.AddWithValue("@Tip", automat.Tip);
                command.Parameters.AddWithValue("@Potrosnja", automat.Potrosnja);
                command.Parameters.AddWithValue("@SerijskiBroj", automat.SerijskiBroj);
                command.ExecuteNonQuery();
                if (automat.Tip == "Hrana")
                {
                    command.Parameters.Clear();
                    command.CommandText = "update automat_hrane set Kapacitet=@kapacitet where AUTOMAT_idAutomat=@id";
                    command.Parameters.AddWithValue("@id", automat.ID);
                    AutomatHraneDTO temp = (AutomatHraneDTO)automat;
                    command.Parameters.AddWithValue("@kapacitet", temp.Kapacitet);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.Parameters.Clear();
                    command.CommandText = "update automat_kafe set KapacitetKontejnera=@kapacitet where AUTOMAT_idAutomat=@id";
                    command.Parameters.AddWithValue("@id", automat.ID);
                    AutomatKafeDTO temp = (AutomatKafeDTO)automat;
                    command.Parameters.AddWithValue("@kapacitet", temp.Kapacitet);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
