using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _repository;

		public ProductsController(IProductRepository repository) {
			_repository = repository;
		}

		[HttpGet]
		public async Task<ActionResult<Product[]>> GetProducts() {
			var products = await _repository.GetProductsAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id) {
			var product = await _repository.GetProductByIdAsync(id);
			return Ok(product);
		}

		[HttpGet("brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands() {
			var brands = await _repository.GetProductBrandsAsync();
			return Ok(brands);
		} 

		//[HttpGet("brands/{id}")]
		//public async Task<ActionResult<ProductBrand>> GetType(int id) {
		//	var brand = await _repository.GetProductBrandByIdAsync(id);
		//	return Ok(brand);
		//} 

		[HttpGet("types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes() {
			var types = await _repository.GetProductTypesAsync();
			return Ok(types);
		} 

		//[HttpGet("types/{id}")]
		//public async Task<ActionResult<ProductType>> GetBrand(int id) {
		//	var type = await _repository.GetProductTypeByIdAsync(id);
		//	return Ok(type);
		//} 
	}
}