using InventryManagement.Core.Models;
using InventryManagement.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly InventryManagementDBContext _context;

		public ProductRepository(InventryManagementDBContext context)
		{
			_context = context;
		}

		public Product CreateProduct(Product product)
		{
			return _context.Products.Add(product).Entity;
		}

		public bool DeleteProduct(int id)
		{
			var Products = _context.Products.Find(id);
			if (Products == null)
			{
				return false;
			}
			_context.Products.Remove(Products);
			_context.SaveChanges();
			return true;
		}

		public IEnumerable<Category> GetAllCategories()
		{
			return _context.Categories.ToList();
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _context.Products.ToList();
		}

		public IEnumerable<Supplier> GetAllSuppliers()
		{
			return _context.Suppliers.ToList();
		}

		public Product GetProductById(int id)
		{
			var products = _context.Products.Find(id);
			return products;
		}

		public Product UpdateProduct(int id, Product product)
		{
			var existingproducts =  _context.Products.Find(id);
			if (existingproducts != null)
			{
				existingproducts.ProductName = product.ProductName;
				existingproducts.CategoryId = product.CategoryId;
				existingproducts.SupplierId = product.SupplierId;
				existingproducts.Price = product.Price;
				existingproducts.QuantityInStock = product.QuantityInStock;
				_context.Products.Update(existingproducts);
				_context.SaveChanges();
			}
			return existingproducts;
		}
	}
}
