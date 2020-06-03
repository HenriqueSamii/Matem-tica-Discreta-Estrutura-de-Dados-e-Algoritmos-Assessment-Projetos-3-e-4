using System.Collections.Generic;

namespace proj_3.Domain
{
    public class Local
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }

        public Stack<ItemEntrega> ItensEntrega { get; set; }
    }
}