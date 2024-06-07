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


        }
        private void ButtonConection(object sender, RoutedEventArgs e)
        {
            //this.Fenetre.FenetreAOuvrir = "Stop";
            FenetreAOuvrir = "Connexion";
            OuvertureFenetre();
            lbNumCaserne.Content = $"N° {numCaserne}";

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

    }
}
