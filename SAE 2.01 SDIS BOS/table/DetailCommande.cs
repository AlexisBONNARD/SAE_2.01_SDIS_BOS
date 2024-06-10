using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class DetailCommande:Icrud
    {
        private int numCommande;
        private int numMateriel;
        private double quantite;

        public DetailCommande(int numCommande, int numMateriel, double quantite)
        {
            this.NumCommande = numCommande;
            this.NumMateriel = numMateriel;
            this.Quantite = quantite;
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

        public int Create(DetailCommande dt)
        {
            String sql = $"insert into Deta (NUM_COMMANDE , NUM_MATERIEL,QUANTITE)  values ({dt.NumCommande},{dt.NumMateriel},{dt.Quantite})";
            return DataAccess.Instance.SetData(sql);
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
