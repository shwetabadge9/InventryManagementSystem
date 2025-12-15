using AutoMapper;
using InventryManagement.Core.Models.Entities;
using InventryManagement.Models;
using InventryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventryManagement.UI.Controllers
{
	public class SupplierController : Controller
	{
		private readonly ISupplierService _supplierService;
		private readonly IMapper _mapper;

		public SupplierController(ISupplierService supplierService, IMapper mapper)
		{
			_supplierService = supplierService;
			_mapper = mapper;
		}

		// GET: SupplierController
		public ActionResult Index()
		{
			IEnumerable<SupplierModel> suppliersModel = _supplierService.GetAllSuppliers().ToList();
			var suppliers = _mapper.Map<IEnumerable<Supplier>>(suppliersModel);
			return View(suppliers);
		}

		// GET: SupplierController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SupplierController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(SupplierModel supplier)
		{
			try
			{
				var supplierModel = _mapper.Map<SupplierModel>(supplier);
				_supplierService.CreateSupplier(supplierModel);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(supplier);
			}
		}

		// GET: SupplierController/Edit/5
		public ActionResult Update(int id)
		{
			var SuppliersModel = _supplierService.GetSupplierById(id);
			var suppliers = _mapper.Map<Supplier>(SuppliersModel);
			return View(suppliers);
		}

		// POST: SupplierController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(int id, SupplierModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
				   _supplierService.UpdateSupplier(id, model);
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(model);
			}
		}

		// GET: SupplierController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SupplierController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			try
			{
				_supplierService.DeleteSupplier(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
