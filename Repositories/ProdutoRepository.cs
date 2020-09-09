using EfCore.Domains;
using EfCore.Interfaces;
using EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
        
        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="produto">objeto produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona um produto ao dbset do contexto
                _ctx.Produtos.Add(produto);

                //Salva as alteracoes no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto pelo id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Produto buscado</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Produto buscado</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto que sera editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Busca o produto por id
                Produto produtoTemp = BuscarPorId(produto.Id);

                // Verifica se o produto existe
                // Caso não exista cria uma mensagem
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista, fara a alteração
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                _ctx.Produtos.Update(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista os produtos cadastrados
        /// </summary>
        /// <returns>Lista de produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Busca o produto por id
                Produto produtoTemp = BuscarPorId(id);

                // Verifica se o produto existe
                // Caso não exista cria uma mensagem
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Produtos.Remove(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
