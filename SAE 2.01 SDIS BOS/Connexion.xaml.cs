using Npgsql;
using P3_BD_PostGRESQL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Connexion : Window
    {
        private string login;
        private string password;

        public Connexion()
        {
            InitializeComponent();
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



        public bool Read()
        {
         
        }


        public int Update()
        {
            throw new NotImplementedException();
        }

        private void Button_Connexion_Valid(object sender, RoutedEventArgs e)
        {
            /*
            //this.Fenetre.FenetreAOuvrir = "Stop";
            this.DialogResult = true;

            try
            {
                //connexion.Read();
            }
            catch (Exception err)
            {
                Console.WriteLine("Erreur lors de la conection à la base de données");
                return;
            }
           : if (connexion.Read())
            {
                ((MainWindow)Application.Current.MainWindow).FenetreAOuvrir = "Jeux";
            }
            else
            {
                MessageBox.Show(this, "Erreur", "Vérifiez vos informations.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            */

        }


    }
}
