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

namespace Vokabeltrainer
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public int max_vok = 20;
        public int vok_negativ = 6;
        public Settings()
        {
            InitializeComponent();
        }

        private void vok_max_TextChanged(object sender, TextChangedEventArgs e)
        {
            vok_max.Background = Brushes.White;

            try
            {
                max_vok = Convert.ToInt16(vok_max.Text);
            }
            catch
            {
                vok_max.Background = Brushes.Coral;
            }
        }

        private void vok_fehler_TextChanged(object sender, TextChangedEventArgs e)
        {
            vok_fehler.Background = Brushes.White;

            try
            {
                vok_negativ = Convert.ToInt16(vok_fehler.Text);
            }
            catch
            {
                vok_fehler.Background = Brushes.Coral;

            }
        }
    }
}
