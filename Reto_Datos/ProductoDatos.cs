using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reto_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_Datos
{
	public class ProductoDatos: IProductoDatos
	{
		private readonly ILogger<Contexto> _logger;
		private readonly Contexto _contexto;

		public ProductoDatos(Contexto context, ILogger<Contexto> logger)
		{
			_logger = logger;
			_contexto = context;
		}

		public async Task<string> Guardar(Producto item)
		{
			if (item == null)
				throw new ArgumentException("Recursos.ParametroNull");

			var db = await _contexto.Producto.FirstOrDefaultAsync(a => a.Id == item.Id).ConfigureAwait(true);
			if (db == null)
			{
				_contexto.Producto.AddAsync(item);
				await _contexto.SaveChangesAsync().ConfigureAwait(true);
			}
			else
			{
				_logger.LogWarning("Id ya existe: " + db.Id);
			}
			return item.Id;
		}

		public IEnumerable<Producto> Listado(double inicio, double fin)
		{
			var consulta = _contexto.Producto.AsQueryable();

			consulta = consulta.Where(x => x.Price >= inicio && x.Price <= fin);

			if (!consulta.Any())
			{
				_logger.LogWarning("No existen productos que cumplan la condicion");
			}
			return consulta;
		}

		public async Task<Producto> Obtener(string id)
		{
			var consulta = await _contexto.Producto.FirstOrDefaultAsync(x=> x.Id.Equals(id)).ConfigureAwait(true);
			if (consulta == null)
			{
				_logger.LogWarning("No existe Id de producto");
			}
			return consulta;
		}
	}
}
