using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Services.Interfaces;
using ProductManagement.UI.Models;
using AutoMapper;
using ProductManagement.Domain;

namespace ProductManagement.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appState;

        public ProductsController(IProductsService productsService, AppSettings appState, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
            _appState = appState;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetProducts();
            var viewModel = new ProductListViewModel()
            {
                DataStorage = _appState.CurrentDataStorage,
                Products = products
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateDataStorage(DataStorageOption dataStorage)
        {
            _appState.CurrentDataStorage = dataStorage;
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _productsService.AddProduct(_mapper.Map<Product>(product));
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}