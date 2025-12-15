using InventryManagement.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Repository
{
	public interface ISupplierRepository
	{
		IEnumerable<Supplier> GetAllSuppliers();
		Supplier GetSupplierById(int id);
		Supplier CreateSupplier(Supplier supplier);
		bool DeleteSupplier(int id);
		Supplier UpdateSupplier(int id, Supplier supplier);
	}
}
