using ApiCatalogoJogos2.Entities;
using ApiCatalogoJogos2.Exceptions;
using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.Repositories;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoJogos2.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task AtualizarJogo(Guid idJogo, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(idJogo);

            if (entidadeJogo == null)
                throw new JogoJaCadastradoException();

            entidadeJogo.Nome= jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.AtualizarJogo(entidadeJogo);
        }

        public async Task AtualizarJogo(Guid idJogo, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter(idJogo);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.AtualizarJogo(entidadeJogo);
        }

        public async Task<JogoViewModel> InserirJogo(JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco,
            };

            await _jogoRepository.Inserir(jogoInsert);


            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogoInsert.Nome,
                Produtora = jogoInsert.Produtora,
                Preco = jogoInsert.Preco,
            };
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco,
            }).ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco,
            };

        }

        public async Task Remover(Guid idJogo)
        {
            var jogo = _jogoRepository.Remover(idJogo);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            await _jogoRepository.Remover(idJogo);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }

    }
}
