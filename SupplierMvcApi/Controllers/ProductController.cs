using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierMvcApi.DataServices;
using SupplierMvcApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierMvcApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IDataService _dataService;
        private readonly ProductRepository _productRepository;
        private readonly SupplierRepository _supplierRepository;
        public ProductController(ILogger<ProductController> logger, IDataService dataService, ProductRepository productRepository, SupplierRepository supplierRepository)
        {
            _logger = logger;
            _dataService = dataService;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _productRepository.GetAll();
            return Ok(allProducts);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
