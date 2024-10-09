using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos2.Controllers.V1
{
    public partial class JogosController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> ObterTodos([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var result = await _jogoService.Obter(pagina, quantidade);
            return Ok(result);
        }
    }
}
