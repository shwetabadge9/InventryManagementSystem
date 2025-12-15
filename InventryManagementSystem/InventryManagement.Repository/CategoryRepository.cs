using InventryManagement.Core.Models;
using InventryManagement.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Repository
{
	
	public class CategoryRepository : ICategoryRepository
	{
		private readonly InventryManagementDBContext _context;

		public CategoryRepository(InventryManagementDBContext context)
		{
			_context = context;
		}

		public Category CreateCategory(Category category)
		{
			var categories = _context.Categories.Add(category);
			_context.SaveChanges();
			return categories.Entity;
		}

		public bool DeleteCategory(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return false;
			}
			_context.Categories.Remove(category);
			_context.SaveChanges();
			return true;
		}

		public IEnumerable<Category> GetAllCategory()
		{
			return _context.Categories;
		}

		public Category GetCategoryById(int id)
		{
			return _context.Categories.Find(id);
		}

		public Category UpdateCategory(int id, Category category)
		{
			var existingCategory = _context.Categories.Find(id);
			if (existingCategory == null)
			{
				return category;
			}
			// Update properties
			existingCategory.CategoryName = category.CategoryName;
			// Add other property updates as needed

			_context.Categories.Update(existingCategory);
			_context.SaveChanges();
			return existingCategory;
		}
	}
}
