using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace covid_console.persistence
{
    class Persistence
    {
        private Connection connection_;

        public Persistence()
        {
            connection_ = new Connection();
        }

        public List<Citoyen> getAllCitoyens()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = connection.Query<Citoyen>($"select * from citoyen_").ToList();
                return output;
            }
        }

        public Citoyen getCitoyen(string cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = connection.QueryFirst<Citoyen>("select * from citoyen_ where cin=@cin", new { cin = cin });
                return output;
            }
        }

        public void addCitoyen(Citoyen citoyen)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                List<Citoyen> people = new List<Citoyen>();

                people.Add(new Citoyen { Cin = citoyen.Cin, Address = citoyen.Address, Age = citoyen.Age, Date_naissance = citoyen.Date_naissance, Nom = citoyen.Nom,Prenom = citoyen.Prenom ,Date_deces = citoyen.Date_deces,N_tele = citoyen.N_tele = citoyen.N_tele});

                connection.Execute("INSERT INTO citoyen_(cin,nom,prenom,age,adresse,n_tele,date_naissance,date_deces) VALUES (@Cin,@Nom, @Prenom,@Age,@Address,@N_tele,@Date_naissance,@Date_deces)", people);

            }
        }

        public void suppCitoyen(string cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Execute("DELETE citoyen_ WHERE cin = @Cin", new { Cin = cin });
            }
        }

        public void modifierCitoyen(string cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                Citoyen citoyen = getCitoyen(cin);
                connection.Execute("Update citoyen_ SET nom=@Nom,prenom=@Prenom,age=@Age,adresse=@Adresse,n_tele=@N_tele,date_naissance=@Date_naissance,date_deces=@Date_deces WHERE cin = @Cin", new Citoyen { Cin = citoyen.Cin, Address = citoyen.Address, Age = citoyen.Age, Date_naissance = citoyen.Date_naissance, Nom = citoyen.Nom, Prenom = citoyen.Prenom, Date_deces = citoyen.Date_deces, N_tele = citoyen.N_tele = citoyen.N_tele });
            }

        }

        public List<Consultation> getAllConsultationByCitoyen(String cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = connection.Query<Consultation>($"select * from consultation where cin_citoyen=@cin", new { Cin = cin }).ToList();
                return output;
            }
        }

        public Consultation getLastConsultationByCitoyen(String cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = connection.QueryFirstOrDefault<Consultation>($"select * from consultation where cin_citoyen=@cin ORDER BY date_consultation desc", new { Cin = cin });
                return output;
            }
        }

        public void addConsultation(Consultation consultation,Action action)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                List<Consultation> consultations = new List<Consultation>();

                consultations.Add(new Consultation { Synthese = consultation.Synthese, Date_consultation = consultation.Date_consultation, Etat_couleur = consultation.Etat_couleur, Cin_citoyen = consultation.Cin_citoyen});
                connection.Execute("INSERT INTO consultation(synthese,date_consultation,etat_couleur,cin_citoyen) VALUES (@Synthese,@Date_consultation, @Etat_couleur,@Cin_citoyen)", consultations);
                addAction(action);
            }

        }

        public void addAction(Action consultation)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {


            }

        }

        public List<AntecedentMedical> getAllAntecedentMedicalByCitoyen(string Cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = connection.Query<AntecedentMedical>($"select * from antecedentmedical where cinCitoyen=@cin", new { cin = Cin }).ToList();
                return output;
            }
        }
        public AntecedentMedical getAntecedentMedical(string Cin)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                AntecedentMedical output = connection.QueryFirst<AntecedentMedical>("select * from antecedentmedical where cinCitoyen=@cin", new { cin = Cin });
                return output;
            }
        }
        public void addAntecedentMedical(AntecedentMedical antecedentMedical)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                List<AntecedentMedical> antecedentMedicals = new List<AntecedentMedical>();

                antecedentMedicals.Add(new AntecedentMedical { Nom_maladie = antecedentMedical.Nom_maladie, Medecin_traitent = antecedentMedical.Medecin_traitent, Lieu = antecedentMedical.Lieu, Date = antecedentMedical.Date, Etat = antecedentMedical.Etat, Citoyen = antecedentMedical.Citoyen });
                connection.Execute("INSERT INTO antecedentmedicale(Nom_maladie,Medecin_traitent,Lieu,Date,Etat,Citoyen) VALUES (@Nom_maladie,@Medecin_traitent,@Lieu,@Date,@Etat,@Citoyen)", antecedentMedicals);

            }

        }
        public void modifierAntecedentmedical(string id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                AntecedentMedical antecedentMedical = getAntecedentMedical(id);
                connection.Execute("Update antecedentmedical SET nom_maladie=@Nom_maladie,medecin_traitent=@Medecin_traitent,lieu=@Lieu,date=@Date,etat=@Etat,citoyen=@Citoyen WHERE id = @id", new AntecedentMedical { Nom_maladie = antecedentMedical.Nom_maladie, Medecin_traitent = antecedentMedical.Medecin_traitent, Lieu = antecedentMedical.Lieu, Date = antecedentMedical.Date, Etat = antecedentMedical.Etat, Citoyen = antecedentMedical.Citoyen });
            }

        }

        public Action getActionByConsultation(int id_cons)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                Action output = connection.QueryFirst<Action>("select * from action_ where id_consultation=@id_cons", new { id_cons = id_cons });
                return output;
            }
        }

        public double[] getStat(){
            Int32 guéri = 0;
            Int32 no_confirmée = 0;
            Int32 malade = 0;
            Int32 total = 0;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                guéri = (Int32)connection.ExecuteScalar("select count(*) from citoyen_ where etat_couleur='#00FF00'");
                no_confirmée = (Int32)connection.ExecuteScalar("select count(*) from citoyen_ where etat_couleur='#FFA500'");
                malade = (Int32)connection.ExecuteScalar("select count(*) from citoyen_ where etat_couleur='#FF0000'");
                total = (Int32)connection.ExecuteScalar("select count(*) from citoyen_");
            }
            double g_perc = Math.Round(((double)guéri / (double)total * 100d),2);
            double nc_perc = Math.Round(((double)no_confirmée / (double)total * 100d), 2);
            double m_perc = Math.Round(((double)malade / (double)total * 100d), 2);
            double[] stat = { g_perc, nc_perc, m_perc, total };
            return stat;
        }
    }
  
}
