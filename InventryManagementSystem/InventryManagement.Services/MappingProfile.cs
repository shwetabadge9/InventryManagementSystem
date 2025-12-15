using AutoMapper;
using InventryManagement.Core.Models.Entities;
using InventryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Services
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Category, CategoryModel>().ReverseMap();
			CreateMap<Supplier, SupplierModel>().ReverseMap();
			CreateMap<Product, ProductModel>().ReverseMap();
		}
	}
}
