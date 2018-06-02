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
                Nome = "Pão"
                ,
                Categoria = "Alimento"
                ,
                PrecoUnitario = 0.40
                ,
                Unidade = "Unidade"
            };

            var compra = new Compra
            {
                Produto = produto
                ,
                Quantidade = 10
            };

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }
        }
    }
}
