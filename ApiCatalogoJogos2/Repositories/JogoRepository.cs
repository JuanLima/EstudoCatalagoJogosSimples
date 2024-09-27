using ApiCatalogoJogos2.Entities;
using ApiCatalogoJogos2.Services;

namespace ApiCatalogoJogos2.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("153e9ee7-ca56-4a49-8daf-1e6bce1a793d"), new Jogo{ Id = Guid.Parse("153e9ee7-ca56-4a49-8daf-1e6bce1a793d"), Nome = "teste1", Produtora = "Produtora1" , Preco = 1 } },
            {Guid.Parse("424fb8b6-ef51-4c0d-8ad0-0d36d600e02b"), new Jogo{ Id = Guid.Parse("424fb8b6-ef51-4c0d-8ad0-0d36d600e02b"), Nome = "teste2", Produtora = "Produtora2" , Preco = 2 } },
            {Guid.Parse("961461cb-a8c3-411f-8245-24643aa53903"), new Jogo{ Id = Guid.Parse("961461cb-a8c3-411f-8245-24643aa53903"), Nome = "teste3", Produtora = "Produtora3" , Preco = 3 } },
            {Guid.Parse("f944f157-32f0-4f0f-8f4c-a91ee52b4385"), new Jogo{ Id = Guid.Parse("f944f157-32f0-4f0f-8f4c-a91ee52b4385"), Nome = "teste4", Produtora = "Produtora4" , Preco = 4 } },
            {Guid.Parse("62f3c312-971d-4013-9075-17977d262d63"), new Jogo{ Id = Guid.Parse("62f3c312-971d-4013-9075-17977d262d63"), Nome = "teste5", Produtora = "Produtora5" , Preco = 5 } },
            {Guid.Parse("b9604477-3152-481e-a1cb-f2af588ac426"), new Jogo{ Id = Guid.Parse("b9604477-3152-481e-a1cb-f2af588ac426"), Nome = "teste6", Produtora = "Produtora6" , Preco = 6 } }

        };


        public Task AtualizarJogo(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;

            return Task.CompletedTask;
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);

            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(x => x.Nome.Equals(nome) && x.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid idJogo)
        {
          jogos.Remove(idJogo);

          return Task.CompletedTask;  
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
