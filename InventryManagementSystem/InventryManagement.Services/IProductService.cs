using InventryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Services
{
	public interface IProductService
	{
		ProductModel CreateProduct(ProductModel productModel);
		bool DeleteProduct(int id);
		IEnumerable<ProductModel> GetAllProducts();
		ProductModel GetProductById(int id);
		ProductModel UpdateProduct(int id, ProductModel productModel);
		IEnumerable<CategoryModel> GetAllCategories();
		IEnumerable<SupplierModel> GetAllSuppliers();
	}
}
