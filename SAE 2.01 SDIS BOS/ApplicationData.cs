

using Npgsql;
using SAE_2._01_SDIS_BOS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{

    public class ApplicationData
    {

        private ObservableCollection<Sapeur> lesSapeurs = new ObservableCollection<Sapeur>();
        private NpgsqlConnection connexion = null;   // futur lien à la BD
        private string login;
        private string password;


        public ObservableCollection<Sapeur> LesSapeurs
        {
            get
            {
                return this.lesSapeurs;
            }

            set
            {
                this.lesSapeurs = value;
            }
        }

        public NpgsqlConnection Connexion
        {
            get
            {
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public ApplicationData()
        {

            //this.ConnexionBD();
           // this.Read();
        }
        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = $"Server=srv-peda-new; port=5433; Database=SDIS; Search Path = SDIS; uid={Login};password={Password}";
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                // juste pour le debug : à transformer en MsgBox 
            }
        }
        public int Read()
        {
            String sql = "SELECT NUM_SAPEUR,NUM_CASERNE,LOGIN_SAPEUR,MDP_SAPEUR  FROM Sapeur where ";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
            {
        }

        public int Create()
        {
            throw new  NotImplementedException();


        }
        public int Update()
        {
            throw new NotImplementedException();
        }
        

        public int Delete()
        {
           throw new NotImplementedException();
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
    }
}
