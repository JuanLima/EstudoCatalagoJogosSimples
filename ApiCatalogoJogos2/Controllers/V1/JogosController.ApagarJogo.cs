using ApiCatalogoJogos2.Exceptions;
using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos2.Controllers.V1
{
    public partial class JogosController
    {
        [HttpDelete("{idJogo: guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();

            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
