using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class DetailCaracteristique:Icrud
    {
        private int numMateriel;
        private int  numCarateristique;
        private double valeur;

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

        public int NumCarateristique
        {
            get
            {
                return this.numCarateristique;
            }

            set
            {
                this.numCarateristique = value;
            }
        }

        public double Valeur
        {
            get
            {
                return this.valeur;
            }

            set
            {
                this.valeur = value;
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
