using System;
using System.Collections.Generic;

namespace proj_3.Domain
{
    public class Caminhao
    {
        public string Placa { get; set; }
        public Queue<Local> PontosDeEntrega { get; private set; }

        public readonly int Lotacao = 20;
        public int ItensNaCacamba { get; private set; }

        ///////////////////////////////////////////////////////////

        public Caminhao(string placa)
        {
            this.Placa = placa;
            this.PontosDeEntrega = new Queue<Local>();
            this.ItensNaCacamba = 0;
        }

        ///////////////////////////////////////////////////////////

        public string adecionarLocal(Local localAdicionado)
        {
            this.PontosDeEntrega.Enqueue(localAdicionado);
            string retorno = "Itens para " + localAdicionado.Nome + " carregados";
            if (this.ItensNaCacamba == this.Lotacao)
            {
                retorno += ", capasidade do caminhão lodado";
            }
            return retorno;
        }

        public string entregar()
        {
            string final = "Percurso do caminhão " + this.Placa + ":\n";
            int holderPosicaoLocal = 0;
            while (this.PontosDeEntrega.Count != 0)
            {
                Local local = PontosDeEntrega.Dequeue();
                final += "\t" + util.posicaoAlfabetica(holderPosicaoLocal++)
                + ". Visitado ponto de entrega "
                + local.Nome
                + ". Foram entregues os itens:\n";

                int holderPosicaoItem = 0;
                while (local.ItensEntrega.Count != 0)
                {
                    ItemEntrega item = local.ItensEntrega.Pop();
                    final += "\t\t" + util.posicaoAlfabetica(holderPosicaoItem++) + ". " + item.Nome + "\n";
                    //holderPosicaoItem++;
                }
                //holderPosicaoLocal++;
            }
            return final;

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

        /*public string adecionarLocal(ref List<Local> localAdicionado, int ponto)
        {
            if (this.ItensNaCacamba == this.Lotacao)
            {
                return "Camião lotado";
            }
            var localHolder = new Local(localAdicionado[ponto].Identificador, localAdicionado[ponto].Nome);
            while (this.ItensNaCacamba != this.Lotacao && localAdicionado[ponto].ItensEntrega.Count > 0)
            {
                localHolder.ItensEntrega.Push(localAdicionado[ponto].ItensEntrega.Pop());
            }
            this.PontosDeEntrega.Enqueue(localHolder);
            string retorno = "Itens para " + localAdicionado[ponto].Nome + " carregados";
            if (this.ItensNaCacamba == this.Lotacao)
            {
                retorno += ", capasidade do caminhão lodado";
            }
            return retorno;
        }*/
    }
}