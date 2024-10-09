using ApiCatalogoJogos2.Exceptions;
using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos2.Controllers.V1
{
    public partial class JogosController
    {
        [HttpPut("{idJogo: guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInput)
        {
            try
            {
                await _jogoService.AtualizarJogo(idJogo, jogoInput);
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
