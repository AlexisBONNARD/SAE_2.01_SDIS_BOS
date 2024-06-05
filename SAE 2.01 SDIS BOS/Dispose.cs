using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Dispose:Icrud
    {
        private int numMateriel;
        private string nomHabilitation;

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

        public string NomHabilitation
        {
            get
            {
                return this.nomHabilitation;
            }

            set
            {
                this.nomHabilitation = value;
            }
        }
    }
}
