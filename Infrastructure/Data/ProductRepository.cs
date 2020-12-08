﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoreContext _context;

		public ProductRepository(StoreContext context) {
			_context = context;
		}

		public async Task<ProductBrand> GetProductBrandByIdAsync(int id) {
			return await _context.ProductBrands.FindAsync(id);
		}

		public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync() {
			return await _context.ProductBrands.ToListAsync();
		}

		public async Task<Product> GetProductByIdAsync(int id) {
			return await _context.Products
				.Include(b => b.ProductBrand)
				.Include(t => t.ProductType)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IReadOnlyList<Product>> GetProductsAsync() {
			return await _context.Products
				.Include(b => b.ProductBrand)
				.Include(t => t.ProductType)
				.ToListAsync();
		}

		public async Task<ProductType> GetProductTypeByIdAsync(int id) {
			return await _context.ProductTypes.FindAsync(id);
		}

		public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync() {
			return await _context.ProductTypes.ToListAsync();
		}
	}
}
