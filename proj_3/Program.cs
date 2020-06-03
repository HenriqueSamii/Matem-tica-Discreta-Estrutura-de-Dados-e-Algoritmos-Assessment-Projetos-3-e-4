using System;
using System.Collections.Generic;
using proj_3.Domain;

namespace proj_3
{
    class Program
    {
        private static int itemMenu = -1;
        private static List<Local> locais;
        private static List<ItemEntrega> itens;
        public static Queue<Caminhao> pontosDeEntrega;
        static void Main(string[] args)
        {
            locais = new List<Local>();
            itens = new List<ItemEntrega>();
            pontosDeEntrega = new Queue<Caminhao>();

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
                        inserirPontoDeEntrega();
                        break;
                    case 2:
                        inserirItemDeEntrega();
                        break;
                    case 3:
                        inserirCamiao();
                        break;
                    case 4:
                        associarItemAPontoDeEntrega();
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
        private static void inserirPontoDeEntrega(){
            System.Console.WriteLine("teste");
        }
        private static void inserirItemDeEntrega(){
            System.Console.WriteLine("teste");
        }
        private static void inserirCamiao(){
            System.Console.WriteLine("teste");
        }
        private static void associarItemAPontoDeEntrega(){
            System.Console.WriteLine("teste");
        }
        private static void associarPontoDeEntregaACamiao(){
            System.Console.WriteLine("teste");
        }
        private static void realizarEntregas(){
            System.Console.WriteLine("teste");
        }
    }
}
