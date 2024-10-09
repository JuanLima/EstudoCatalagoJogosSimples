﻿using ApiCatalogoJogos2.Exceptions;
using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos2.Controllers.V1
{
    public partial class JogosController
    {
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInput)
        {
            try
            {
                var jogo = await _jogoService.InserirJogo(jogoInput);

            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }

            return Ok();
        }
    }
}
