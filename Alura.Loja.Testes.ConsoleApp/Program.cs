using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            using (var context = new LojaContext())
            {
                context.Produtos.ToList();
                var  entityEntries = context.ChangeTracker.Entries();

                ExibeEstadoProduto(entityEntries);

                var p1 = new Produto
                {
                    Nome = "Novo produto"
                    ,
                    Preco = 78.8
                    ,
                    Categoria = "Sem categoria"
                };

                context.Add(p1);

                ExibeEstadoProduto(entityEntries);

                context.SaveChanges();

                ExibeEstadoProduto(entityEntries);

            }
            
            Console.ReadKey();
        }

        private static void ExibeEstadoProduto(IEnumerable<EntityEntry> entityEntries)
        {
            Console.WriteLine("\n=========================================\n");
            foreach (var item in entityEntries)
            {
                Console.WriteLine(item.State + " - " + item.Entity.ToString());
            }
            
        }
    }
}
