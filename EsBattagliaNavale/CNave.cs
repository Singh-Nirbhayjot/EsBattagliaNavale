using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{
    public class CNave : CCella
    {
        public int IdNave { get; set; }
        public int DimensioneNave { get; set; }
        public CNave(int riga, int colonna, int idNave, int dimensioneNave) : base(riga, colonna)
        {
            IdNave = idNave;
            DimensioneNave = dimensioneNave;
        }
        public override string Colpito()
        {
            return "Colpito in posizione (" + Riga + "," + Colonna + ") - Nave da " + DimensioneNave;
        }
    }
}
