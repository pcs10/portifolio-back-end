using GeradorDeApostas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class MegaSenaController : ControllerBase
    {

        [HttpGet]
        [Route(template: "seis-numeros")]
        public async Task<IActionResult> SeisNumeros()
        {
            var numeros = new MegaSena();
            numeros.Id = 1;

            Random randNum = new Random();
            int numerosSorteado;
            int[] verificador = new int[6]; // um vetor instanciado recebe o numero zero em todas as posições


            for (int i = 0; i < 6; i++)
            {

            Inicio:
                numerosSorteado = randNum.Next(1, 6+1); //precisa colocar o mais um pois tem um bug que se nao tiver nao pega o ultimo numero

                for (int j = 0; j < 6; j++)
                {
                    if (verificador[j] == numerosSorteado)
                    {
                        goto Inicio; //refaz os passos acima caso tenha algum numero repetido
                    }
                }

                numeros.Numeros.Add(numerosSorteado);
                verificador[i] = numerosSorteado;

            }

            return Ok(numeros);

        }
    }
}
