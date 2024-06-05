using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Transport:Icrud
    {
        private int numTransport;
        private string nomTrasnpsort;

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

        public string NomTrasnpsort
        {
            get
            {
                return this.nomTrasnpsort;
            }

            set
            {
                this.nomTrasnpsort = value;
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
