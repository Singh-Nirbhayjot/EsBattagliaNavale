using System;
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
        public event Action<int, int>? CasellaCliccata;
        private Button[,] bottoni = new Button[10, 10];

        public bool IsOrizzontale
        {
            get { return ChkOrizzontale.IsChecked == true; }
        }

        public Insert()
        {
            InitializeComponent();

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    Button b = new Button();
                    b.Width = 28;
                    b.Height = 28;
                    b.Background = Brushes.LightBlue;
                    b.Tag = new int[] { r, c };
                    b.Click += OnClickBottone;

                    GrigliaCampo.Children.Add(b);
                    bottoni[r, c] = b;
                }
            }
        }

        private void OnClickBottone(object? sender, RoutedEventArgs e)
        {
            Button b = (Button)sender!;
            int[] coord = (int[])b.Tag!;
            if (CasellaCliccata != null)
            {
                CasellaCliccata(coord[0], coord[1]);
            }
        }

        public void ColoraNave(int r, int c)
        {
            bottoni[r, c].Background = Brushes.Gray;
        }
        public void NascondiNavi()
        {
            foreach (Button b in bottoni)
            {
                b.Background = Brushes.LightBlue;
            }
        }
    }
}