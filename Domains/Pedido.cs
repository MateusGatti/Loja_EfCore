﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public class Pedido : BaseDomain
    {

        public string status { get; set; }

        public DateTime OrderDate { get; set; }

        public List<PedidoItem> PedidosItens { get; set; }


        public Pedido()
        {
            PedidosItens = new List<PedidoItem>();
        }
    }
}
