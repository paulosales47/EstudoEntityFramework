using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            RecuperarProdutos();
            ExcluirProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var context = new LojaContext())
            {
                using (var contextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var produtos = context.Produtos.ToList();

                        foreach (var produto in produtos)
                        {
                            context.Produtos.Remove(produto);
                        }

                        context.SaveChanges();
                        contextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        contextTransaction.Rollback();
                    }
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var context = new LojaContext())
            {
                var produtos = context.Produtos.ToList();

                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            Produto p2 = new Produto();
            p2.Nome = "Harry Potter e as Reliquias da Morte";
            p2.Categoria = "Livros";
            p2.Preco = 19.89;

            using (var context = new LojaContext())
            {
                using (var contextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Produtos.AddRange(p, p2);
                        context.SaveChanges();
                        contextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        contextTransaction.Rollback();
                    }
                }


            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
