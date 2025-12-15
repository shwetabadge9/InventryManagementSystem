using InventryManagement.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Repository
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetAllCategory();
		Category GetCategoryById(int id);

		Category CreateCategory(Category category);

		bool DeleteCategory(int id);
		Category UpdateCategory(int id, Category category);
	}
}
