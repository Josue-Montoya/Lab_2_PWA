using Lab2_PWA_Juegos.Models;
using Lab2_PWA_Juegos.Repositories.Entrance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2_PWA_Juegos.Controllers
{
    public class EntranceController : Controller
    {
        private readonly IEntranceRepository _entranceRepository;
        private SelectList _productsList;
        private SelectList _suppliersList;

        public EntranceController(IEntranceRepository entranceRepository)
        {
            _entranceRepository = entranceRepository;
            _productsList = new SelectList(
                                           _entranceRepository.GetAllProducts(),
                                           nameof(ProductsModel.ProductID),
                                           nameof(ProductsModel.PName));
            _suppliersList = new SelectList(
                                            _entranceRepository.GetAllSuppliers(),
                                            nameof(SuppliersModel.SupplierID),
                                            nameof(SuppliersModel.SName));

        }

        public ActionResult Index()
        {
            return View(_entranceRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Products = _productsList;
            ViewBag.Suppliers = _suppliersList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntranceModel entrance)
        {
            try
            {
                _entranceRepository.Add(entrance);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Products = _productsList;
                ViewBag.Suppliers = _suppliersList;
                return View(entrance);

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entrance = _entranceRepository.GetById(id);

            _productsList = new SelectList(
                                            _entranceRepository.GetAllProducts(),
                                            nameof(ProductsModel.ProductID),
                                            nameof(ProductsModel.PName),
                                            entrance?.Products?.ProductID);

            _suppliersList = new SelectList(
                                            _entranceRepository.GetAllSuppliers(),
                                            nameof(SuppliersModel.SupplierID),
                                            nameof(SuppliersModel.SName),
                                            entrance?.Suppliers?.SupplierID);

            ViewBag.Products = _productsList;
            ViewBag.Suppliers = _suppliersList;
            return View(entrance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EntranceModel entrance)
        {
            try
            {
                _entranceRepository.Edit(entrance);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Products = _productsList;
                ViewBag.Suppliers = _suppliersList;
                return View(entrance);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var entrance = _entranceRepository.GetById(id);

            if (entrance == null)
            {
                return NotFound();
            }

            // Obtener todos los productos y empleados
            var allProducts = _entranceRepository.GetAllProducts();
            var allSuppliers = _entranceRepository.GetAllSuppliers();

            // Buscar el producto y proveedor asociado con la entrada
            entrance.Products = allProducts.FirstOrDefault(p => p.ProductID == entrance.ProductID);
            entrance.Suppliers = allSuppliers.FirstOrDefault(s => s.SupplierID == entrance.SupplierID);

            return View(entrance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EntranceModel entrance)
        {
            try
            {
                _entranceRepository.Delete(entrance.EntranceID);

                TempData["message"] = "Producto Eliminado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Manejar errores aquí si es necesario
                return View(entrance);
            }
        }




    }
}