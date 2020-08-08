using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reto_Api.Models;
using Reto_Modelo;

namespace Reto_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase
	{
        private readonly IProductoDatos _productoDatos;

        public ProductoController(IProductoDatos productoDatos)
		{
            _productoDatos = productoDatos;
		}

        [HttpGet("get/{id}")]
        public async Task<ProductoVm> GetProducto(string id)
        {
            var producto = await _productoDatos.Obtener(id);
			if (producto == null)
			{
                producto = new Producto();
			}
            return new ProductoVm { Id = producto.Id, Name = producto.Name, Price = producto.Price, Type = producto.Type };
        }

        [HttpGet("rango/{inicio}/{fin}")]
        public IEnumerable<ProductoVm> GetRango(double inicio, double fin)
        {
            var lista = _productoDatos.Listado(inicio, fin).Select(x=> new ProductoVm { 
                Id= x.Id,
                Name = x.Name,
                Price = x.Price,
                Type = x.Type,
                SalesPrice = x.SalesPrice
            });
            return lista;
        }

        [HttpPost("registro")]
        public async Task<string> Registro([FromBody] ProductoVm productoVm)
        {            
            return await _productoDatos.Guardar(new Producto { Name = productoVm.Name, Price = productoVm.Price, Type = productoVm.Type });
        }


    }
}
