using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{
    public delegate void DelegatoClick(int riga, int colonna);
    public class CCella
    {
        public int Riga { get; set; }
        public int Colonna { get; set; }
        public bool Colpita { get; set; }
        public DelegatoClick OnClick { get; set; }

        public CCella(int riga, int colonna)
        {
            Riga = riga;
            Colonna = colonna;
            Colpita = false;
        }

        public void EseguiClick()
        {
            if (OnClick != null)
            {
                OnClick(Riga, Colonna);
            }
        }
    }
}
