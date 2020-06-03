namespace proj_3.Domain
{
    public class ItemEntrega
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }

        ///////////////////////////////////////////////////////////

        public ItemEntrega(int identificador, string nome)
        {
            this.Identificador = identificador;
            this.Nome = nome;
        }
    }
}