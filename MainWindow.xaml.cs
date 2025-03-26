using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

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
        for (int j = 0; j < 5; j++)
        {


            for (int i = 0; i < 10; i++)
            {


                var tegla = new Image();

                tegla.Source = new BitmapImage(new Uri("tegla.jpg", UriKind.Relative));

                tegla.Width = 90;
                tegla.Height = 20;
                tegla.Stretch = Stretch.Fill;
                Canvas.SetLeft(tegla, i * 100);
                Canvas.SetTop(tegla, j * 30);
                jatekter.Children.Add(tegla);
            }
        }
        labda.CacheMode = new BitmapCache();
       
        CompositionTarget.Rendering += Mozgatas;
        
        Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 60 });

        //var ido = new DispatcherTimer();
        // ido.Interval = TimeSpan.FromMilliseconds(1);
        // ido.Tick += Mozgatas;
        // ido.Start();
    }

    private void Mozgatas(object? sender, EventArgs e)
    {
        Canvas.SetLeft(jatekos, Mouse.GetPosition(jatekter).X);

        var labdaY = Canvas.GetTop(labda);
        var labdaX = Canvas.GetLeft(labda);

        if (labdaX > 980 || labdaX < 0) Xseb *= -1;
        if (labdaY > 580) {
            lbpontszam.Content = --pontstam;
            lbpontszam.Content = 0;
            labdaY = Canvas.GetTop(jatekos) - labda.Height;
            labdaX = Canvas.GetLeft(jatekos) - jatekos.Width / 2;
            Canvas.SetTop(labda,labdaX);
            Canvas.SetLeft(labda,labdaY);
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
            Yseb *= -1;
         
        }

        foreach (var tegla in jatekter.Children.OfType<Image>())
        {
            var teglaX = Canvas.GetLeft(tegla);
            var teglaY = Canvas.GetTop(tegla);
            if (labdaX + labda.Width > teglaX &&
                labdaX < teglaX + jatekos.Width &&
                labdaY + labda.Height > teglaY &&
                labdaY < teglaY + jatekos.Height)
            {
                Yseb *= -1;
                jatekter.Children.Remove(tegla);
                lbpontszam.Content = ++pontstam;
                break;
            }
        }

        Canvas.SetLeft(labda, labdaX + Xseb);
        Canvas.SetTop (labda, labdaY + Yseb);
    }
}