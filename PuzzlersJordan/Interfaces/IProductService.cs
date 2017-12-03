using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzlersJordan.Models;

namespace PuzzlersJordan.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
