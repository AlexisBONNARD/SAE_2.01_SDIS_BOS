using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class DetailCommande
    {
        private int numCommande;
        private int numMateriel;
        private double quantite;
        private string lienImage;
        private double prix;

        public DetailCommande(int numCommande, int numMateriel, double quantite)
        {
            this.NumCommande = numCommande;
            this.NumMateriel = numMateriel;
            this.Quantite = quantite;
        }

        public DetailCommande(int numCommande, int numMateriel, double quantite, string lienImage, double prix) : this(numCommande, numMateriel, quantite)
        {
            this.LienImage = lienImage;
            this.Prix = prix;
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

        public int NumMateriel
        {
            get
            {
                return this.numMateriel;
            }

            set
            {
                this.numMateriel = value;
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

        public double Prix
        {
            get
            {
                return this.prix;
            }

            set
            {
                this.prix = value;
            }
        }

        public int Create(DetailCommande dt)
        {
            String sql = $"insert into DETAIL_COMMANDE (NUM_COMMANDE , NUM_MATERIEL,QUANTITE)  values ({dt.NumCommande},{dt.NumMateriel},{dt.Quantite})";
            return DataAccess.Instance.SetData(sql);
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public static ObservableCollection<DetailCommande> Read()
        {
            ObservableCollection<DetailCommande> lesDetailsCommandes = new ObservableCollection<DetailCommande>();
            String sql = $"SELECT NUM_COMMANDE, m.NUM_MATERIEL,QUANTITE,m.Prix,m.LIEN_PHOTO from DETAIL_COMMANDE dt join MATERIEL m on m.NUM_MATERIEL = dt.NUM_MATERIEL";
            DataTable dt = DataAccess.Instance.GetData(sql);

            foreach (DataRow res in dt.Rows)
            {
                DetailCommande nouveau = new DetailCommande(int.Parse(res["NUM_COMMANDE"].ToString()),
                int.Parse(res["NUM_MATERIEL"].ToString()), int.Parse(res["QUANTITE"].ToString()), res["Prix"].ToString(), double.Parse(res["Prix"].ToString()));
            }

            return lesDetailsCommandes;
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

       
    }
}
