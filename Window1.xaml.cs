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
using System.Windows.Shapes;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int currentIndex = 0;
        public Window1()
        {
            InitializeComponent();
        }
        private void ScrollLeft(object sender, RoutedEventArgs e)
        {
            currentIndex = Math.Max(0, currentIndex - 1);
            ScrollDays();
        }

        private void ScrollRight(object sender, RoutedEventArgs e)
        {
            currentIndex = Math.Min(DaysContainer.Children.Count - 1, currentIndex + 1);
            ScrollDays();
        }

        private void ScrollDays()
        {
            double translateValue = -currentIndex * 100; // Assuming each day has a fixed width of 100
            DaysContainer.RenderTransform = new TranslateTransform { X = translateValue };
        }
    }
}
