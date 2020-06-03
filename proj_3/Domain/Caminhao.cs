using System;
using System.Collections.Generic;

namespace proj_3.Domain
{
    public class Caminhao
    {
        public string Placa { get; set; }
        public Queue<Local> PontosDeEntrega { get; private set; }

        private readonly int Lotacao = 20;

        ///////////////////////////////////////////////////////////
        
        public Caminhao(string placa)
        {
            this.Placa = placa;
            this.PontosDeEntrega = new Queue<Local>();
        }

        ///////////////////////////////////////////////////////////

        public override string ToString()
        {
            string final = "Percurso do caminhão " + this.Placa + ":\n";
            int holderPosicaoLocal = 0;
            foreach (var local in this.PontosDeEntrega)
            {
                final += "\t" + util.posicaoAlfabetica(holderPosicaoLocal++)
                + ". Visitado ponto de entrega "
                + local.Nome
                + ". Foram entregues os itens:\n";

                int holderPosicaoItem = 0;
                foreach (var item in local.ItensEntrega)
                {
                    final += "\t\t"+ util.posicaoAlfabetica(holderPosicaoItem++) + ". " + item.Nome + "\n";
                    //holderPosicaoItem++;
                }
                //holderPosicaoLocal++;
            }
            return final;

        }
    }
}