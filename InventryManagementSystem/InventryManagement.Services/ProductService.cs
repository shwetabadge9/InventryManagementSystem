using AutoMapper;
using InventryManagement.Core.Models.Entities;
using InventryManagement.Models;
using InventryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}
		public ProductModel CreateProduct(ProductModel productModel)
		{
			return _mapper.Map<ProductModel>(_productRepository.CreateProduct(_mapper.Map<Product>(productModel)));
		}

		public bool DeleteProduct(int id)
		{
			_productRepository.DeleteProduct(id);
			return true;
		}

		public IEnumerable<CategoryModel> GetAllCategories()
		{
			return _mapper.Map<IEnumerable<CategoryModel>>(_productRepository.GetAllCategories());
		}

		public IEnumerable<ProductModel> GetAllProducts()
		{
			return _mapper.Map<IEnumerable<ProductModel>>(_productRepository.GetAllProducts());
		}

		public IEnumerable<SupplierModel> GetAllSuppliers()
		{
			return _mapper.Map<IEnumerable<SupplierModel>>(_productRepository.GetAllSuppliers());
		}

		public ProductModel GetProductById(int id)
		{
			var product = _productRepository.GetProductById(id);
			return _mapper.Map<ProductModel>(product);
		}

		public ProductModel UpdateProduct(int id, ProductModel productModel)
		{
			return _mapper.Map<ProductModel>(_productRepository.UpdateProduct(id, _mapper.Map<Product>(productModel)));
		}
	}
}
