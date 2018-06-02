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
                var p1 = context
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                    

                Console.WriteLine("Lista de produtos da promoção:\n");
                foreach (var produto in p1.Produtos)
                {
                    Console.WriteLine(produto.Produto.Nome);
                }

                
            }

            Console.ReadKey();
        }
    }
}
