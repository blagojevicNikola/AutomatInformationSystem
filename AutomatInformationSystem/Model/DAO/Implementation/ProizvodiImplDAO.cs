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

        public List<ProizvodDTO> GetAllProizvodHrana()
        {
            List<ProizvodDTO> resultList = new List<ProizvodDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from proizvod_hrana";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    string tip = reader.GetString(2);
                    resultList.Add(new HranaDTO(id, naziv, tip));
                }
            }
            return resultList;
        }

        public List<ProizvodDTO> GetAllProizvodKafa()
        {
            List<ProizvodDTO> resultList = new List<ProizvodDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from proizvod_kafa";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    string tip = reader.GetString(2);
                    resultList.Add(new HranaDTO(id, naziv, tip));
                }
            }
            return resultList;
        }

        public List<NudiProizvodDTO> GetAllHranaOfAutomat(int id)
        {
            List<NudiProizvodDTO> resultList = new List<NudiProizvodDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select idProizvod, Naziv, Tip, Kolicina, Cijena from (select * from proizvod p natural join ah_nudi_h h natural join automat a where idAutomat = @id) as ubaceni_proizvodi";
                command.Parameters.AddWithValue("@id",id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idProizvoda = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    string tip = reader.GetString(2);
                    double cijena = (double)reader.GetDecimal(4);
                    int kolicina = reader.GetInt32(3);
                    
                    resultList.Add(new NudiProizvodDTO(idProizvoda, naziv, tip, cijena, kolicina));
                   

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

        public List<NudiProizvodDTO> GetAllKafaOfAutomat(int id)
        {
            List<NudiProizvodDTO> resultList = new List<NudiProizvodDTO>();
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select idProizvod, Naziv, Tip, Cijena from (select * from proizvod p natural join ak_nudi_k k natural join automat a where idAutomat = @id) as ubaceni_proizvodi ";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idProizvoda = reader.GetInt32(0);
                    string naziv = reader.GetString(1);
                    string tip = reader.GetString(2);
                    double cijena = (double)reader.GetDecimal(3);
                    resultList.Add(new NudiProizvodDTO(idProizvoda, naziv, tip, cijena, null));
                }
            }
            return resultList;
        }

        public bool insertHranaInAutomat(int automatId, int proizvodId, double cijena, int kolicina, out string poruka)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "kolicina_hrane_procedure";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@pIdAutomat", automatId);
                command.Parameters["@pIdAutomat"].Direction = System.Data.ParameterDirection.Input;

                command.Parameters.AddWithValue("@pIdProizvod", proizvodId);
                command.Parameters["@pIdProizvod"].Direction = System.Data.ParameterDirection.Input;

                command.Parameters.AddWithValue("@pCijena", cijena);
                command.Parameters["@pCijena"].Direction = System.Data.ParameterDirection.Input;

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
                poruka = command.Parameters["@pPoruka"].Value.ToString();
                status = ((int)command.Parameters["@pStatus"].Value) !=0;
                return status;
                
            }
           
        }

        public void insertKafaInAutomat(int automatId, int proizvodId, double cijena)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into ak_nudi_k VALUES(@idAutomat, @idProizvod, @Cijena)";
                //command.Parameters.AddWithValue("@Sifra", 1);
                command.Parameters.AddWithValue("@idAutomat", automatId);
                command.Parameters.AddWithValue("@idProizvod", proizvodId);
                command.Parameters.AddWithValue("@Cijena", cijena);
                command.ExecuteNonQuery();

            }
        }

        public void deleteProizvodFromAutomat(int automatId, int proizvodId, string tip)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["AutomatDB"].ConnectionString))
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                if(tip=="Hrana")
                {
                    command.CommandText = "delete from ah_nudi_h where idAutomat=@idAutomat and idProizvod=@idProizvod";
                }
                else
                {
                    command.CommandText = "delete from ak_nudi_k where idAutomat=@idAutomat and idProizvod=@idProizvod";
                }
                //command.Parameters.AddWithValue("@Sifra", 1);
                command.Parameters.AddWithValue("@idAutomat", automatId);
                command.Parameters.AddWithValue("@idProizvod", proizvodId);
                command.ExecuteNonQuery();

            }
        }
    }
}
