

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
using System.Windows;

namespace SAE_2._01_SDIS_BOS
{

    public class ApplicationData
    {

        private ObservableCollection<Sapeur> lesSapeurs = new ObservableCollection<Sapeur>();
        private ObservableCollection<Materiel> lesMatériel = new ObservableCollection<Materiel>();
        private ObservableCollection<Commande> lesCommandes = new ObservableCollection<Commande>();
        private ObservableCollection<Panier> lePanier= new ObservableCollection<Panier>();
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

        public ObservableCollection<Panier> LePanier
        {
            get
            {
                return this.lePanier;
            }

            set
            {
                this.lePanier = value;
            }
        }

        public ApplicationData()
        {
            if (((MainWindow)Application.Current.MainWindow).FenetreAOuvrir == "Jeux")
            {
                LesSapeurs = Sapeur.Read();
                LesCommandes = Commande.Read();
                LesMatériel = Materiel.Read();
                LePanier = ((MainWindow)Application.Current.MainWindow).LePanier;
                
            }

        }



       

    }
}
