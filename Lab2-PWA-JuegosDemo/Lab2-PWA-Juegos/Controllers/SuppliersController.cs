using Lab2_PWA_Juegos.Models;
using Lab2_PWA_Juegos.Repositories.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_PWA_Juegos.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public ActionResult Index()
        {
            return View(_suppliersRepository.GetAll());
        }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersModel suppliersModel)
        {
            try
            {
                _suppliersRepository.Add(suppliersModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(suppliersModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var suppliers = _suppliersRepository.GetById(id);

            if (suppliers == null)
            {
                return NotFound();
            }

            return View(suppliers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersModel suppliersModel)
        {
            try
            {
                _suppliersRepository.Edit(suppliersModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(suppliersModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var suppliers = _suppliersRepository.GetById(id);

            if (suppliers == null)
            {
                return NotFound();
            }

            return View(suppliers);
        }

        // POST: SuppliersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuppliersModel suppliersModel)
        {
            try
            {
                _suppliersRepository.Delete(suppliersModel.SupplierID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(suppliersModel);
            }
        }
    }
}
