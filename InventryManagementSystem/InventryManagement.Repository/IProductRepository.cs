using InventryManagement.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Repository
{
	public interface IProductRepository
	{
		Product CreateProduct(Product product);
		Product GetProductById(int id);
		IEnumerable<Product> GetAllProducts();
		Product UpdateProduct(int id, Product product);
		bool DeleteProduct(int id);
		IEnumerable<Category> GetAllCategories();
		IEnumerable<Supplier> GetAllSuppliers();
	}
}
