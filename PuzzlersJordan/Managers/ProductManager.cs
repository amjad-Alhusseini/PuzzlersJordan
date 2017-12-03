using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzlersJordan.Interfaces;
using PuzzlersJordan.Models;

namespace PuzzlersJordan.Managers
{
    public class ProductManager
    {
        readonly IProductService productService;
        public ProductManager(IProductService productService)
        {
            this.productService = productService;
        }

        internal Task<IEnumerable<Product>> GetProducts() => productService.GetProductsAsync();
    }
}
