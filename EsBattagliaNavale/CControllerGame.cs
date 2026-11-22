using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace EsBattagliaNavale
{
    public class CControllerGame
    {
        public event Action? RichiestaReset;
        private Game vista;
        private CCampo campo;
        private int mosse = 0;

        public CControllerGame(Game vistaGame, CCampo campoGioco)
        {
            vista = vistaGame;
            campo = campoGioco;

            vista.TxtNavi.Text = "Navi non affondate: " + campo.ContaNaviNonAffondate();
            vista.RichiestaReset += InoltraReset;

            for (int r = 0; r < campo.Dimensione; r++)
            {
                for (int c = 0; c < campo.Dimensione; c++)
                {
                    Button b = vista.CreaBottone(r, c);

                    if (campo.IsNave(r, c))
                    {
                        b.Click += OnClickNave;
                    }
                    else
                    {
                        b.Click += OnClickAcqua;
                    }

                    b.Click += ControlloVittoria;
                }
            }
        }

        private void OnClickNave(object? sender, RoutedEventArgs e)
        {
            Button b = (Button)sender!;
            int[] coord = (int[])b.Tag!;

            b.IsEnabled = false;
            b.Content = "N";
            b.Background = Brushes.Red;

            string msg = campo.Colpisci(coord[0], coord[1]);
            AggiornaStato(msg);
        }

        private void OnClickAcqua(object? sender, RoutedEventArgs e)
        {
            Button b = (Button)sender!;
            int[] coord = (int[])b.Tag!;

            b.IsEnabled = false;
            b.Content = "A";
            b.Background = Brushes.White;

            string msg = campo.Colpisci(coord[0], coord[1]);
            AggiornaStato(msg);
        }

        private void ControlloVittoria(object? sender, RoutedEventArgs e)
        {
            if (campo.ControllaVittoria())
            {
                vista.ScriviLog("Bravo Hai Vinto!");
                vista.DisabilitaTuttiBottoni();
                vista.BtnReset.IsVisible = true;
            }
        }

        private void AggiornaStato(string messaggio)
        {
            mosse++;
            vista.TxtMosse.Text = "Mosse: " + mosse;
            vista.TxtNavi.Text = "Navi non affondate: " + campo.ContaNaviNonAffondate();
            vista.ScriviLog(messaggio);
        }

        private void InoltraReset()
        {
            if (RichiestaReset != null)
            {
                RichiestaReset();
            }
        }
    }
}
