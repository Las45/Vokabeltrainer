using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vokabeltrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Deck deck;
        public Vok_trainer trainer;
        TextBox answers;
        int max = 20;
        int fehler = 6;
        public MainWindow()
        {
            InitializeComponent();  
            deck = new Deck();
            deck.Load("vok.json");

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            answers = answer_textbox;
            trainer = new Vok_trainer(vok_canvas, deck, answers, input_lan, voc_label, output_lan, Lösung_lab, feedback_bar);
            trainer.NextWord();
        }
        private void next_voc_button_Click(object sender, RoutedEventArgs e)
        {
            trainer.NextWord();
        }

        private void voc_verwalten_button_Click(object sender, RoutedEventArgs e)
        {
            Vok_bearb window = new Vok_bearb(deck);
            window.ShowDialog();
            
        }

        private void pruefen_button_Click(object sender, RoutedEventArgs e)
        {
            trainer.CheckAnswer(fehler, max);
            Lösung_lab.Content = "";
        }

        private void output_lan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trainer != null)
            {
                trainer.NextWord();
            }
        }

        private void answer_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                trainer.CheckAnswer(fehler, max);
                Lösung_lab.Content = "";

            }
        }

        private void Lösen_Click(object sender, RoutedEventArgs e)
        {
            trainer.ShowAnswer();
        }

        private void Settngs_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            max = settings.max_vok;
            fehler = settings.vok_negativ;
        }
    }
}