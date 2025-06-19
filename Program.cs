using System;

namespace Pix
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.Clear();
            var chave = "18241594412";
            var valorTransacao = 1.10m;
            var idTransacao = "";                        

            var codigoPix = PixGenerator.GeraPix(chave, idTransacao, valorTransacao);
            var code_link = $"https://quickchart.io/qr?text={codigoPix}";
            Console.WriteLine("Código PIX: " + codigoPix);
            Console.WriteLine("Link QrCode: " + code_link);

        }
    }
}