

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
        private ObservableCollection<Materiel> lesMatériel = new ObservableCollection<Materiel>();
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

        public ObservableCollection<Materiel> LesMatériel
        {
            get
            {
                return this.lesMatériel;
            }

            set
            {
                this.lesMatériel = value;
            }
        }

        public ApplicationData()
        {

            //this.ConnexionBD();
           // this.Read();
        }
        public void ConnexionBD(string login ,string password)
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = $"Server=srv-peda-new; port=5433; Database=SDIS; Search Path = SDIS; uid={login};password={password}";
                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                return;
                // juste pour le debug : à transformer en MsgBox 
            }
        }
        public int Read(string login)
        {
            String sql = $"SELECT NUM_SAPEUR,NUM_CASERNE,LOGIN_SAPEUR,MDP_SAPEUR  FROM Sapeur where LOGIN_SAPEUR ='{login}' ";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Sapeur nouveau = new Sapeur(int.Parse(res["NUM_SAPEUR"].ToString()),
                    int.Parse(res["NUM_CASERNE"].ToString()), res["LOGIN_SAPEUR"].ToString(), res["MDP_SAPEUR"].ToString());
                    LesSapeurs.Add(nouveau);
                }
               
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadNumSapeur(string login)
        {
            int id = 0;
            String sql = $"SELECT NUM_CASERNE FROM Sapeur where LOGIN_SAPEUR ='{login}' ";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {

                    id = int.Parse(res["NUM_CASERNE"].ToString());
                }

                return id;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
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
