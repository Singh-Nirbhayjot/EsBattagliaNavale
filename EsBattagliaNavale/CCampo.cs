using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{
    public class CCampo
    {
        public int Dimensione { get; set; }
        public CCella[,] Griglia { get; set; }

        public CCampo()
        {
            Dimensione = 10;
            Griglia = new CCella[Dimensione, Dimensione];

            for (int r = 0; r < Dimensione; r++)
            {
                for (int c = 0; c < Dimensione; c++)
                {
                    Griglia[r, c] = new CAcqua(r, c);
                }
            }
        }

        public bool PosizionaNave(int dimensioneNave, int riga, int colonna, bool orizzontale)
        {
            if (orizzontale && colonna + dimensioneNave > Dimensione)
            {
                return false;
            }

            if (!orizzontale && riga + dimensioneNave > Dimensione)
            {
                return false;
            }

            for (int i = 0; i < dimensioneNave; i++)
            {
                int r = riga;
                int c = colonna;

                if (orizzontale)
                {
                    c = colonna + i;
                }
                else
                {
                    r = riga + i;
                } 

                if (Griglia[r, c] is CNave)
                {
                    return false;
                }
            }

            for (int i = 0; i < dimensioneNave; i++)
            {
                int r = riga;
                int c = colonna;

                if (orizzontale)
                {
                    c = colonna + i;
                }
                else
                {
                    r = riga + i;
                }
                Griglia[r, c] = new CNave(r, c, dimensioneNave);
            }
            return true;
        }
    }
}
