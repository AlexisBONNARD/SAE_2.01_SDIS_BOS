using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
    public interface Icrud
    {

        public int Create();
        public int Delete();
        public int Read();
        public int ToString();
        public int Update();
    }
}
