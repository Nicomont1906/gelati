using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace montaspro.nicolo._4i.gelati
{
    public class Gelato
    {
        public int idGelato { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Prezzo { get; set; }

        

        public Gelato() { }

        public Gelato(string riga)
        {
            string[] campi = riga.Split(';');

            if (campi.Count() != 4)
            {
                throw new Exception("Le righe del file contatti.csv, devono essere di tre colonne");
            }

            int Id = 0;
            int.TryParse(campi[0], out Id);
            idGelato = Id;

            this.Nome = campi[1];
            this.Descrizione = campi[2];
            this.Prezzo = campi[3];
           
        }
    }

    public class Gelati : List<Gelato>
    {
        public Gelati() { }

        public Gelati(string NomeFile)
        {
            StreamReader fin = new StreamReader(NomeFile);
            fin.ReadLine();
            while (!fin.EndOfStream)

                Add(new Gelato(fin.ReadLine()));

            fin.Close();
        }
    }
}
