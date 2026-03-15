using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Vokabeltrainer
{
    public class Vok_trainer
    {
        Canvas canvas;
        Deck deck;
        public Vok_entry currentEntry;
        TextBox textBox;
        ComboBox to;
        Label geg;
        ComboBox from;
        int falsch = 0;
        int done = 0;
        Label lösug;
        Rectangle rect;

        public Vok_trainer(Canvas canvas, Deck deck, TextBox answer, ComboBox to, Label geg, ComboBox from, Label lösung, Rectangle rect)
        {
            this.canvas = canvas;
            this.deck = deck;
            this.textBox = answer;
            this.to = to;
            this.geg = geg;
            this.from = from;
            this.lösug = lösung;
            this.rect = rect;
        }

        public async Task NextWord()
        {
            await Task.Delay(50);
            currentEntry = deck.GetRandom();
            if(from.Text == "EN")
                geg.Content = currentEntry.en;
            else if (from.Text == "DE")
                geg.Content = currentEntry.de;
            else
                geg.Content = currentEntry.fr;
        }
        
        public void ShowAnswer()
        {
            if(to.Text == "EN")
                lösug.Content = currentEntry.en;
            if (to.Text == "DE")
                lösug.Content = currentEntry.de;
            if (to.Text == "FR")
                lösug.Content = currentEntry.fr;
        }
        public void CheckAnswer(int fehler, int max) 
        {
            textBox.Background = Brushes.White;
            if ((textBox.Text == currentEntry.en) && (to.Text == "EN"))
            {
                NextWord();
                textBox.Clear();
                done++;
            }
            else if ((textBox.Text == currentEntry.de) && (to.Text == "DE"))
            {
                NextWord();
                textBox.Clear();
                done++;
            }
            else if ((textBox.Text == currentEntry.fr) && (to.Text == "FR"))
            {
                NextWord();
                textBox.Clear();
                done++;
            }
            else
            {   
                falsch += 1;
                textBox.Background = Brushes.Coral;
            }

            if ((double)falsch / done < (double)fehler / max)
            {
                rect.Fill = Brushes.Green;
            }
            else
            {
                rect.Fill = Brushes.Red;
            }
            rect.Height = (330 / max) * done;
        }
    }
}
