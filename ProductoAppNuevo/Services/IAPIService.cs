using ProductoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Services
{
    internal interface IAPIService
    {
        public Task<List<Plato>> GetProductos();

        public Task<Plato> GetProducto(int id);
        public Task<Plato> PostProducto(Plato producto);
        public Task<Plato> PutProducto(int IdProducto, Plato producto);
        public Task<Boolean> DeleteProducto(int IdProducto);
    }
}
