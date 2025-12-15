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
	public class SupplierService : ISupplierService
	{
		private readonly ISupplierRepository _supplierRepository;
		private readonly IMapper _mapper;
		public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
		{
			_supplierRepository = supplierRepository;
			_mapper = mapper;
		}
		public SupplierModel CreateSupplier(SupplierModel supplier)
		{
			return _mapper.Map<SupplierModel>(_supplierRepository.CreateSupplier(_mapper.Map<Supplier>(supplier)));
		}

		public bool DeleteSupplier(int id)
		{
			return _supplierRepository.DeleteSupplier(id);
		}

		public IEnumerable<SupplierModel> GetAllSuppliers()
		{
			return _mapper.Map<IEnumerable<SupplierModel>>(_supplierRepository.GetAllSuppliers());
		}

		public SupplierModel GetSupplierById(int id)
		{
			var suppliers = _supplierRepository.GetSupplierById(id);
			return _mapper.Map<SupplierModel>(suppliers);
		}

		public SupplierModel UpdateSupplier(int id, SupplierModel supplier)
		{
			return _mapper.Map<SupplierModel>(_supplierRepository.UpdateSupplier(id, _mapper.Map<Supplier>(supplier)));
		}
	}
}
