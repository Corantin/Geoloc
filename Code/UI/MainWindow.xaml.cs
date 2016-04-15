using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double MAX_X = 1000;
        const double MAX_Y = 800;

        public MainWindow()
        {
            InitializeComponent();

            SizeChanged += MainWindow_SizeChanged;

            DrawPosition("Camion de pompier", 1, 0, 0);
            DrawPosition("Camion de pompier", 1, 50, 50);
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var children in cnvLocalisation.Children)
            {
                if(children is Image)
                {
                    UpdatePosition((Image)children);
                }
            }
        }

        public void DrawPosition(string type, int id, double x, double y)
        {
            Image pointer = new Image();
            pointer.Source = new BitmapImage(new Uri("pack://application:,,,/Images/positionIcon.png"));
            pointer.Width = 25;
            pointer.Height = 25;
            Dictionary<string,double> dicCoordo = new Dictionary<string, double>();
            dicCoordo.Add("x", x);
            dicCoordo.Add("y", y);
            pointer.Tag = dicCoordo;
            Canvas.SetLeft(pointer, x * ActualWidth / MAX_X);
            Canvas.SetTop(pointer, y * ActualHeight / MAX_Y);
            pointer.ToolTip = type;
            cnvLocalisation.Children.Add(pointer);
        }

        private void UpdatePosition(Image pointer)
        {
            Dictionary<string, double> dicCoordo = pointer.Tag as Dictionary<string, double>;
            Canvas.SetLeft(pointer, dicCoordo["x"] * ActualWidth / MAX_X);
            Canvas.SetTop(pointer, dicCoordo["y"] * ActualHeight / MAX_Y);
        }
    }
}
