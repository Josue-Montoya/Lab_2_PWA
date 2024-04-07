﻿using Lab2_PWA_Juegos.Models;
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Suppliers = _suppliersList;
                return View(products);
               
            }
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
            var products = _productsRepository.GetById(id);

            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductsModel products)
        {
            try
            {
                _productsRepository.Delete(products.ProductID);

                TempData["message"] = "Producto Eliminado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(products);
            }
        }
    }
}
