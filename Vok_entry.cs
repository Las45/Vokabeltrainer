using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    public class Vok_entry
    {
        public int id {  get; set; }
        public string de {  get; set; }
        public string en { get; set; }
        public string fr { get; set; }

        public Vok_entry()
        {

        }

        public Vok_entry(int id, string de, string en, string fr)
        {
            this.id = id;
            this.de = de;
            this.en = en;
            this.fr = fr;
        }
    }
}
