using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace SAE_2._01_SDIS_BOS
{

        public class DataAccess
        {
            private static DataAccess instance;
         
        private static string login;
          private static string password;

            private DataAccess()
            {
            ConnexionBD();
            }
            public static DataAccess Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new DataAccess();
                    }
                    return instance;
                }
            }

        public static string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public static string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public NpgsqlConnection? Connexion
            {
                get;
                set;
            }

      

        public void ConnexionBD()
            {
                try
                {
                    Connexion = new NpgsqlConnection();
                    Connexion.ConnectionString = $"Server=srv-peda-new; port=5433; Database=SDIS; Search Path = SDIS; uid={Login};password={Password}";
                Connexion.Open();
                }
                catch (Exception e)
                {
                MessageBox.Show("Impossible de se connecter à la base de données Veuillez verifier vos identifiant", "Erreur" , MessageBoxButton.OK, MessageBoxImage.Error);
                // juste pour le debug : à transformer en MsgBox 
            }
            }
            public void DeconnexionBD()
            {
                try
                {
                    Connexion.Close();
                }
                catch (Exception e)
                { Console.WriteLine("pb à la déconnexion : " + e); }
            }
          public bool TestConnection()
        {
            bool isConnected = false;
            try
            {
                using (NpgsqlConnection testConnexion = new NpgsqlConnection(Connexion.ConnectionString))
                {
                    testConnexion.Open();
                    testConnexion.Close();
                }
                isConnected = true;
                return isConnected;
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection verification failed: " + e);
                return isConnected;
            }
        }

            public DataTable GetData(string selectSQL)
            {
                try
                {
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception e)
                {
                    Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                    return null;
                }
            }
            public int SetData(string setSQL)
            {

                try
                {
                    NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                    int nbLines = sqlCommand.ExecuteNonQuery();
                    return nbLines;
                }
                catch (Exception e)
                {
                    Console.WriteLine("pb avec : " + setSQL + e.ToString());
                    return 0;
                }
            }
        }
    

}
