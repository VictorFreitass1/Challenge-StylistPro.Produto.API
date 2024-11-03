using StylistPro.Produto.Data.AppData;
using StylistPro.Produto.Domain.Entities;
using StylistPro.Produto.Domain.Interfaces;

namespace StylistPro.Produto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProdutoEntity? DeletarDados(int id)
        {
            var produto = _context.Produto.Find(id);

            if(produto is not null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();

                return produto;
            }
            return null;
        }

        public ProdutoEntity? EditarDados(ProdutoEntity entity)
        {
            var produto = _context.Produto.Find(entity.Id);

            if (produto is not null)
            {
                produto.Nome = entity.Nome;
                produto.Descricao = entity.Descricao;

                _context.Produto.Update(produto);
                _context.SaveChanges();

                return produto;
            }
            return null;
        }

        public ProdutoEntity? ObterPorId(int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto is not null)
            { 

                return produto;
            }

            return null;
        }

        public IEnumerable<ProdutoEntity> ObterTodos()
        {
            var entity = _context.Produto.ToList();

            return entity;
        }


        public ProdutoEntity? SalvarDados(ProdutoEntity entity)
        {
            _context.Produto.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
