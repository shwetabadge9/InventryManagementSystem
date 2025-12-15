using InventryManagement.Core.Models;
using InventryManagement.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Repository
{
	public class SupplierRepository : ISupplierRepository
	{
		private readonly InventryManagementDBContext _context;
		public SupplierRepository(InventryManagementDBContext context)
		{
			_context = context;
		}
		public Supplier CreateSupplier(Supplier supplier)
		{ 
			_context.Suppliers.Add(supplier);
			_context.SaveChanges();
			return supplier;
		}

		public bool DeleteSupplier(int id)
		{
			var supplier = _context.Suppliers.Find(id);
			if (supplier == null)
			{
				return false;
			}
			_context.Suppliers.Remove(supplier);
			_context.SaveChanges();
			return true;
		}

		public IEnumerable<Supplier> GetAllSuppliers()
		{
			return _context.Suppliers.ToList();
		}

		public Supplier GetSupplierById(int id)
		{
			return _context.Suppliers.Find(id);
		}

		public Supplier UpdateSupplier(int id, Supplier supplier)
		{
			var existingSupplier = _context.Suppliers.Find(id);
			if (existingSupplier == null)
			{
				return null;
			}
			existingSupplier.SupplierName = supplier.SupplierName;
			existingSupplier.ContactNumber = supplier.ContactNumber;
			existingSupplier.Address = supplier.Address;
			_context.Suppliers.Update(existingSupplier);
			_context.SaveChanges();
			return existingSupplier;
		}
	}
}
