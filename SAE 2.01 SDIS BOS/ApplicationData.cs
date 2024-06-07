

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

    }
}
