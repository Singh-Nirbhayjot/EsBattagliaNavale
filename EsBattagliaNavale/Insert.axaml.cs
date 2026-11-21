using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace EsBattagliaNavale
{
    public partial class Insert : UserControl
    {
        private CCampo campo;
        private MainWindow mainWindow;
        private Button[,] bottoni;
        private List<int> naviDaInserire;

        public Insert()
        {
            InitializeComponent();
        }
        public Insert(CCampo campoGioco, MainWindow main)
        {
            InitializeComponent();

            campo = campoGioco;
            mainWindow = main;

            naviDaInserire = new List<int>();
            naviDaInserire.Add(4);
            naviDaInserire.Add(3);
            naviDaInserire.Add(3);
            naviDaInserire.Add(2);
            naviDaInserire.Add(2);
            naviDaInserire.Add(1);

            CreaGriglia();
            TxtIstruzioni.Text = "Posiziona nave da: " + naviDaInserire[0];
        }
        private void CreaGriglia()
        {
            bottoni = new Button[campo.Dimensione, campo.Dimensione];

            for (int r = 0; r < campo.Dimensione; r++)
            {
                for (int c = 0; c < campo.Dimensione; c++)
                {
                    Button b = new Button();
                    b.Width = 30;
                    b.Height = 30;
                    b.Background = Brushes.LightBlue;
                    b.Tag = campo.Griglia[r, c];
                    b.Click += OnClickBottone;

                    GrigliaCampo.Children.Add(b);
                    bottoni[r, c] = b;
                }
            }
        }
        private void OnClickBottone(object sender, RoutedEventArgs e)
        {
            if (naviDaInserire.Count == 0)
            {
                return;
            }

            Button b = (Button)sender;
            CCella cella = (CCella)b.Tag;
            bool orizzontale = ChkOrizzontale.IsChecked == true;

            bool inserita = campo.PosizionaNave(naviDaInserire[0], cella.Riga, cella.Colonna, orizzontale);

            if (inserita)
            {
                for (int r = 0; r < campo.Dimensione; r++)
                {
                    for (int c = 0; c < campo.Dimensione; c++)
                    {
                        if (campo.Griglia[r, c] is CNave)
                        {
                            bottoni[r, c].Background = Brushes.Gray;
                        }
                    }
                }

                naviDaInserire.RemoveAt(0);

                if (naviDaInserire.Count == 0)
                {
                    TxtIstruzioni.Text = "Navi finite!";
                    BtnConferma.IsEnabled = true;
                }
                else
                {
                    TxtIstruzioni.Text = "Posiziona nave da: " + naviDaInserire[0];
                }
            }
        }
        private void OnClickConferma(object sender, RoutedEventArgs e)
        {
            mainWindow.AbilitaGioco();
        }
    }
}