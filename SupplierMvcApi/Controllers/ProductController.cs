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
using System.Reflection;
using System.Threading.Tasks;

namespace SupplierMvcApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        private List<ProductModel> _products = new();

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        [HttpGet("api/products", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _productRepository.GetAll();
            _products = allProducts.ToList();
            return Ok(allProducts);
        }

        [HttpPost("api/products")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductModel product)
        {
            Console.WriteLine(product);
            await _productRepository.Create(product);
            return CreatedAtRoute("GetAllProducts", routeValues: new { id = product.ProductName }, value: product);
        }

        [HttpGet("api/suppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var allSuppliers = await _supplierRepository.GetAll();
            return Ok(allSuppliers);
        }

        [HttpPost("api/suppliers")]
        public async Task<IActionResult> AddNewSupplier([FromBody] SupplierModel supplier)
        {
            await _supplierRepository.Create(supplier);
            return Created("supplier", supplier);
        }

        public async Task<IActionResult> GetProducts()
        {
            var test = await GetAllProducts();
            return View(_products);
        }

        public IActionResult CreateProducts()
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
