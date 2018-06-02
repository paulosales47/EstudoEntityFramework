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
            var produto = new Produto
            {
                Nome = "Carro"
                ,
                Categoria = "Veiculo"
                ,
                PrecoUnitario = 45999.99
                ,
                Unidade = "Unidade"
            };

            var produto2 = new Produto
            {
                Nome = "Suco"
                ,
                Categoria = "Bebidas"
                ,
                PrecoUnitario = 15.70
                ,
                Unidade = "Litros"
            };

            var promocao = new Promocao
            {
                Descricao = "Natal"
                ,
                DtInicio = DateTime.Now
                ,
                DtTermino = DateTime.Now.AddDays(10)
            };

            promocao.AdicionaProduto(produto);
            promocao.AdicionaProduto(produto2);

            using (var context = new LojaContext())
            {
                context.Promocoes.Add(promocao);
                context.SaveChanges();
            }
        }
    }
}
