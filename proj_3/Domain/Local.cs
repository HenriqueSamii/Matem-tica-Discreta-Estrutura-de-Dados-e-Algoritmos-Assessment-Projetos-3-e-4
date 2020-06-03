using System.Collections.Generic;

namespace proj_3.Domain
{
    public class Local
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }

        public Stack<ItemEntrega> ItensEntrega { get; set; }
        
        ///////////////////////////////////////////////////////////

        public Local(int identificador, string nome)
        {
            this.Identificador = identificador;
            this.Nome = nome;
            this.ItensEntrega = new Stack<ItemEntrega>();
        }
    }
}