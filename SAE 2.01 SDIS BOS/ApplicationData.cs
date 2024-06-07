

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
        private ObservableCollection<Commande> lesCommandes = new ObservableCollection<Commande>();
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

        public ObservableCollection<Commande> LesCommandes
        {
            get
            {
                return this.lesCommandes;
            }

            set
            {
                this.lesCommandes = value;
            }
        }

        public ApplicationData()
        {

            LesSapeurs = Sapeur.Read();
            LesCommandes = Commande.Read();
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
        /*
        public int ReadMateriel()
        {
            String sql = $"SELECT NUM_MATERIEL,NUM_FOURNISSEUR, CODE_TYPE,DESCRIPTION_MATERIEL, ";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {

                    Materiel nouveau = new Materiel(int.Parse(res["NUM_SAPEUR"].ToString()),
                    int.Parse(res["NUM_CASERNE"].ToString()), res["LOGIN_SAPEUR"].ToString(), res["MDP_SAPEUR"].ToString());
                    LesMatériel.Add(nouveau);
                }

                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        
        }
        */
        public int ReadCommande(int numcaserne)
        {
            String sql = $"SELECT NUM_COMMANDE,NUM_TRANSPORT,NUM_CASERNE,DATE_COMMANDE,DATE_LIVRAISON FROM COMMANDE WHERE NUM_CASERNE = {numcaserne} ";
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = $"Server=srv-peda-new; port=5433; Database=SDIS; Search Path = SDIS; uid=selmaner;password=ip1PIB";
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {

                    Commande nouveau = new Commande(int.Parse(res["NUM_COMMANDE"].ToString()),
                    int.Parse(res["NUM_TRANSPORT"].ToString()), int.Parse(res["NUM_CASERNE"].ToString()), DateTime.Parse(res["DATE_COMMANDE"].ToString()), DateTime.Parse(res["DATE_LIVRAISON"].ToString()));
                    LesCommandes.Add(nouveau);
                }

                return dataTable.Rows.Count;
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
