using MyEyes_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEyes_API.Tests
{
    public class ProcessamentoImagemTests
    {        

        public void buscarCartaTest(string NomeCarta)
        {
            ProcessamentoImagem Proc = new ProcessamentoImagem();
            Proc.buscarCarta(NomeCarta);
        }
    }
}