using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsShop.Application.Models
{
    public class Product
    {
        public virtual long? Id { get; protected internal set; }
        public virtual string Name { get; protected internal set; }
        public virtual string Description { get; protected internal set; }
        public virtual ProductStatus Status { get; protected internal set; }
        public virtual int Quantity { get; protected internal set; }
        public virtual string FileId { get; protected internal set; }
        public virtual long? CategoryId { get; protected internal set; }
        public virtual long? PriceId { get; protected internal set; }
        public virtual Category Category { get; protected internal set; }
        public virtual Price Price { get; protected internal set; }

    }
}
