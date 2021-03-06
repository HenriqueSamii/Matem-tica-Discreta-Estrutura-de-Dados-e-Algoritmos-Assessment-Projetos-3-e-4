﻿using System;
using System.Collections.Generic;
using System.Linq;
using proj_3.Domain;

namespace proj_3
{
    class Program
    {
        private static int itemMenu = -1;
        private static List<Local> locais;
        private static List<ItemEntrega> itens;
        public static List<Caminhao> caminhoes;
        public static int identificadorItem = 0;
        public static int identificadorLocal = 0;
        static void Main(string[] args)
        {
            locais = new List<Local>();
            itens = new List<ItemEntrega>();
            caminhoes = new List<Caminhao>();

            variaveisTeste();

            while (itemMenu != 0)
            {
                System.Console.WriteLine("[1] Inserir ponto de entrega;\n[2] Inserir item de entrega;\n[3] Inserir caminhão;\n[4] Associar item a ponto de entrega;"
                                         + "\n[5] Associar ponto de entrega a caminhão;\n[6] Realizar entregas;\n[0] Sair.");
                if (!int.TryParse(System.Console.ReadLine(), out itemMenu))
                {
                    itemMenu = -1;
                }
                switch (itemMenu)
                {
                    case 0:
                        break;
                    case 1:
                        System.Console.WriteLine(inserirPontoDeEntrega());
                        break;
                    case 2:
                        System.Console.WriteLine(inserirItemDeEntrega());
                        break;
                    case 3:
                        System.Console.WriteLine(inserirCamiao());
                        break;
                    case 4:
                        System.Console.WriteLine(associarItemAPontoDeEntrega());
                        break;
                    case 5:
                        System.Console.WriteLine(associarPontoDeEntregaACamiao());
                        break;
                    case 6:
                        System.Console.WriteLine(realizarEntregas());
                        break;
                    default:
                        System.Console.WriteLine("Essa opção nao exist, tente novamente");
                        break;
                }

            }
            Console.WriteLine("Programa terminado");
        }
        private static string inserirPontoDeEntrega()
        {
            System.Console.WriteLine("Insira o nome do novo ponto de entrega:");
            string nomeNovo = System.Console.ReadLine();
            foreach (var local in locais)
            {
                if (local.Nome.ToLower() == nomeNovo.ToLower())
                {
                    return "Ponto de entrega " + nomeNovo + " já existe";
                }
            }

            Local novoLocal = new Local(++identificadorLocal, nomeNovo);
            locais.Add(novoLocal);
            return "Ponto de entrega " + nomeNovo + " criado";
        }
        private static string inserirItemDeEntrega()
        {
            System.Console.WriteLine("Insira o nome do novo item de entrega:");
            string nomeNovo = System.Console.ReadLine();
            ItemEntrega novoItem = new ItemEntrega(++identificadorItem, nomeNovo);
            itens.Add(novoItem);
            return "Item de entrega " + nomeNovo + " criado";
        }
        private static string inserirCamiao()
        {
            System.Console.WriteLine("Insira o numero da placa do novo caminhão:");
            string placaNova = System.Console.ReadLine();
            foreach (var local in locais)
            {
                if (local.Nome.ToLower() == placaNova.ToLower())
                {
                    return "Placa " + placaNova + " já existe";
                }
            }
            Caminhao novoCaminhao = new Caminhao(placaNova);
            caminhoes.Add(novoCaminhao);
            return "Camião de placa " + placaNova + " criado";
        }
        private static string associarItemAPontoDeEntrega()
        {
            string retornoErro = "";
            if (itens.Count == 0)
            {
                retornoErro += "Nao existe itens para serem adecionados. ";
            }
            if (locais.Count == 0)
            {
                retornoErro += "Nao existe locais para adecionar itens. ";
            }
            if (retornoErro != "")
            {
                return retornoErro;
            }

            int itemNum = -1;
            int localNum = -1;

            System.Console.WriteLine("Selecione o numero do item:");
            for (int i = 0; i < itens.Count; i++)
            {
                System.Console.WriteLine(i + ". " + itens[i].Nome);
            }
            string inputItemString = System.Console.ReadLine();
            if (!int.TryParse(inputItemString, out itemNum) || itemNum > itens.Count - 1)
            {
                return "Erro, opção não permetida. Tente novamente";
            }

            System.Console.WriteLine("Selecione o numero do local onde adicionar o item:");
            for (int i = 0; i < locais.Count; i++)
            {
                System.Console.WriteLine(i + ". " + locais[i].Nome);
            }
            string inputLocalString = System.Console.ReadLine();
            if (!int.TryParse(inputLocalString, out localNum) || localNum > locais.Count - 1)
            {
                return "Erro, opção não permetida. Tente novamente";
            }

            locais[localNum].ItensEntrega.Push(new ItemEntrega(itens[itemNum].Identificador, itens[itemNum].Nome));

            itens.RemoveAt(itemNum);

            return ("Item " + locais[localNum].ItensEntrega.Peek().Nome + " adecionado em" + locais[localNum].Nome);
        }
        private static string associarPontoDeEntregaACamiao()
        {
            int localNum = -1;
            int caminhaoNum = -1;

            System.Console.WriteLine("Selecione o ponto de entrega:");
            for (int i = 0; i < locais.Count; i++)
            {
                System.Console.WriteLine(i + ". " + locais[i].Nome);
            }
            string inputLocalString = System.Console.ReadLine();
            if (!int.TryParse(inputLocalString, out localNum) || localNum > locais.Count - 1)
            {
                return "Erro, opção não permetida. Tente novamente";
            }
            System.Console.WriteLine("Selecione o caminhão ponto de entrega:");
            for (int i = 0; i < caminhoes.Count; i++)
            {
                System.Console.WriteLine(i + ". " + caminhoes.ElementAt(i).Placa);
            }
            string inputCaminhaoString = System.Console.ReadLine();
            if (!int.TryParse(inputCaminhaoString, out caminhaoNum) || caminhaoNum > caminhoes.Count - 1)
            {
                return "Erro, opção não permetida. Tente novamente";
            }

            caminhoes[caminhaoNum].adecionarLocal(localNum);

            return "Ponto de entrega " + locais[localNum].Nome + " andecionado no camhão" + caminhoes[caminhaoNum].Placa;
        }
        private static string realizarEntregas()
        {
            if (caminhoes.Count == 0)
            {
                return "Sem entregas marcadas";
            }
            string returnString = "";
            foreach (var caminhao in caminhoes)
            {
                returnString += caminhao.entregar(ref locais) + "\n\n";
            }
            return returnString;
        }

        private static void variaveisTeste()
        {
            //teste - variaveis
            for (int i = 0; i < 6; i++)
            {
                locais.Add(new Local(++identificadorLocal, ("Lugar " + i)));
            }

            for (int i = 0; i < 60; i++)
            {
                itens.Add(new ItemEntrega(++identificadorItem, ("item " + i)));
                int numLocal = -1;
                if (i < 18)
                {
                    numLocal = 0;
                }
                else if (i < 30)
                {
                    numLocal = 1;
                }
                else if (i < 50)
                {
                    numLocal = 2;
                }
                else if (i < 55)
                {
                    numLocal = 3;
                }
                else if (i < 51)
                {
                    numLocal = 4;
                }
                if (numLocal > -1)
                {
                    locais[numLocal].ItensEntrega.Push(itens[itens.Count-1]);
                    itens.RemoveAt(itens.Count-1);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                caminhoes.Add(new Caminhao("Caminhão " + i));
            }
            caminhoes[0].adecionarLocal(0);
            caminhoes[0].adecionarLocal(1);
            caminhoes[1].adecionarLocal(1);
            caminhoes[1].adecionarLocal(2);
            caminhoes[2].adecionarLocal(3);
            //////////
        }
    }
}
