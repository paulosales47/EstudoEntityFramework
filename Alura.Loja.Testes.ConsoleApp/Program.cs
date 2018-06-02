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
            var endereco = new Endereco
            {
                Logradouro = "Praça primeiro de maio"
                ,
                Bairro = "PQ. Novo Horizonte"
                ,
                Cidade = "SJC"
            };

            var cliente = new Cliente
            {
                Nome = "Paulo Sampaio"
                ,
                EnderecoEntrega = endereco
            };
            
            using (var context = new LojaContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }
    }
}
