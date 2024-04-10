using Lab2_PWA_Juegos.Models;
using Lab2_PWA_Juegos.Repositories.Customers;
using Lab2_PWA_Juegos.Repositories.Suppliers;
using Lab2_PWA_Juegos.Services_Email;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_PWA_Juegos.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomersController(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ActionResult Index()
        {
            return View(_customerRepository.GetAll());
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersModel customersModel)
        {
            try
            {
                _customerRepository.Add(customersModel);

                TempData["createcustomers"] = "Datos guardados exitosamente";

                string email = customersModel.Email;
                string subject = "Bienvenid@";
                string body = "Bievenido a la libreria " + customersModel.CName;

                _emailService.SendEmail(email, customersModel.CName, subject, body);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(customersModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customers = _customerRepository.GetById(id);

            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersModel customersModel)
        {
            try
            {
                _customerRepository.Edit(customersModel);

                TempData["editcustomers"] = "Datos editados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(customersModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customers = _customerRepository.GetById(id);

            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: SuppliersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomersModel customersModel)
        {
            try
            {
                _customerRepository.Delete(customersModel.CustomerID);

                TempData["deletecustomers"] = "Dato eliminados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(customersModel);
            }
        }
    }
}
