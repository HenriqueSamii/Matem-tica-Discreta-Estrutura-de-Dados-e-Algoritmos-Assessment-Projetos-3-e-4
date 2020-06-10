using System;
using System.Collections.Generic;

namespace proj_4
{
    class Program
    {
        private static List<Pacote> V;
        private static Random rnd;
        private static int d;
        static void Main(string[] args)
        {
            V = new List<Pacote>();
            rnd = new Random();
            d = 1;

            string itensExistentes = "";

            for (int i = 0; i < 40; i++)
            {
                int codigoB  = rnd.Next(1, 6);
                if (i != 0)
                {
                    itensExistentes += ", ";
                }
                itensExistentes += codigoB;
                V.Add(new Pacote(codigoB));
            }

            System.Console.WriteLine(itensExistentes);
            Console.WriteLine("Iterativa:\n" + d + " aparece " + numeroDeVezesDeD() + " vezes no etor V ");
            Console.WriteLine("Recusrivo:\n" + d + " aparece " + numeroDeVezesDeDRecursivo(V.Count - 1) + " vezes no etor V ");
        }

        private static int numeroDeVezesDeD (){
            int vezesDeD = 0;
            for (int i = 0; i < V.Count-1; i++)
            {
                vezesDeD += isEqualVectorItem(i);
            }
            return vezesDeD;
        }

        private static int numeroDeVezesDeDRecursivo (int index){
            if (index == 0)
            {
                return isEqualVectorItem(index);
            }
            return (isEqualVectorItem(index) + numeroDeVezesDeDRecursivo(index-1));
        }

        private static int isEqualVectorItem(int index){
            if (d == V[index].CodigoDeBarra)
                {
                    return 1;
                }
            return 0;
        }

    }

    /*
    Considere um vetor V que contém como dados as assinaturas dos tipos de 
    pacotes transportados por uma rede móvel em uma determinada região. Para analisar esses dados e colher estatísticas dos pacotes trafegados:

    Escreva uma função recursiva que determine quantas vezes um dado D (parâmetro de entrada) ocorre em V.
    Escreva a mesma função, de maneira iterativa, sem uso de recursividade.

    */
}
