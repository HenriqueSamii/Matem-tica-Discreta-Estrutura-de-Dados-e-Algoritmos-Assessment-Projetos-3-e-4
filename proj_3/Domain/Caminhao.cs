using System;
using System.Collections.Generic;

namespace proj_3.Domain
{
    public class Caminhao
    {
        public string Placa { get; set; }
        public Queue<int> IndexPontosDeEntrega { get; private set; }

        public readonly int Lotacao = 20;
        public int ItensNaCacamba { get; private set; }

        ///////////////////////////////////////////////////////////

        public Caminhao(string placa)
        {
            this.Placa = placa;
            this.IndexPontosDeEntrega = new Queue<int>();
            this.ItensNaCacamba = 0;
        }

        ///////////////////////////////////////////////////////////

        public void adecionarLocal(int IndexlocalAdicionado)
        {
            this.IndexPontosDeEntrega.Enqueue(IndexlocalAdicionado);
            //string retorno = "Itens para " + localAdicionado.Nome + " carregados";
        }

        public string entregar(ref List<Local> locais)
        {
            string final = "Percurso do caminhão " + this.Placa + ":\n";
            int holderPosicaoLocal = 0;
            int itensEntregues = 0;
            while (this.IndexPontosDeEntrega.Count != 0 && itensEntregues != this.Lotacao)
            {
                Local local = locais[IndexPontosDeEntrega.Dequeue()];

                if (local.ItensEntrega.Count == 0)
                {
                    final += "";
                }
                else
                {
                    final += "\t" + util.posicaoAlfabetica(holderPosicaoLocal++)
                    + ". Visitado ponto de entrega "
                    + local.Nome
                    + ". Foram entregues os itens:\n";

                    int holderPosicaoItem = 0;
                    while (local.ItensEntrega.Count != 0 && itensEntregues != this.Lotacao)
                    {
                        ItemEntrega item = local.ItensEntrega.Pop();
                        final += "\t\t" + util.posicaoAlfabetica(holderPosicaoItem++) + ". " + item.Nome + "\n";
                        itensEntregues++;
                    }
                }

                //holderPosicaoLocal++;
            }
            return final;

        }

        /*public override string ToString()
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

        }*/

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