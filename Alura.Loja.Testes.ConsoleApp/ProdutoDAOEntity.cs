using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private LojaContext _context;

        public ProdutoDAOEntity()
        {
            _context = new LojaContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public void Adicionar(Produto produto)
        {
            using (var contextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Produtos.Add(produto);
                    _context.SaveChanges();
                    contextTransaction.Commit();
                }
                catch (Exception)
                {
                    contextTransaction.Rollback();
                }

            }
        }

        public void Atualizar(Produto produto)
        {
            using (var contextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Produtos.Update(produto);
                    _context.SaveChanges();
                    contextTransaction.Commit();
                }
                catch (Exception)
                {
                    contextTransaction.Rollback();
                }

            }
        }

        public void Remover(Produto produto)
        {
            using (var contextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Produtos.Remove(produto);
                    _context.SaveChanges();
                    contextTransaction.Commit();
                }
                catch (Exception)
                {
                    contextTransaction.Rollback();
                }

            }
        }

        public IList<Produto> Selecionar(Produto produto)
        {
            return new List<Produto>(_context.Produtos.ToList());
        }
    }
}
