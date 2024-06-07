using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Panier
    {
        private Materiel unMateriel;
        private double quantite;
        private int numtransport;

        public Panier(Materiel unMateriel, double quantite, int numtransport)
        {
            this.UnMateriel = unMateriel;
            this.Quantite = quantite;
            this.Numtransport = numtransport;
        }

        public Materiel UnMateriel
        {
            get
            {
                return this.unMateriel;
            }

            set
            {
                this.unMateriel = value;
            }
        }

        public double Quantite
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

        public int Numtransport
        {
            get
            {
                return this.numtransport;
            }

            set
            {
                this.numtransport = value;
            }
        }
    }
}
