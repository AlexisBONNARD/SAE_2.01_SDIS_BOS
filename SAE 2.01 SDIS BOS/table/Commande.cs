using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Commande:Icrud
    {
        private int numCommande;
        private int numTransport;
        private int numCaserne;
        private DateTime dateCommande;
        private DateTime dateLivraison;

        public Commande(int numCommande, int numTransport, int numCaserne, DateTime dateCommande, DateTime dateLivraison)
        {
            this.NumCommande = numCommande;
            this.NumTransport = numTransport;
            this.NumCaserne = numCaserne;
            this.DateCommande = dateCommande;
            this.DateLivraison = dateLivraison;
        }

        public int NumCommande
        {
            get
            {
                return this.numCommande;
            }

            set
            {
                this.numCommande = value;
            }
        }

        public int NumTransport
        {
            get
            {
                return this.numTransport;
            }

            set
            {
                this.numTransport = value;
            }
        }

        public int NumCaserne
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

        public DateTime DateCommande
        {
            get
            {
                return this.dateCommande;
            }

            set
            {
                this.dateCommande = value;
            }
        }

        public DateTime DateLivraison
        {
            get
            {
                return this.dateLivraison;
            }

            set
            {
                this.dateLivraison = value;
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
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

        int Icrud.ToString()
        {
            throw new NotImplementedException();
        }
    }
}
