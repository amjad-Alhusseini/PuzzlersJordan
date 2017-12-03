using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzlersJordan.Interfaces;
using PuzzlersJordan.Models;
using System.Net.Http;
using PuzzlersJordan.Helpers;
using Newtonsoft.Json;

namespace PuzzlersJordan.Services
{
    public class ProductService : IProductService
    {

        public ProductService()
        {
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
