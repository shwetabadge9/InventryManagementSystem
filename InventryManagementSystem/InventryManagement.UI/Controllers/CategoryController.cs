using AutoMapper;
using InventryManagement.Core.Models.Entities;
using InventryManagement.Models;
using InventryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventryManagement.UI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}
		// GET: CategoryController1
		public ActionResult GetCategories()
		{
			IEnumerable<CategoryModel> categoryModels = _categoryService.GetAllCategory();

			var categories = _mapper.Map<IEnumerable<Category>>(categoryModels);
			return View(categories);
			
		}


		// GET: CategoryController1/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategoryController1/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CategoryModel model)
		{
			try
			{
				if(ModelState.IsValid)
				{
					// Map ViewModel -> CategoryModel
					var categoryModel = _mapper.Map<CategoryModel>(model);

					// Call service to create
					_categoryService.CreateCategory(categoryModel);
				}
				
				return RedirectToAction(nameof(GetCategories));
			}
			catch
			{
				return View(model);
			}
		}

		// GET: CategoryController1/Edit/5
		public ActionResult Edit(int id)
		{
			var categoryModel = _categoryService.GetCategoryById(id);
			var category = _mapper.Map<Category>(categoryModel);
			return View(category);
		}

		// POST: CategoryController1/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, CategoryModel category)
		{
			try
			{
				if(ModelState.IsValid)
				{
					_categoryService.UpdateCategory(id,category);
				}
				return RedirectToAction(nameof(GetCategories));
			}
			catch
			{
				return View(category);
			}
		}

		// GET: CategoryController1/Delete/5
		public ActionResult Delete(int id)
		{
			var categoryModel = _categoryService.GetCategoryById(id);
			var category = _mapper.Map<Category>(categoryModel);
			return View(category);
		}

		// POST: CategoryController1/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			try
			{
				_categoryService.DeleteCategory(id);

				return RedirectToAction(nameof(GetCategories));
			}
			catch
			{
				return View(GetCategories);
			}
		}
	}
}
