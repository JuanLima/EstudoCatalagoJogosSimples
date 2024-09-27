using ApiCatalogoJogos2.InputModel;
using ApiCatalogoJogos2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoJogos2.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);

        Task<JogoViewModel> InserirJogo(JogoInputModel jogo);

        Task AtualizarJogo(Guid idJogo, JogoInputModel jogo);

        Task AtualizarJogo(Guid idJogo, double preco);

        Task Remover(Guid idJogo);

    }
}
