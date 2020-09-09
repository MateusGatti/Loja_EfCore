using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public abstract class BaseDomain
    {
        public Guid Id { get; set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }
    }
    
}
