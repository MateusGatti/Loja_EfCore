using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Domains;
using EfCore.Repositories;
using EfCore.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        /// <summary>
        /// Mostra os produtos cadastrados
        /// </summary>
        /// <returns>Lista de produtos</returns>
        [HttpGet]
        public IActionResult Get()
        {
        

            try
            {
                var produtos = _produtoRepository.Listar();

                if (produtos.Count == 0)
                    return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<RacaController>/5
        /// <summary>
        /// Mostra um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>produto com o id escolhido</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Moeda dolar = new Moeda();

            try
            {
                Produto produto = _produtoRepository.BuscarPorId(id);

                if (produto == null)
                    return NotFound();

                return Ok(new { produto, valorDolar = dolar.GetDolarValue() * produto.Preco });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<AlunoController>
        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <param name="produto">objeto produto</param>
        /// <returns>Produto cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                if (produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;
                }


                _produtoRepository.Adicionar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlunoController>/5
        /// <summary>
        /// Altera um produto
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <param name="produto">objeto produto com as alterações</param>
        /// <returns>produto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
               

                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlunoController>/5
        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>Id do produto excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoRepository.BuscarPorId(id);
                if (produto == null)
                    return NotFound();

                _produtoRepository.Remover(id);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
