using InventryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Services
{
	public interface ICategoryService
	{
		IEnumerable<CategoryModel>	GetAllCategory();
		CategoryModel GetCategoryById(int id);

		CategoryModel CreateCategory(CategoryModel category);
		CategoryModel UpdateCategory(int id,CategoryModel category);
		bool DeleteCategory(int id);
	}
}
