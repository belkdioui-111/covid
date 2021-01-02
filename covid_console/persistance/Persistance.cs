using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace covid_console.persistence
{
    class CitoyenPersistence
    {
        private Connection connection;

        public CitoyenPersistence()
        {
            connection = new Connection();
        }

        public List<Citoyen> getAllCitoyens()
        {

            connection.Cnn.Open();
            List<Citoyen> citoyens = new List<Citoyen>();
            string query = "SELECT * FROM citoyen_";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            using (connection.Cnn)
            {
                connection.Cnn.Open();
                using (getData)
                {
                    using (SqlDataReader reader = getData.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Citoyen citoyen = new Citoyen(reader.GetString("cin"), reader.GetString("nom"),
                                reader.GetString("prenom"),
                                reader.GetInt32("age"),
                                reader.GetString("adresse"),
                                reader.GetInt32("n_tele"),
                                reader.GetDateTime("date_naissance")

                                );
                            citoyen.Date_deces = reader.IsDBNull("date_deces") ? (DateTime?)null : reader.GetDateTime("date_deces");

                            citoyens.Add(citoyen);
                        }
                    }
                }
                connection.Cnn.Close();
            }

            return citoyens;
        }

        public Citoyen getCitoyen(string cin)
        {
            Citoyen citoyen = new Citoyen();
            string query = "SELECT * FROM citoyen_ where cin=@cin";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            getData.Parameters.AddWithValue("@cin", cin);
            using (connection.Cnn)
            {
                using (getData)
                {
                    using (SqlDataReader reader = getData.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            citoyen = new Citoyen(reader.GetString("cin"), reader.GetString("nom"),
                               reader.GetString("prenom"),
                               reader.GetInt32("age"),
                               reader.GetString("adresse"),
                               reader.GetInt32("n_tele"),
                               reader.GetDateTime("date_naissance"),
                               reader.GetDateTime("date_deces"));
                        }
                    }
                }
            }
            return citoyen;
        }

        public Citoyen addCitoyen(Citoyen citoyen)
        {
            connection.Cnn.Open();
            string query = "INSERT INTO citoyen_(cin,nom,prenom,age,adresse,n_tele,date_naissance) VALUES (@cin,@nom, @prenom,@age,@adresse,@n_tele,@date_naissance)";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            getData.Parameters.AddWithValue("@cin", citoyen.Cin);
            getData.Parameters.AddWithValue("@nom", citoyen.Nom);
            getData.Parameters.AddWithValue("@prenom", citoyen.Prenom);
            getData.Parameters.AddWithValue("@age", citoyen.Age);
            getData.Parameters.AddWithValue("@adresse", citoyen.Address);
            getData.Parameters.AddWithValue("@n_tele", citoyen.N_tele);

            getData.Parameters.Add("@date_naissance", SqlDbType.DateTime2).Value = citoyen.Date_naissance;
            //getData.Parameters.AddWithValue("@date_naissance", citoyen.Date_naissance);
            using (connection.Cnn)
            {
                using (getData)
                {
                    getData.ExecuteNonQuery();
                }
            }
            return citoyen;
        }

        public void suppCitoyen(string cin)
        {
            string query = "delete citoyen_ where cin=@cin";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            getData.Parameters.AddWithValue("@cin", cin);
            using (connection.Cnn)
            {
                using (getData)
                {
                    getData.ExecuteNonQuery();
                }
            }

        }

        public void modifierCitoyen(Citoyen citoyen)
        {
            string query = "update citoyen_ set nom=@cin,prenom=@prenom,age=@age,adresse=@adresse,n_tele=@n_tele,date_naissance=@date_naissance,date_deces=@date_deces where cin=@cin";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            getData.Parameters.AddWithValue("@cin", citoyen.Cin);
            getData.Parameters.AddWithValue("@nom", citoyen.Nom);
            getData.Parameters.AddWithValue("@prenom", citoyen.Prenom);
            getData.Parameters.AddWithValue("@age", citoyen.Age);
            getData.Parameters.AddWithValue("@adresse", citoyen.Address);
            getData.Parameters.AddWithValue("@n_tele", citoyen.N_tele);
            getData.Parameters.AddWithValue("@date_naissance", citoyen.Date_naissance);
            getData.Parameters.AddWithValue("@date_deces", citoyen.Date_deces);
            using (connection.Cnn)
            {
                using (getData)
                {
                    getData.ExecuteNonQuery();
                }
            }

        }

        public List<Consultation> getAllConsultation()
        {

            connection.Cnn.Open();
            List<Consultation> consultations = new List<Consultation>();
            string query = "SELECT * FROM consultation";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            using (connection.Cnn)
            {
                connection.Cnn.Open();
                using (getData)
                {
                    using (SqlDataReader reader = getData.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Consultation consultation = new Consultation(reader.GetInt32("id"), reader.GetString("synthese"),
                                reader.GetString("date_consultation"),
                                reader.GetString("etat_couleur"),
                                reader.GetString("cin_citoyen"));
                        }
                    }
                }
                connection.Cnn.Close();
            }

            return Consultaion;
        }

        public Consultation addConsultaion(Consultation consultation)
        {
            connection.Cnn.Open();
            string query = "INSERT INTO consultation(id,synthese,date_consultation,etat_couleur,cin_citoyen) VALUES (@id,@synthese,@date_consultation,@etat_couleur,@cin_citoyen)";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            getData.Parameters.AddWithValue("@id", consultation.id);
            getData.Parameters.AddWithValue("@synthese",consultation.Synthese);
            getData.Parameters.AddWithValue("@date_consultation", consultation.Date_consultation);
            getData.Parameters.AddWithValue("@etat_couleur", consultation.Etat_couleur);
            getData.Parameters.AddWithValue("@cin_citoyen", consultation.cin_consultation);

 
            using (connection.Cnn)
            {
                using (getData)
                {
                    getData.ExecuteNonQuery();
                }
            }
            return consultation;
        }


        public List<AntecedentMedical> getAllAntecedentMedical()
        {

            connection.Cnn.Open();
            List<AntecedentMedical> AntecedentMedical = new List<AntecedentMedical>();
            string query = "SELECT * FROM AntecedentMedical";
            SqlCommand getData = new SqlCommand(query, connection.Cnn);
            using (connection.Cnn)
            {
                connection.Cnn.Open();
                using (getData)
                {
                    using (SqlDataReader reader = getData.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AntecedentMedical antecedentMedical = new AntecedentMedical(reader.GetInt32("id"), reader.GetString("nomMaladie"),
                                reader.GetString("medcintraitant"),
                                reader.GetString("lieu"),
                                reader.GetDateTime("date"),
                                reader.GetString("etat")

                                );
                        }
                    }
                }
                connection.Cnn.Close();
            }

            return AntecedentMedical;
        }
    }
}
