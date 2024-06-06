using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class TypeMateriel:Icrud
    {
        private string codeType;
        private int numcategorie;
        private string materielType;

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

        public int Numcategorie
        {
            get
            {
                return this.numcategorie;
            }

            set
            {
                this.numcategorie = value;
            }
        }

        public string MaterielType
        {
            get
            {
                return this.materielType;
            }

            set
            {
                this.materielType = value;
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
