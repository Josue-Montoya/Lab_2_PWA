using Lab2_PWA_Juegos.Models;
using Lab2_PWA_Juegos.Repositories.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2_PWA_Juegos.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private SelectList _suppliersList;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
            _suppliersList = new SelectList(
                                            _productsRepository.GetAllSuppliers(),
                                            nameof(SuppliersModel.SupplierID),
                                            nameof(SuppliersModel.SName));
                                            
        }

        public ActionResult Index()
        {
            return View(_productsRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Suppliers = _suppliersList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsModel products)
        {
            try
            {
                _productsRepository.Add(products);

                TempData["createproduts"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Suppliers = _suppliersList;
                return View(products);
               
            }
        }

        [HttpGet]
        public ActionResult GetPriceById(int productId)
        {
            var price = _productsRepository.GetPriceById(productId);
            return Json(price);
        }


        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var products = _productsRepository.GetById(id);

            _suppliersList = new SelectList(
                                            _productsRepository.GetAllSuppliers(),
                                            nameof(SuppliersModel.SupplierID),
                                            nameof(SuppliersModel.SName),
                                            products?.Suppliers?.SupplierID);

            ViewBag.Suppliers = _suppliersList;
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public ActionResult Edit(ProductsModel products)
        {
            try
            {
                _productsRepository.Edit(products);

                TempData["editdproducts"] = "Datos editados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                ViewBag.Suppliers = _suppliersList;
                return View(products);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _productsRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            // Obtener todos los proveedores
            var allSuppliers = _productsRepository.GetAllSuppliers();

            // Buscar el proveedor asociado con el producto
            var SName = allSuppliers.FirstOrDefault(s => s.SupplierID == product.SupplierID)?.SName;

            // Verifica si SName tiene el valor correcto
            ViewBag.SName = SName;

            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductsModel products)
        {
            try
            {
                _productsRepository.Delete(products.ProductID);

                TempData["deleteproducts"] = "Datos eliminados exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Manejar errores aquí si es necesario
                return View(products);
            }
        }


    }
}
