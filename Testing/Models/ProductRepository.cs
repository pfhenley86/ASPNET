using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Testing.Models;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    
    // GET All Products
    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
    }

    // GET Single Product
    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("Select * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
    }
    
    // UPDATE Single Product
    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id", new { name = product.Name, price = product.Price, id = product.ProductID });
    }
}