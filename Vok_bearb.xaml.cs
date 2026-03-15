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
    /// Interaktionslogik für Vok_bearb.xaml
    /// </summary>
    public partial class Vok_bearb : Window
    {
        Deck deck;
        public Vok_bearb(Deck deck)
        {
            InitializeComponent();
            this.deck = deck;
            Datagrid_Vokabeln.ItemsSource = deck.vocabulary;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            deck.vocabulary.Add(new Vok_entry(deck.vocabulary.Count+1, "N/A", "N/A", "N/A"));
            Datagrid_Vokabeln.Items.Refresh();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            deck.vocabulary.RemoveAt(Datagrid_Vokabeln.SelectedIndex);
            Datagrid_Vokabeln.Items.Refresh();

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            deck.Save("vok.json");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Datagrid_Vokabeln.Columns.RemoveAt(0);

        }
    }
}
