using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reto_Modelo;
using System;

namespace Reto_Datos
{
	public class Contexto : DbContext
	{
		private readonly ILogger<Contexto> _logger;
		public Contexto(ILogger<Contexto> logger, DbContextOptions<Contexto> options)
			: base(options)
		{
			try
			{
				_logger = logger;
				Database.EnsureCreated();			
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}
		}

		public virtual DbSet<Producto> Producto { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			if (modelBuilder == null)
				throw new ArgumentException("Recursos.ParametroNull");

		}
	}

}
