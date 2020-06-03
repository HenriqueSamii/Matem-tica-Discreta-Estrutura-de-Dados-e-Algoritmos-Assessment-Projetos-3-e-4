using System;

namespace proj_3
{
    public static class util
    {
        public static string posicaoAlfabetica(int numero)
        {
            string posicaoLetra = "";
            //26 letras - de 0 à 25 -- posicaoAscii == i = 65; i <= 90
            int casa = (int)Math.Floor((decimal)(numero)/25);
            if (casa > 0)
            {
                posicaoLetra += ((char)(65 + casa-1)).ToString().ToLower();
                numero -= (25*casa);
            }
            posicaoLetra += ((char)(65 + numero)).ToString().ToLower();
            return posicaoLetra;
        }
    }
}