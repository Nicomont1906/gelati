using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace montaspro.nicolo._4i.gelati
{
    public enum TipoIngrediente { nessuno, Panna, Colorante, Aroma, Cacao, Latte, Caffe, Mascarpone, Uovo, Panna_soia}
    public class Ingrediente
    {
        public int idGelato { get; set; }
        public TipoIngrediente Tipo { get; set; }
        public string Val { get; set; }
        
        public Ingrediente()
        {
            Tipo = TipoIngrediente.nessuno;
        }
        public Ingrediente(string riga)
        {
            string[] campi = riga.Split(';');

            int Id = 0;
            int.TryParse(campi[0], out Id);
            idGelato = Id;

            TipoIngrediente c;
            Enum.TryParse(campi[1], out c);
            this.Tipo = c;

            this.Val = campi[2];
        }

        public static Ingrediente MakeIngrediente(string riga)
        {
            string[] campi = riga.Split(';');


            TipoIngrediente c;
            Enum.TryParse(campi[1], out c);

            switch (c)
            {
                case TipoIngrediente.Panna:
                    return new IngredientePanna(riga);
                    break;
                case TipoIngrediente.Colorante:
                    return new IngredienteColorante(riga);
                    break;
                case TipoIngrediente.Latte:
                    return new IngredienteLatte(riga);
                    

            }
            return new Ingrediente(riga);
        }
    }

    public class IngredientePanna : Ingrediente
    {
        public string Calorie { get; set; }
        
        public IngredientePanna() { }

        public IngredientePanna(string riga)
            : base(riga)
        {
            string[] campi = riga.Split(';');
            if (Tipo == TipoIngrediente.Panna && campi.Length > 3)
            {
                Calorie = campi[3];

            }

        }
    }

    public class IngredienteColorante : Ingrediente
    {
        public string colorante;
        public IngredienteColorante() { }

        public IngredienteColorante(string riga)
            : base(riga)
        {
            string[] campi = riga.Split(';');
            if(Tipo == TipoIngrediente.Colorante && campi.Length > 3) 
            {
            colorante = campi[3];
            
            }
        }
        public string Colorante
        {
            get { return colorante; }
        }

    }

    public class IngredienteAroma : Ingrediente
    {
        public IngredienteAroma() { }

        public IngredienteAroma(string riga)
            : base(riga)
        {

        }
    }

    public class IngredienteCacao : Ingrediente
    {
        public IngredienteCacao() { }

        public IngredienteCacao(string riga)
            : base(riga)
        {

        }
    }

    public class IngredienteLatte : Ingrediente
    {
        public string lattosio;

        public IngredienteLatte(string riga)
            : base(riga)
        {
            string[] campi = riga.Split(';');
            if(Tipo == TipoIngrediente.Latte && campi.Length > 3)
            {
                Val = campi[2];
                lattosio = campi[3];

            }
        }
        public string Lattosio
        {
            get { return lattosio;}
        }

    }

    public class IngredienteCaffe : Ingrediente
    {
        public IngredienteCaffe() { }

        public IngredienteCaffe(string riga)
            : base(riga)
        {

        }
    }

    public class IngredienteMascarpone : Ingrediente
    {
        public IngredienteMascarpone() { }

        public IngredienteMascarpone(string riga)
            : base(riga)
        {

        }
    }

    public class IngredienteUovo : Ingrediente
    {
        public IngredienteUovo() { }

        public IngredienteUovo(string riga)
            : base(riga)
        {

        }
    }



    public class Ingredienti : List<Ingrediente>
    {
        public Ingredienti() { }

        public Ingredienti(string nomeFile)
        {

            StreamReader fine = new StreamReader(nomeFile);
            fine.ReadLine();
            while (!fine.EndOfStream) 

                Add(Ingrediente.MakeIngrediente(fine.ReadLine()));

            fine.Close();


        }
    }
}
