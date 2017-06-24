using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MtgApiManager.Lib.Dto;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;



using System.Collections.Specialized;
using System.Threading.Tasks;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Core.Exceptions;
//using MtgApiManager.Moq;


namespace MyEyes_API
{
    public class ProcessamentoImagem
    {
        public string BuscarCarta(string NomeCarta)
        {
            CardService service = new CardService();
            //var xpto = service.Where(x => x.Name, "Fog").All();
            service = service.Where(x => x.Name, NomeCarta);

            var result = service.All();
            
            if (result.IsSuccess && result.Value.Count > 0 )
            {

                return "Sua Carta é " + result.Value[0].Name + " ela é uma carta do tipo " + result.Value[0].SubTypes + " Seu custo de mana é " + result.Value[0].ManaCost + " seus efeitos são " + result.Value[0].Text;
            }
            else
            {
                return "Carta não identificada";
            }







            //var dto = new CardDto()
            // {
            //     Name = NomeCarta
            // };
            // Card Model = new Card(dto);

            
        }
    }

}
