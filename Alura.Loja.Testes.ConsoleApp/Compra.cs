using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra
    {
        public int Id { get; set; }
        public int ProdutoId { get; internal set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public double  Preco
        {
            get { return (Quantidade * Produto.PrecoUnitario); }
            internal set { }
        }

        public Compra()
        {
            this.Produto = new Produto();
        }


    }
}
