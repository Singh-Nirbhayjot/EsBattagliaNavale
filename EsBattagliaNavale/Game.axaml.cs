using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace EsBattagliaNavale
{
    public partial class Game : UserControl
    {
        public event Action? RichiestaReset;
        private Button[,] bottoni = new Button[10, 10];

        public Game()
        {
            InitializeComponent();
        }

        public Button CreaBottone(int r, int c)
        {
            Button b = new Button();
            b.Width = 28;
            b.Height = 28;
            b.Background = Brushes.LightBlue;
            b.Tag = new int[] { r, c };

            GrigliaCampo.Children.Add(b);
            bottoni[r, c] = b;
            return b;
        }

        public void DisabilitaTuttiBottoni()
        {
            foreach (Button b in bottoni)
            {
                b.IsEnabled = false;
            }
        }

        public void ScriviLog(string testo)
        {
            TxtLog.Text = testo + "\n" + TxtLog.Text;
        }

        private void OnClickReset(object? sender, RoutedEventArgs e)
        {
            if (RichiestaReset != null)
            {
                RichiestaReset();
            }
        }
    }
}