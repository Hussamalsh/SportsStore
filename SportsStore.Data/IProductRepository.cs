using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Data.Models
{
    public interface IProductRepository
    {
        //This interface uses IEnumerable<T > to allow a caller to obtain a sequence of Product objects, without
        //saying how or where the data is stored or retrieved
                IEnumerable<Product> Products { get; }
    }
}
