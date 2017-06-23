using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MtgApiManager.Lib.Dto;
using MtgApiManager.Lib.Model;

namespace MyEyes_API
{
    public class ProcessamentoImagem
    {
        public string BuscarCarta(string NomeCarta)
        {
            var dto = new CardDto()
            {
                Name = NomeCarta
            };
            Card Model = new Card(dto);

            return "Sua Carta é " + Model.Name + " ela é uma carta do tipo " + Model.SubTypes + " Seu custo de mana é " + Model.ManaCost + " seus efeitos são " + Model.Text;
        }
    }

}
