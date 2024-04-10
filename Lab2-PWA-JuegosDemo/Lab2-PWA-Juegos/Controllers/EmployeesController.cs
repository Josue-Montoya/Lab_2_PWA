using Lab2_PWA_Juegos.Models;
using Lab2_PWA_Juegos.Repositories.Employees;
using Lab2_PWA_Juegos.Repositories.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_PWA_Juegos.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public ActionResult Index()
        {
            return View(_employeesRepository.GetAll());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeesModel employeesModel)
        {
            try
            {
                _employeesRepository.Add(employeesModel);

                TempData["createemployees"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(employeesModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employees = _employeesRepository.GetById(id);

            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesModel employeesModel)
        {
            try
            {
                _employeesRepository.Edit(employeesModel);

                TempData["editdemployees"] = "Datos editados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(employeesModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employees = _employeesRepository.GetById(id);

            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeesModel employeesModel)
        {
            try
            {
                _employeesRepository.Delete(employeesModel.EmployeeID);

                TempData["deleteemployees"] = "Dato eliminados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(employeesModel);
            }
        }
    }
}
