using Lab2_PWA_Juegos.Models;
using Lab2_PWA_Juegos.Repositories.Departures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2_PWA_Juegos.Controllers
{
    public class DepartureController : Controller
    {
        private readonly IDeparturesRepository _departuresRepository;
        private SelectList _productsList;
        private SelectList _employeesList;

        public DepartureController(IDeparturesRepository departuresRepository)
        {
            _departuresRepository = departuresRepository;
            _productsList = new SelectList(
                                           _departuresRepository.GetAllProducts(),
                                           nameof(ProductsModel.ProductID),
                                           nameof(ProductsModel.PName));
            _employeesList = new SelectList(
                                            _departuresRepository.GetAllEmployees(),
                                            nameof(EmployeesModel.EmployeeID),
                                            nameof(EmployeesModel.EName));

        }

        public ActionResult Index()
        {
            return View(_departuresRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Products = _productsList;
            ViewBag.Employees = _employeesList;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartureModel departure)
        {
            try
            {
                _departuresRepository.Add(departure);

                TempData["createdeparture"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Products = _productsList;
                ViewBag.Employees = _employeesList;
                return View(departure);

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var departure = _departuresRepository.GetById(id);

            _productsList = new SelectList(
                                            _departuresRepository.GetAllProducts(),
                                            nameof(ProductsModel.ProductID),
                                            nameof(ProductsModel.PName),
                                            departure?.Products?.ProductID);

            _employeesList = new SelectList(
                                            _departuresRepository.GetAllEmployees(),
                                            nameof(EmployeesModel.EmployeeID),
                                            nameof(EmployeesModel.EName),
                                            departure?.Employees?.EmployeeID);

            ViewBag.Products = _productsList;
            ViewBag.Employees = _employeesList;
            return View(departure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartureModel departure)
        {
            try
            {
                _departuresRepository.Edit(departure);

                TempData["editdeparture"] = "Datos editados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Products = _productsList;
                ViewBag.Employees = _employeesList;
                return View(departure);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var departure = _departuresRepository.GetById(id);

            if (departure == null)
            {
                return NotFound();
            }

            // Obtener todos los productos y empleados
            var allProducts = _departuresRepository.GetAllProducts();
            var allEmployees = _departuresRepository.GetAllEmployees();

            // Buscar el producto y empleado asociado con la salida
            departure.Products = allProducts.FirstOrDefault(p => p.ProductID == departure.ProductID);
            departure.Employees = allEmployees.FirstOrDefault(e => e.EmployeeID == departure.EmployeeID);

            return View(departure);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DepartureModel departure)
        {
            try
            {
                _departuresRepository.Delete(departure.DepartureID);

                TempData["deletedeparture"] = "Datos eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Manejar errores aquí si es necesario
                return View(departure);
            }
        }

    }
}
