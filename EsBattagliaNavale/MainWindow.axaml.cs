using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using EsBattagliaNavale;

namespace EsBattagliaNavale;

public partial class MainWindow : Window
{
    private CCampo campo = new CCampo();
    private Insert? vistaInsert;
    private Game? vistaGame;
    private CControllerInsert? controllerInsert;
    private CControllerGame? controllerGame;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnClickInsert(object? sender, RoutedEventArgs e)
    {
        if (vistaInsert == null)
        {
            vistaInsert = new Insert();
            controllerInsert = new CControllerInsert(vistaInsert, campo);
            controllerInsert.FlottaCompleta += AbilitaPartita;
        }

        AreaContenuto.Content = vistaInsert;
    }

    private void OnClickGame(object? sender, RoutedEventArgs e)
    {
        if (vistaGame == null)
        {
            vistaGame = new Game();
            controllerGame = new CControllerGame(vistaGame, campo);
            controllerGame.RichiestaReset += ResetPartita;
        }

        AreaContenuto.Content = vistaGame;
    }

    private void AbilitaPartita()
    {
        BtnGame.IsEnabled = true;
    }

    private void ResetPartita()
    {
        campo = new CCampo();
        vistaInsert = null;
        vistaGame = null;
        controllerInsert = null;
        controllerGame = null;
        BtnGame.IsEnabled = false;
        AreaContenuto.Content = null;
    }
}