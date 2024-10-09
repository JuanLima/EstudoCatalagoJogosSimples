using ApiCatalogoJogos2.Exceptions;
using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos2.Controllers.V1
{
    public partial class JogosController
    {
        [HttpPatch("{idJogo: guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPrecoJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.AtualizarJogo(idJogo, preco);
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
