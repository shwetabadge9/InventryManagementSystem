using InventryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManagement.Services
{
	public interface ISupplierService
	{
		IEnumerable<SupplierModel> GetAllSuppliers();
		SupplierModel GetSupplierById(int id);
		SupplierModel CreateSupplier(SupplierModel supplier);
		bool DeleteSupplier(int id);
		SupplierModel UpdateSupplier(int id, SupplierModel supplier);
	}
}
