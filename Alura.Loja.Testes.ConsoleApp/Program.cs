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
            GravarUsandoEntity();
            RecuperarProdutos();

            ExcluirProdutos();
            RecuperarProdutos();

            GravarUsandoEntity();
            AtualizarProdutos();
            RecuperarProdutos();

            Console.ReadKey();
        }

        private static void AtualizarProdutos()
        {
            using (var context = new ProdutoDAOEntity())
            {
                var produto = context.Selecionar(new Produto()).First();
                produto.Nome = "Produto editado";
                context.Atualizar(produto);
            }
        }

        private static void ExcluirProdutos()
        {
            using (var context = new ProdutoDAOEntity())
            {
                var produto = context.Selecionar(new Produto()).First();
                context.Remover(produto);
            }
        }

        private static void RecuperarProdutos()
        {
            using (var context = new ProdutoDAOEntity())
            {
                var produtos = context.Selecionar(new Produto());

                Console.WriteLine("\n\nProdutos encontrados:\n\n");
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

            using (var context = new ProdutoDAOEntity())
            {
                context.Adicionar(p);
            }
        }
    }
}
