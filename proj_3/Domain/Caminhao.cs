using System;
using System.Collections.Generic;

namespace proj_3.Domain
{
    public class Caminhao
    {
        public string Placa { get; set; }
        public Queue<Local> PontosDeEntrega { get; private set; }

        private readonly int Lotacao = 20;
        private int ItensNaCacamba;

        ///////////////////////////////////////////////////////////

        public Caminhao(string placa)
        {
            this.Placa = placa;
            this.PontosDeEntrega = new Queue<Local>();
            this.ItensNaCacamba = 0;
        }

        ///////////////////////////////////////////////////////////

        public string adecionarLocal(ref Local localAdicionado)
        {
            if (this.ItensNaCacamba == this.Lotacao)
            {
                return "Camião lotado";
            }
            var localHolder = new Local(localAdicionado.Identificador, localAdicionado.Nome);
            while (this.ItensNaCacamba != this.Lotacao && localAdicionado.ItensEntrega.Count > 0)
            {
                localHolder.ItensEntrega.Push(localAdicionado.ItensEntrega.Pop());
            }
            this.PontosDeEntrega.Enqueue(localHolder);
            string retorno = "Itens para " + localAdicionado.Nome + " carregados";
            if (this.ItensNaCacamba == this.Lotacao)
            {
                retorno += ", capasidade do caminhão lodado";
            }
            return retorno;
        }

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
                    final += "\t\t" + util.posicaoAlfabetica(holderPosicaoItem++) + ". " + item.Nome + "\n";
                    //holderPosicaoItem++;
                }
                //holderPosicaoLocal++;
            }
            return final;

        }
    }
}