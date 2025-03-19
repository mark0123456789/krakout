using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace krakout;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double Xseb = 5;
    double Yseb = 5;
    int pontstam = 0;
    public MainWindow()
    {
        InitializeComponent();
        var ido = new DispatcherTimer();
        ido.Interval = TimeSpan.FromMilliseconds(1);
        ido.Tick += Mozgatas;
        ido.Start();
    }

    private void Mozgatas(object? sender, EventArgs e)
    {
        Canvas.SetLeft(jatekos, Mouse.GetPosition(jatekter).X);

        var labdaY = Canvas.GetTop(labda);
        var labdaX = Canvas.GetLeft(labda);
        if (labdaX > 950) Xseb = -5;
        if (labdaX < 0) Xseb = 5;
        if (labdaY > 550) Yseb = -5;
        if (labdaY < 0) Yseb = 5;

        var jatekosX = Canvas.GetLeft(jatekos);
        var jatekosY = Canvas.GetTop(jatekos);
        if (labdaX+ labda.Width> jatekosX &&
            labdaX< jatekosX +jatekos.Width&&
            labdaY+ labda.Height > jatekosY&&
            labdaY< jatekosY +jatekos.Height)
        {
            Yseb = -5;
            lbpontszam.Content = ++pontstam;
        }

        Canvas.SetLeft(labda, labdaX + Xseb);
        Canvas.SetTop (labda, labdaY + Xseb);
    }
}