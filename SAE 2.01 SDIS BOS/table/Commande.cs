using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Commande
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
        public Commande(int numCommande, int numTransport, int numCaserne, DateTime dateCommande)
        {
            this.NumCommande = numCommande;
            this.NumTransport = numTransport;
            this.NumCaserne = numCaserne;
            this.DateCommande = dateCommande;
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

        public int Create(Commande c )
        {
            String sql = $"insert into Commande (NUM_TRANSPORT , NUM_CASERNE,DATE_COMMANDE,DATE_LIVRAISON)  values ('{c.numTransport}','{c.NumCaserne}','{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day},'{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}')";
            return DataAccess.Instance.SetData(sql);
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public static ObservableCollection<Commande> Read()
        {
            Sapeur sapeur = Sapeur.Read()[0];
            ObservableCollection<Commande> lesCommandes = new ObservableCollection<Commande>();
            String sql = $"SELECT NUM_COMMANDE,NUM_TRANSPORT,NUM_CASERNE,DATE_COMMANDE,DATE_LIVRAISON FROM COMMANDE WHERE NUM_CASERNE = {sapeur.NumCasene} ";
            DataTable dt = DataAccess.Instance.GetData(sql);

            foreach (DataRow res in dt.Rows)
            {
                Commande nouveau = new Commande(int.Parse(res["NUM_COMMANDE"].ToString()),
                int.Parse(res["NUM_TRANSPORT"].ToString()), int.Parse(res["NUM_CASERNE"].ToString()), DateTime.Parse(res["DATE_LIVRAISON"].ToString()), DateTime.Parse(res["DATE_LIVRAISON"].ToString()));
                lesCommandes.Add(nouveau);
            }

            return lesCommandes;
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

       

    }
}
