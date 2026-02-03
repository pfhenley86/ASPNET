using System.Collections.Generic;

namespace Testing.Models;

public class ProductRepository : IProductRepository
{
    public IEnumerable<Product> GetAllProducts()
    {
        throw new System.NotImplementedException();
    }
}