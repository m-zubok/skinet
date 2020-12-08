using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class StoreContextSeed
	{
		public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory) {
			try {
				if (!context.ProductBrands.Any()) {
					var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
					var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
					foreach (var item in brands) {
						context.ProductBrands.Add(item);
					}

					await context.SaveChangesAsync();
				}

				if (!context.ProductTypes.Any()) {
					var productTypes = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
					var types = JsonSerializer.Deserialize<List<ProductType>>(productTypes);
					foreach (var item in types) {
						context.ProductTypes.Add(item);
					}

					await context.SaveChangesAsync();
				}

				if (!context.Products.Any()) {
					var products = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
					var types = JsonSerializer.Deserialize<List<Product>>(products);
					foreach (var item in types) {
						context.Products.Add(item);
					}

					await context.SaveChangesAsync();
				}
			} catch (Exception ex) {
				loggerFactory.CreateLogger<StoreContextSeed>().LogError(ex, "Error seed data");
			}
		}
	}
}
