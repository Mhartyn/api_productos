using System;

namespace Reto_Modelo
{
    public class Producto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public double SalesPrice {
            get {
                return Price * 1.18;
            }
        }

        public Producto()
        {
            Id = GeneraId();
        }

        public Producto(string name, string type, double price)
        {
            Id = GeneraId();
            Name = name;
            Type = type;
            Price = price;
        }

        private string GeneraId()
        {
            var idTemp = string.Empty;
            var idTotal = 0;

            for (int i = 0; i < 4; i++)
            {
                var valor = new Random().Next(0, 9);
                idTemp += valor.ToString();
                idTotal += valor;
                System.Diagnostics.Debug.WriteLine(valor);
            }

            while (idTotal > 9)
            {
                var totalTemp = 0;
                for (int i = 0; i < 2; i++)
                {
                    totalTemp += Convert.ToInt32(idTotal.ToString()[i].ToString());
                }
                idTotal = totalTemp;
            }

            return string.Format("{0}{1}", idTemp, idTotal);
        }
    }

}
