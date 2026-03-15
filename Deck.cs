using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Vokabeltrainer
{
    public class Deck
    {

        public List<Vok_entry> vocabulary { get; set; } = new List<Vok_entry>();
        Random random = new Random();
        public Deck()
        {
            
        }
        public void Add(string de, string en, string sp)
        {
            vocabulary.Add(new Vok_entry(vocabulary.Count, de, en, sp));
        }
        public void Remove(int id)
        {
            vocabulary.Remove(vocabulary[id]);
        }
        public void Load(string path)
        {
            string json;
            vocabulary.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    json = sr.ReadToEnd();

                }

                Deck d = (JsonSerializer.Deserialize<Deck>(json));
                vocabulary = d.vocabulary;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Save(string path)
        {
            string json;
            json = JsonSerializer.Serialize(vocabulary);
            using(StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.Write($"{{\r\n \"vocabulary\": {json}}}");
            }
        }
        public Vok_entry GetRandom()
        {
            int id_ran;
            id_ran = random.Next(1, vocabulary.Count);
            return vocabulary[id_ran];
        }
    }
}
