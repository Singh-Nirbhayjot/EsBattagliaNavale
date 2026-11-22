using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{
    public class CCampo
    {
        private CCella[,] griglia;
        public int Dimensione { get; set; }

        public CCampo()
        {
            Dimensione = 10;
            griglia = new CCella[Dimensione, Dimensione];

            for (int r = 0; r < Dimensione; r++)
            {
                for (int c = 0; c < Dimensione; c++)
                {
                    griglia[r, c] = new CAcqua(r, c);
                }
            }
        }

        public bool IsNave(int riga, int colonna)
        {
            return griglia[riga, colonna] is CNave;
        }
        public bool PosizionaNave(int idNave, int dimensioneNave, int riga, int colonna, bool orizzontale)
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

                if (griglia[r, c] is CNave)
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

                griglia[r, c] = new CNave(r, c, idNave, dimensioneNave);
            }

            return true;
        }
        public string Colpisci(int riga, int colonna)
        {
            string messaggio = griglia[riga, colonna].Colpito();

            if (griglia[riga, colonna] is CNave)
            {
                griglia[riga, colonna] = new CAcqua(riga, colonna);
            }

            return messaggio;
        }
        public int ContaNaviNonAffondate()
        {
            List<int> idNaviVive = new List<int>();

            foreach (CCella cella in griglia)
            {
                if (cella is CNave)
                {
                    CNave nave = (CNave)cella;
                    if (!idNaviVive.Contains(nave.IdNave))
                    {
                        idNaviVive.Add(nave.IdNave);
                    }
                }
            }

            return idNaviVive.Count;
        }
        public bool ControllaVittoria()
        {
            foreach (CCella cella in griglia)
            {
                if (cella is CNave)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
