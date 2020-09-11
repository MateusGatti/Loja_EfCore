using EfCore.Domains;
using EfCore.Interfaces;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Criando objeto tipo pedido e passando os valores
                Pedido pedido = new Pedido
                {
                    status = "Pedido efetuado",
                    OrderDate = DateTime.Now,
                };

                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id,
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                _ctx.Pedidos.Add(pedido);

                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
