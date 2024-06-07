using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public class Sapeur
    {
        private int numSapeur;
        private int numCasene;
        private string loginCaserne;
        private string mdpCaserne;

        public Sapeur(int numSapeur, int numCasene, string loginCaserne, string mdpCaserne)
        {
            this.NumSapeur = numSapeur;
            this.NumCasene = numCasene;
            this.LoginCaserne = loginCaserne;
            this.MdpCaserne = mdpCaserne;
        }

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

        public static ObservableCollection<Sapeur> Read()
        {
            ObservableCollection<Sapeur> lesSapeurs = new ObservableCollection<Sapeur>();
            String sql = $"SELECT NUM_SAPEUR,NUM_CASERNE,LOGIN_SAPEUR,MDP_SAPEUR  FROM Sapeur where LOGIN_SAPEUR ='{DataAccess.Login}' ";
            DataTable dt = DataAccess.Instance.GetData(sql);
          
                foreach (DataRow res in dt.Rows)
                {
                    Sapeur nouveau = new Sapeur(int.Parse(res["NUM_SAPEUR"].ToString()),
                    int.Parse(res["NUM_CASERNE"].ToString()), res["LOGIN_SAPEUR"].ToString(), res["MDP_SAPEUR"].ToString());
                    lesSapeurs.Add(nouveau);
                }

            return lesSapeurs;
            
          
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
