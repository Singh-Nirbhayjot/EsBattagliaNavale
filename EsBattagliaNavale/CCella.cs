using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{

    public abstract class CCella
    {
        public int Riga { get; set; }
        public int Colonna { get; set; }

        public CCella(int riga, int colonna)
        {
            Riga = riga;
            Colonna = colonna;
        }

        public abstract string Colpito();
    }
}
