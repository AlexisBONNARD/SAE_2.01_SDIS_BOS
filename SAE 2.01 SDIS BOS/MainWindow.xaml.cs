using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private double prixAchat;
        private int quantiteAchat;
        private ObservableCollection<Panier> lePanier = new ObservableCollection<Panier>();
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

        public double PrixAchat
        {
            get
            {
                return this.prixAchat;
            }

            set
            {
                this.prixAchat = value;
            }
        }

        public int QuantiteAchat
        {
            get
            {
                return this.quantiteAchat;
            }

            set
            {
                this.quantiteAchat = value;
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
                PrixAchat = commande.Prix * QuantiteAchat;

                labelPrixmaterielCree.Content = $"Prix Materiel : {PrixAchat}€";
            }
        }



        private void sliderQuantiteCree_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            QuantiteAchat = (int)sliderQuantiteCree.Value;
            UpdatePrixLabel();

        }

        private void dataGridmaterielCree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrixLabel();
        }

        private void butAjouterCree_Click(object sender, RoutedEventArgs e)
        {
            int numlivraison = 0;

            MessageBoxResult res =   MessageBox.Show(this,"Information", "Voulez vous confimer votre commande ?", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(radioButCamionCree.IsChecked == true)
            {
                numlivraison = 1;
            }
            else if (radioButVoitureCree.IsChecked == true)
            {
                numlivraison = 2;
            }

            if(res == MessageBoxResult.OK)
            {
                Materiel materiel = (Materiel)dataGridmaterielCree.SelectedItem;
                Panier panier = new Panier(materiel,quantiteAchat,numlivraison);
                data.LePanier.Add(panier);
                CalculePrixPanier();





            }
        }

        private void butSuprimerCree_Click(object sender, RoutedEventArgs e)
        {
            LePanier.Clear();
            CalculePrixPanier();
        }

        private void butAnnulerCree_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridCommandeCree.SelectedItem !=null)
            {
               LePanier.Remove((Panier) dataGridCommandeCree.SelectedItem);
                CalculePrixPanier();
            }
        }

        private void butValiderCree_Click(object sender, RoutedEventArgs e)
        {
            
          for(int i =0; i<LePanier.Count;i++)
            {
                Commande c = new Commande(data.getNumCommande()+1, lePanier[i].Numtransport,int.Parse(NumCaserne), DateTime.Now,DateTime.Now);
                DetailCommande dc = new DetailCommande(data.getNumCommande()+1,LePanier[i].UnMateriel.NumMateriel,LePanier[i].Quantite);
                data.LesCommandes.Add(c);
                c.Create(c);
            }
            LePanier.Clear();
            UpdatePrixLabel();

        }

        public void CalculePrixPanier()
        {
            double nb = 0;
            foreach (Panier pn in LePanier)
            {
                if (LePanier.Count > 0)
                {
                    nb += pn.UnMateriel.Prix * pn.Quantite;
                }
            }
        
        labelPrixTotalCree.Content = $"Prix total {nb}€";
        }
    }
}
