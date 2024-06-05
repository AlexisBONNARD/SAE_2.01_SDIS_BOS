using Npgsql;
using P3_BD_PostGRESQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE_2._01_SDIS_BOS
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window,Icrud
    {
        private string login;
        private string password;

        public Connexion()
        {
            InitializeComponent();
        }

        public Connexion(string login, string password)
        {
            this.Login = login;
            this.Password = password;
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

        public int Create()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

 

        public int Read()
        {
            String sql = $"SELECT * num_sapeur  FROM sapeur  FROM Client where login_sapeur = '{login}' and mdp_sapeur = '{password}' ";
            int nb = 0;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }
       

        public int Update()
        {
            throw new NotImplementedException();
        }

        private void Button_Connexion_Valid(object sender, RoutedEventArgs e)
        {
            //this.Fenetre.FenetreAOuvrir = "Stop";
            this.DialogResult = true;
            ((MainWindow)Application.Current.MainWindow).FenetreAOuvrir = "Jeux";
            Connexion connexion = new Connexion();
        }

        int Icrud.ToString()
        {
            throw new NotImplementedException();
        }
    }
}
