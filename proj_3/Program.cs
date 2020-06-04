﻿using System;
using System.Collections.Generic;
using proj_3.Domain;

namespace proj_3
{
    class Program
    {
        private static int itemMenu = -1;
        private static List<Local> locais;
        private static List<ItemEntrega> itens;
        public static Queue<Caminhao> caminhoes;
        static void Main(string[] args)
        {
            locais = new List<Local>();
            itens = new List<ItemEntrega>();
            caminhoes = new Queue<Caminhao>();

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
                        associarPontoDeEntregaACamiao();
                        break;
                    case 6:
                        realizarEntregas();
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
            int identificador = 0;
            foreach (var local in locais)
            {
                if (local.Nome.ToLower() == nomeNovo.ToLower())
                {
                    return "Ponto de entrega " + nomeNovo + " já existe";
                }
                if (local.Identificador > identificador)
                {
                    identificador = local.Identificador + 1;
                }
            }
            Local novoLocal = new Local(identificador, nomeNovo);
            locais.Add(novoLocal);
            return "Ponto de entrega " + nomeNovo + " criado";
        }
        private static string inserirItemDeEntrega()
        {
            System.Console.WriteLine("Insira o nome do novo item de entrega:");
            string nomeNovo = System.Console.ReadLine();
            int identificador = 0;
            foreach (var local in locais)
            {
                if (local.Identificador > identificador)
                {
                    identificador = local.Identificador + 1;
                }
            }
            ItemEntrega novoItem = new ItemEntrega(identificador, nomeNovo);
            itens.Add(novoItem);
            return "Item de entrega " + nomeNovo + " criado";
        }
        private static string inserirCamiao()
        {
            string placaNova = System.Console.ReadLine();
            foreach (var local in locais)
            {
                if (local.Nome.ToLower() == placaNova.ToLower())
                {
                    return "Placa " + placaNova + " já existe";
                }
            }
            Caminhao novoCaminhao = new Caminhao(placaNova);
            caminhoes.Enqueue(novoCaminhao);
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
            if (!int.TryParse(inputItemString, out itemNum) || itemNum > itens.Count-1 )
            {
                return "Erro, opção não permetida. Tente novamente";
            }

            System.Console.WriteLine("Selecione o numero do local onde adicionar o item:");
            for (int i = 0; i < locais.Count; i++)
            {
                System.Console.WriteLine(i + ". " + locais[i].Nome);
            }
            string inputLocalString = System.Console.ReadLine();
            if (!int.TryParse(inputLocalString, out localNum) || localNum > locais.Count-1 )
            {
                return "Erro, opção não permetida. Tente novamente";
            }
            
            locais[localNum].ItensEntrega.Push(new ItemEntrega(itens[itemNum].Identificador,itens[itemNum].Nome));

            itens.RemoveAt(itemNum);

            return("Item " +  locais[localNum].ItensEntrega.Peek().Nome + " adecionado em" + locais[localNum].Nome);
        }
        private static void associarPontoDeEntregaACamiao()
        {
            System.Console.WriteLine("teste");
        }
        private static void realizarEntregas()
        {
            while (caminhoes.Count > 0)
            {
                System.Console.WriteLine(caminhoes.Dequeue().ToString());
            }
        }
    }
}
