using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Sapeur:Icrud
    {
        private int numSapeur;
        private int numCasene;
        private string loginCaserne;
        private string mdpCaserne;

        public int NumSapeur
        {
            get
            {
                return this.numSapeur;
            }

            set
            {
                this.numSapeur = value;
            }
        }

        public int NumCasene
        {
            get
            {
                return this.numCasene;
            }

            set
            {
                this.numCasene = value;
            }
        }

        public string LoginCaserne
        {
            get
            {
                return this.loginCaserne;
            }

            set
            {
                this.loginCaserne = value;
            }
        }

        public string MdpCaserne
        {
            get
            {
                return this.mdpCaserne;
            }

            set
            {
                this.mdpCaserne = value;
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
