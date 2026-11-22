using System;
using System.Collections.Generic;
using System.Text;

namespace EsBattagliaNavale
{
    public class CControllerInsert
    {
        public event Action? FlottaCompleta;
        private Insert vista;
        private CCampo campo;
        private List<int> naviDaInserire = new List<int> { 4, 3, 3, 2, 2, 1 };
        private int idProssimaNave = 1;

        public CControllerInsert(Insert vistaInsert, CCampo campoGioco)
        {
            vista = vistaInsert;
            campo = campoGioco;
            vista.CasellaCliccata += Posiziona;
            vista.TxtIstruzioni.Text = "Posiziona nave da: " + naviDaInserire[0];
        }

        private void Posiziona(int riga, int colonna)
        {
            if (naviDaInserire.Count == 0)
            {
                return;
            }

            bool inserita = campo.PosizionaNave(idProssimaNave, naviDaInserire[0], riga, colonna, vista.IsOrizzontale);

            if (!inserita)
            {
                vista.TxtMessaggio.Text = "Posizione non valida! Riprova.";
                return;
            }

            for (int r = 0; r < campo.Dimensione; r++)
            {
                for (int c = 0; c < campo.Dimensione; c++)
                {
                    if (campo.IsNave(r, c))
                    {
                        vista.ColoraNave(r, c);
                    }
                }
            }

            idProssimaNave++;
            naviDaInserire.RemoveAt(0);

            if (naviDaInserire.Count == 0)
            {
                vista.TxtIstruzioni.Text = "Flotta completa! Premi Avvia Partita.";
                vista.NascondiNavi();
                if (FlottaCompleta != null)
                {
                    FlottaCompleta();
                }
            }
            else
            {
                vista.TxtIstruzioni.Text = "Posiziona nave da: " + naviDaInserire[0];
            }
        }
    }
}
