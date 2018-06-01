using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = context.Produtos.ToList();
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.Nome);
                }

                Console.WriteLine("\n\n===============================\n\n");

                foreach (var item in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(item.State);
                }

                Console.WriteLine("\n\n===============================\n\n");

                var p1 = produtos.First();
                p1.Nome = "Alterado";
                context.Update(p1);
                
            }


                Console.ReadKey();
        }
    }
}
