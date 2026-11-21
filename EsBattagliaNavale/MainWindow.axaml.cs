using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using EsBattagliaNavale;

namespace EsBattagliaNavale;

public partial class MainWindow : Window
{
    private CCampo campo;
    private Insert controlloInsert;
    private Game controlloGame;

    public MainWindow()
    {
        InitializeComponent();
        campo = new CCampo();
    }

    private void OnClickInsert(object sender, RoutedEventArgs e)
    {
        controlloInsert = new Insert(campo, this);
        AreaContenuto.Content = controlloInsert;
    }

    private void OnClickGame(object sender, RoutedEventArgs e)
    {
        controlloGame = new Game(campo, this);
        AreaContenuto.Content = controlloGame;
    }
    public void AbilitaGioco()
    {
        BtnInsert.IsEnabled = false;
        BtnGame.IsEnabled = true;
        AreaContenuto.Content = null;
    }
    public void PartitaVinta()
    {
        BtnInsert.IsEnabled = true;
        BtnGame.IsEnabled = false;
        AreaContenuto.Content = null;
        campo = new CCampo();
    }
}
