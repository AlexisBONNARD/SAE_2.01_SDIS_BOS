using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Materiel:Icrud
    {
        private int numMateriel;
        private int numFournisseur;
        private string codeType;
        private string descriptionMateriel;
        private string lienPhoto;
        private string description;
        private double prix;

        public Materiel(int numMateriel, int numFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string description, double prix)
        {
            this.NumMateriel = numMateriel;
            this.NumFournisseur = numFournisseur;
            this.CodeType = codeType;
            this.DescriptionMateriel = descriptionMateriel;
            this.LienPhoto = lienPhoto;
            this.Description = description;
            this.Prix = prix;
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

        public int NumFournisseur
        {
            get
            {
                return this.numFournisseur;
            }

            set
            {
                this.numFournisseur = value;
            }
        }

        public string CodeType
        {
            get
            {
                return this.codeType;
            }

            set
            {
                this.codeType = value;
            }
        }

        public string DescriptionMateriel
        {
            get
            {
                return this.descriptionMateriel;
            }

            set
            {
                this.descriptionMateriel = value;
            }
        }

        public string LienPhoto
        {
            get
            {
                return this.lienPhoto;
            }

            set
            {
                this.lienPhoto = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
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
