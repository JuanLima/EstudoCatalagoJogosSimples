using ApiCatalogoJogos2.Entities;
using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoJogos2.Repositories
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int quantidade);

        Task<Jogo> Obter(Guid id);
        Task<List<Jogo>> Obter(string nome, string produtora);

        Task Inserir(Jogo jogo);

        Task AtualizarJogo(Jogo jogo);

        Task Remover(Guid idJogo);
    }
}
