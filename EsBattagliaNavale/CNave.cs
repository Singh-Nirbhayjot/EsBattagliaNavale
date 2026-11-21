using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{
    public class CNave : CCella
    {
        public int DimensioneNave { get; set; }
        public CNave(int riga, int colonna, int dimensioneNave) : base(riga, colonna)
        {
            DimensioneNave = dimensioneNave;
        }
    }
}
