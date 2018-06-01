using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDAO : IDisposable, IProdutoDAO
    {
        private SqlConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)";

                var paramNome = new SqlParameter("nome", produto.Nome);
                insertCmd.Parameters.Add(paramNome);

                var paramCategoria = new SqlParameter("categoria", produto.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                var paramPreco = new SqlParameter("preco", produto.Preco);
                insertCmd.Parameters.Add(paramPreco);

                insertCmd.ExecuteNonQuery();
            } catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Produtos SET Nome = @nome, Categoria = @categoria, Preco = @preco WHERE Id = @id";

                var paramNome = new SqlParameter("nome", produto.Nome);
                var paramCategoria = new SqlParameter("categoria", produto.Categoria);
                var paramPreco = new SqlParameter("preco", produto.Preco);
                var paramId = new SqlParameter("id", produto.Id);
                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramCategoria);
                updateCmd.Parameters.Add(paramPreco);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            } catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Remover(Produto produto)
        {
            try
            {
                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Produtos WHERE Id = @id";

                var paramId = new SqlParameter("id", produto.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            } catch(SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public IList<Produto> Selecionar(Produto produto)
        {
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Produtos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Produto p = new Produto();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Nome = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.Preco = Convert.ToDouble(resultado["Preco"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}