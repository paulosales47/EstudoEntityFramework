using Microsoft.EntityFrameworkCore;
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

                var produto = context
                    .Produtos
                    .Where(p => p.Id == 5002)
                    .First();

                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Id == 1002)
                    .Load();
                
                
                
                Console.WriteLine($"Total em vendas do produto {produto.Nome}");
                foreach (var compra in produto.Compras)
                {
                    Console.WriteLine(compra.Preco);
                }


            }

            Console.ReadKey();
        }
    }
}
