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
        public void addHranaToPunjenje(long idPunjenje, long idHrana, int kolicina) 
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into puni_sa_hranom VALUES(@proizvodId,@kolicina,@punjenjeId)";
                command.Parameters.AddWithValue("@proizvodId", idHrana);
                command.Parameters.AddWithValue("@punjenjeId", idPunjenje);
                command.Parameters.AddWithValue("@kolicina", kolicina);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public long addPrihod(PunjenjeDTO prihod)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into punjenje(RADNIK_ZAPOSLENI_Sifra,AUTOMAT_idAutomat,DatumPunjenja,Prihod) VALUES(@radnikId,@automatId,@DatumPunjenja,@Prihod)";
                command.Parameters.AddWithValue("@radnikId", prihod.RadnikID);
                command.Parameters.AddWithValue("@automatId", prihod.AutomatID);
                command.Parameters.AddWithValue("@DatumPunjenja", prihod.DatumPunjenja);
                command.Parameters.AddWithValue("@Prihod", prihod.Prihod);
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine(command.LastInsertedId);
                return command.LastInsertedId;
            }
        }

        public void addSastojciToPunjenje(long idPunjenje, long idHrana, double kolicina)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into puni_sa_sastojcima VALUES(@proizvodId,@kolicina,@punjenjeId)";
                command.Parameters.AddWithValue("@proizvodId", idHrana);
                command.Parameters.AddWithValue("@punjenjeId", idPunjenje);
                command.Parameters.AddWithValue("@kolicina", kolicina);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ProizvodPunjenjaDTO> GetAllHranaByPunjenje(long punjenjeId)
        {
            List<ProizvodPunjenjaDTO> resultList = new List<ProizvodPunjenjaDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select Naziv,Kolicina from punjenje_automata_hranom where idPunjenje=@id";
                command.Parameters.AddWithValue("@id", punjenjeId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string naziv = reader.GetString(0);
                    int kolicina = reader.GetInt32(1);
                    resultList.Add(new ProizvodPunjenjaDTO(naziv,kolicina.ToString()));
                }
            }
            return resultList;
        }

        public List<PunjenjeDTO> GetAllPrihodByAutomatId(int id)
        {
            List<PunjenjeDTO> resultList = new List<PunjenjeDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from punjenje where AUTOMAT_idAutomat=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idPunjenja = reader.GetInt32(0);
                    int idRadnika = reader.GetInt32(1);
                    int idAutomata = reader.GetInt32(2);
                    DateTime datumPunjenja = reader.GetDateTime(3);
                    double prihod = (double)reader.GetDecimal(4);
                    resultList.Add(new PunjenjeDTO(idPunjenja,idAutomata, idRadnika, datumPunjenja, prihod));
                }
            }
            return resultList;
        }

        public List<ProizvodPunjenjaDTO> GetAllSastojciByPunjenje(long punjenjeId)
        {
            List<ProizvodPunjenjaDTO> resultList = new List<ProizvodPunjenjaDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select Naziv,Kolicina from punjenje_automata_sastojcima where idPunjenje=@id";
                command.Parameters.AddWithValue("@id", punjenjeId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string naziv = reader.GetString(0);
                    double kolicina =(double) reader.GetDecimal(1);
                    resultList.Add(new ProizvodPunjenjaDTO(naziv, kolicina.ToString()));
                }
            }
            return resultList;
        }

        public PunjenjeDTO GetPunjenjeById(long id)
        {
            PunjenjeDTO result = null;
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from punjenje where idPunjenje=@id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idPunjenja = reader.GetInt32(0);
                    int idRadnika = reader.GetInt32(1);
                    int idAutomata = reader.GetInt32(2);
                    DateTime datumPunjenja = reader.GetDateTime(3);
                    double prihod = (double)reader.GetDecimal(4);
                    result = new PunjenjeDTO(idPunjenja, idAutomata, idRadnika, datumPunjenja, prihod);
                }
            }
            return result;
        }

        public bool HranaCanBeAdded(long idAutomat, long idProizvod, int kolicina, out string poruka)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "can_add_hrana_procedure";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@pIdAutomat", idAutomat);
                command.Parameters["@pIdAutomat"].Direction = System.Data.ParameterDirection.Input;

                command.Parameters.AddWithValue("@pIdProizvod", idProizvod);
                command.Parameters["@pIdProizvod"].Direction = System.Data.ParameterDirection.Input;

                command.Parameters.AddWithValue("@pKolicina", kolicina);
                command.Parameters["@pKolicina"].Direction = System.Data.ParameterDirection.Input;
                string por = "";
                command.Parameters.AddWithValue("@pPoruka", por);
                command.Parameters["@pPoruka"].Direction = System.Data.ParameterDirection.Output;
                bool status = false;
                command.Parameters.AddWithValue("@pStatus", MySqlDbType.Int32);
                command.Parameters["@pStatus"].Direction = System.Data.ParameterDirection.Output;
                
                //command.CommandText = "insert into ah_nudi_h VALUES(@idAutomat, @idProizvod, @Cijena,@Kolicina)";
                ////command.Parameters.AddWithValue("@Sifra", 1);
                //command.Parameters.AddWithValue("@idAutomat", automatId);
                //command.Parameters.AddWithValue("@idProizvod", proizvodId);
                //command.Parameters.AddWithValue("@Cijena", cijena);
                //command.Parameters.AddWithValue("@Kolicina", kolicina);
                command.ExecuteNonQuery();
                status = (int)command.Parameters["@pStatus"].Value == 0 ? false:true ;
                poruka = command.Parameters["@pPoruka"].Value.ToString();
                return status;

            }
        }
        public bool SastojakCanBeAdded(long idAutomat, long idSastojak, double kolicina, out string poruka)
        {
            throw new NotImplementedException();
        }
    }
}
