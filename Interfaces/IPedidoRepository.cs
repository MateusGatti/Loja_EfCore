using EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Interfaces
{
    interface IPedidoRepository
    {
        List<Pedido> Listar();

        Pedido BuscarPorId(Guid id);

        /// <summary>
        /// Adiciona um pedido
        /// </summary>
        /// <param name="pedidosItens"></param>
        /// <returns></returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);

    }
}
