using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace SAE_2._01_SDIS_BOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // string pour les ouverture des fenétre
        private String fenetreAOuvrir;
        private int quantite;
        public String FenetreAOuvrir
        
        {
            get { return fenetreAOuvrir; }
            set
            {
                if (value != "Connexion" && value != "Jeux" && value != "Quiter")
                    throw new ArgumentNullException("bruh");
                fenetreAOuvrir = value;
            }
        }

        public string NumCaserne
        {
            get
            {
                return this.numCaserne;
            }

            set
            {
                this.numCaserne = value;
            }
        }

        private String numCaserne;
        
        public bool quitter = false;
        public bool jouer = false;


        public MainWindow()
        {
            FenetreAOuvrir = "Connexion";
            OuvertureFenetre();
            InitializeComponent();
            lbNumCaserne.Content = $"N° {numCaserne}";
            Sapeur.Read();
            Commande.Read();
            dgCommande.Items.Filter = ContientMotClef;
            dataGridmaterielCree.Items.Filter = ContientMotClefMateriel;
            

        }
        private void ButtonConection(object sender, RoutedEventArgs e)
        {
            //this.Fenetre.FenetreAOuvrir = "Stop";
            FenetreAOuvrir = "Connexion";
            OuvertureFenetre();
            lbNumCaserne.Content = $"N° {numCaserne}";

        }
        private bool ContientMotClef(object obj)
        {
            Commande uneCommande = obj as Commande;
            if (String.IsNullOrEmpty(textRechercherConsulter.Text))
                return true;
            else
                return (uneCommande.NumCommande.ToString().StartsWith(textRechercherConsulter.Text, StringComparison.OrdinalIgnoreCase) ||
                    uneCommande.NumCommande.ToString().StartsWith(textRechercherConsulter.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool ContientMotClefMateriel(object obj)
        {
            Materiel unMateriel = obj as Materiel;
            if (String.IsNullOrEmpty(textRechercherCree.Text))
                return true;
            else
                return (unMateriel.NomFournisseur.StartsWith(textRechercherCree.Text, StringComparison.OrdinalIgnoreCase) ||
                    unMateriel.NomFournisseur.StartsWith(textRechercherCree.Text, StringComparison.OrdinalIgnoreCase));
        }



        public void OuvertureFenetre()
        {
            jouer = false;
            while (!quitter && !jouer)
            {
                switch (fenetreAOuvrir)
                {
                    case "Connexion":
                        {
                            //activation Parametre
                            Connexion connexion = new Connexion();
                            connexion.ShowDialog();
                            break;
                        }
                    case "Jeux":
                        {
                            jouer = true;
                            break;
                        }
                    case "Quiter":
                        {
                            quitter = true;
                            break;
                        }
                }
            }
#if DEBUG
            Console.WriteLine(fenetreAOuvrir + " est ouvert");
#endif

            if (quitter)
            {
#if DEBUG
                Console.WriteLine(fenetreAOuvrir + " pour tuer laplication");
#endif
                Application.Current.Shutdown();
            }

        }

        private void dgCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCommande.SelectedItem != null)
            {
                Commande commande = (Commande)dgCommande.SelectedItem;

                dtDateLivraison.SelectedDate = commande.DateLivraison;

            }
        }

        private void textRechercherConsulter_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
                CollectionViewSource.GetDefaultView(dgCommande.ItemsSource).Refresh();
            

        }

        private void mainwindows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataAccess.Instance.DeconnexionBD();
            Application.Current.Shutdown();
        }

        private void textRechercherCree_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridmaterielCree.ItemsSource).Refresh();
        }

       
        private void UpdatePrixLabel()
        {
            if (dataGridmaterielCree.SelectedItem != null)
            {
                Materiel commande = (Materiel)dataGridmaterielCree.SelectedItem;
                labelPrixmaterielCree.Content = $"Prix Materiel : {commande.Prix * quantite}€";
            }
        }



        private void sliderQuantiteCree_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            quantite = (int)sliderQuantiteCree.Value;
            UpdatePrixLabel();

        }

        private void dataGridmaterielCree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrixLabel();
        }
    }
}
