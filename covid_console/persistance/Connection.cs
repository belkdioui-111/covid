using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace covid_console.persistence
{
    class Connection
    {

        private string connetionString;
        private SqlConnection cnn;
      

        public string ConnetionString { get => connetionString; set => connetionString = value; }
        public SqlConnection Cnn { get => cnn; set => cnn = value; }

        public Connection()
        {
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=covid_suivi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
           
        }

        

        
    }

}
