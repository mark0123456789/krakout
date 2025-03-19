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
    double alapVseb = 5;
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

        if (labdaX > 950 || labdaX < 0) Xseb *= -1;
        if (labdaY > 550) {
            pontstam = 0;
        lbpontszam.Content = 0;
            Canvas.SetTop(labda, 0);
        labdaY = 0;
            Yseb = alapVseb;

        }
        if (labdaY < 0) Yseb *= -1;

        var jatekosX = Canvas.GetLeft(jatekos);
        var jatekosY = Canvas.GetTop(jatekos);
        if (labdaX + labda.Width> jatekosX &&
            labdaX< jatekosX +jatekos.Width &&
            labdaY+ labda.Height > jatekosY&&
            labdaY< jatekosY +jatekos.Height)
        {
            Yseb *= -1.3;
            lbpontszam.Content = ++pontstam;
        }

        Canvas.SetLeft(labda, labdaX + Xseb);
        Canvas.SetTop (labda, labdaY + Yseb);
    }
}