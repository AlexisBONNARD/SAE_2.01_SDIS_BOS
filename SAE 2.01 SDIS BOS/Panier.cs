using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Panier
    {
        private string lienImage;
        private int quantite;
        private double prixAchat;
        private string nomFournisseur;
        private string modeLivraison;

        public Panier(string lienImage, int quantite, double prixAchat, string nomFournisseur, string modeLivraison)
        {
            this.LienImage = lienImage;
            this.Quantite = quantite;
            this.PrixAchat = prixAchat;
            this.NomFournisseur = nomFournisseur;
            this.ModeLivraison = modeLivraison;
        }

        public string LienImage
        {
            get
            {
                return this.lienImage;
            }

            set
            {
                this.lienImage = value;
            }
        }

        public int Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                this.quantite = value;
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

        public string NomFournisseur
        {
            get
            {
                return this.nomFournisseur;
            }

            set
            {
                this.nomFournisseur = value;
            }
        }

        public string ModeLivraison
        {
            get
            {
                return this.modeLivraison;
            }

            set
            {
                this.modeLivraison = value;
            }
        }
    }
}
