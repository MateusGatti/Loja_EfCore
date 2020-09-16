using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }

        public float Preco { get; set; }


        
        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; }

        public List<PedidoItem> PedidosItens { get; set; }
    }
}
