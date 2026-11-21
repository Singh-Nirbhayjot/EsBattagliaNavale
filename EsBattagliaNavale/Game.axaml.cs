using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace EsBattagliaNavale
{
    public partial class Game : UserControl
    {
        private CCampo campo;
        private MainWindow mainWindow;
        private Button[,] bottoni;
        private int mosse;
        private int risultato;
        private bool giocoFinito;

        public Game()
        {
            InitializeComponent();
        }

        public Game(CCampo campoGioco, MainWindow main)
        {
            InitializeComponent();

            campo = campoGioco;
            mainWindow = main;
            mosse = 0;
            risultato = 0;
            giocoFinito = false;

            CreaGriglia();
        }

        private void CreaGriglia()
        {
            bottoni = new Button[campo.Dimensione, campo.Dimensione];

            for (int r = 0; r < campo.Dimensione; r++)
            {
                for (int c = 0; c < campo.Dimensione; c++)
                {
                    CCella cella = campo.Griglia[r, c];

                    if (cella is CNave)
                    {
                        cella.OnClick = FunzioneNave;
                    }
                    else
                    {
                        cella.OnClick = FunzioneAcqua;
                    }

                    Button b = new Button();
                    b.Width = 30;
                    b.Height = 30;
                    b.Background = Brushes.LightBlue;
                    b.Tag = cella;
                    b.Click += OnClickBottone;

                    GrigliaCampo.Children.Add(b);
                    bottoni[r, c] = b;
                }
            }
        }

        private void OnClickBottone(object sender, RoutedEventArgs e)
        {
            if (giocoFinito)
            {
                return;
            }

            Button b = (Button)sender;
            CCella cella = (CCella)b.Tag;

            if (cella.Colpita)
            {
                return;
            }

            cella.Colpita = true;
            mosse++;
            TxtMosse.Text = "Mosse: " + mosse;

            cella.EseguiClick();

            if (risultato == 15)
            {
                giocoFinito = true;
                ScriviLog("Bravo Hai Vinto!");
                TxtRisultato.Text = "Bravo Hai Vinto!";

                mainWindow.PartitaVinta();
            }
        }
        private void FunzioneNave(int riga, int colonna)
        {
            risultato += 1;
            CNave nave = (CNave)campo.Griglia[riga, colonna];

            bottoni[riga, colonna].Background = Brushes.Red;
            TxtRisultato.Text = "Colpiti: " + risultato + " / 15";
            ScriviLog("Colpito in posizione (" + riga + "," + colonna + ") - Nave da " + nave.DimensioneNave);
        }
        private void FunzioneAcqua(int riga, int colonna)
        {
            bottoni[riga, colonna].Background = Brushes.White;
            ScriviLog("Acqua !!");
        }

        private void ScriviLog(string testo)
        {
            TxtLog.Text = testo + "\n" + TxtLog.Text;
        }
    }