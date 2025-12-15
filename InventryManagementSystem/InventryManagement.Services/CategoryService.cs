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
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public CategoryModel CreateCategory(CategoryModel category)
		{
			return _mapper.Map<CategoryModel>(_categoryRepository.CreateCategory(_mapper.Map<Category>(category)));
		}

		public bool DeleteCategory(int id)
		{
			return _categoryRepository.DeleteCategory(id);
		}

		public IEnumerable<CategoryModel> GetAllCategory()
		{
			return _mapper.Map<IEnumerable<CategoryModel>>(_categoryRepository.GetAllCategory());
		}

		public CategoryModel GetCategoryById(int id)
		{
			return _mapper.Map<CategoryModel>(_categoryRepository.GetCategoryById(id));
		}

		public CategoryModel UpdateCategory(int id, CategoryModel category)
		{
			return _mapper.Map<CategoryModel>(_categoryRepository.UpdateCategory(id, _mapper.Map<Category>(category)));
		}
	}
}
