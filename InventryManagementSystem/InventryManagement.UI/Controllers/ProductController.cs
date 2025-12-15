using AutoMapper;
using InventryManagement.Core.Models.Entities;
using InventryManagement.Models;
using InventryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventryManagement.UI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		// GET: ProductController
		public ActionResult Index()
		{
			IEnumerable<ProductModel> productsModel = _productService.GetAllProducts().ToList();
			var products = _mapper.Map<IEnumerable<Product>>(productsModel);
			return View(products);
		}

		// GET: ProductController/Create
		public ActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(_productService.GetAllCategories(), "CategoryID", "CategoryName");
			ViewBag.SupplierId = new SelectList(_productService.GetAllSuppliers(), "SupplierID", "SupplierName");
			return View();
		}

		// POST: ProductController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ProductModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					// Map ViewModel -> ProductModel
					var productModel = _mapper.Map<ProductModel>(model);
					// Call service to create
					_productService.CreateProduct(productModel);
					return RedirectToAction(nameof(Index));
				}
				// Re-populate dropdowns if model validation fails
				ViewBag.CategoryId = new SelectList(_productService.GetAllCategories(), "CategoryID", "CategoryName", model.CategoryId);
				ViewBag.SupplierId = new SelectList(_productService.GetAllSuppliers(), "SupplierID", "SupplierName", model.SupplierId);
				return View(model);
			}
			catch
			{
				return View(model);
			}
		}

		// GET: ProductController/Edit/5
		public ActionResult Edit(int id)
		{
			var productModel = _productService.GetProductById(id);
			var product = _mapper.Map<Product>(productModel);
			return View(product);
		}

		// POST: ProductController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, ProductModel model)
		{
			try
			{
				_productService.UpdateProduct(id, model);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductController/Delete/5
		public ActionResult Delete(int id)
		{
			var productModel = _productService.GetProductById(id);
			var product = _mapper.Map<Product>(productModel);
			return View(product);
		}

		// POST: ProductController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public ActionResult Deleteconfirm(int id)
		{
			try
			{
				_productService.DeleteProduct(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
