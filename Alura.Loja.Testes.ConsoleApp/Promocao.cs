using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int PromocaoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtTermino { get; set; }
        public IList<PromocaoProduto> Produtos { get; set; }
    }
}
