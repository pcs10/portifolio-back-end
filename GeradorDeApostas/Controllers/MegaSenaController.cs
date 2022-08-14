using GeradorDeApostas.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class MegaSenaController : ControllerBase
    {

        [HttpGet]
        [Route(template: "mega-sena/{quantidade}")] //quantidade de numeros em uma aposta (6 a 15)
        //public async Task<IActionResult> SeisNumeros([FromRoute] int quantidade)
        public IActionResult SeisNumeros([FromRoute] int quantidade)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (quantidade < 6 || quantidade > 15)
            {
                return BadRequest("A quantidade precisa ser entre 6 e 15");
            }

            var numeros = new MegaSena();
            numeros.Id = 1;

            Random randNum = new Random();
            int numerosSorteado;
            int[] verificador = new int[quantidade]; // um vetor instanciado recebe o numero zero em todas as posições


            for (int i = 0; i < quantidade; i++)
            {

            Inicio:
                numerosSorteado = randNum.Next(1, quantidade + 1); //precisa colocar o mais um pois tem um bug que se nao tiver nao pega o ultimo numero

                for (int j = 0; j < quantidade; j++)
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
