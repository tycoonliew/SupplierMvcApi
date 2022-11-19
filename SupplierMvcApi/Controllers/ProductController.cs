using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplierMvcApi.DataServices;
using SupplierMvcApi.Models;
using SupplierMvcApi.Repositories;
using SupplierMvcApi.Repository;
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
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _productRepository.GetAll();
            return Ok(allProducts);
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductModel product)
        {
            Console.WriteLine(product);
            await _productRepository.Create(product);
            return Created("products", product);
        }

        [HttpGet("suppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var allSuppliers = await _supplierRepository.GetAll();
            return Ok(allSuppliers);
        }

        [HttpPost("suppliers")]
        public async Task<IActionResult> AddNewSupplier([FromBody] SupplierModel supplier)
        {
            await _supplierRepository.Create(supplier);
            return Created("supplier", supplier);
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
