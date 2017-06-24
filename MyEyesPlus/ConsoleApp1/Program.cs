using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEyes_API;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var teste = new MyEyes_API.ProcessamentoImagem();
            Console.WriteLine(teste.BuscarCarta("Congregate"));
            Console.ReadKey();
        }
    }
}
