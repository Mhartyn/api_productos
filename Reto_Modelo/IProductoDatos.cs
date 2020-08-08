using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reto_Modelo
{
	public interface IProductoDatos
	{
		Task<string> Guardar(Producto item);

		IEnumerable<Producto> Listado(double inicio, double fin);

		Task<Producto> Obtener(string id);
	}
}
