﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_2._01_SDIS_BOS
{
   public class Caracteristique:Icrud
    {
        private int numCaracteristique;
        private string nomCaracteristique;

        public int NumCaracteristique
        {
            get
            {
                return this.numCaracteristique;
            }

            set
            {
                this.numCaracteristique = value;
            }
        }

        public string NomCaracteristique
        {
            get
            {
                return this.nomCaracteristique;
            }

            set
            {
                this.nomCaracteristique = value;
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