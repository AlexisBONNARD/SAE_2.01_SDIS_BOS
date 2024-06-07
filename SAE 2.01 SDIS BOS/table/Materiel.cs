using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Materiel
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

        public static ObservableCollection<Materiel> Read()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            String sql = $"SELECT NUM_MATERIEL,NUM_FOURNISSEUR,CODE_TYPE,DESCRIPTION_MATERIEL,LIEN_PHOTO,MARQUE,DESCRIPTION,PRIX FROM MATERIEL";
            DataTable dt = DataAccess.Instance.GetData(sql);

            foreach (DataRow res in dt.Rows)
            {
                Materiel nouveau = new Materiel(int.Parse(res["NUM_MATERIEL"].ToString()),
                int.Parse(res["NUM_FOURNISSEUR"].ToString()), res["CODE_TYPE"].ToString(), res["DESCRIPTION_MATERIEL"].ToString(), res["LIEN_PHOTO"].ToString(), res["DESCRIPTION"].ToString(), Double.Parse(res["PRIX"].ToString()));
                lesMateriels.Add(nouveau);
            }

            return lesMateriels;
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

       
    }
}
