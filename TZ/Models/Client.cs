using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Interfaces;

namespace TZ.Models
{
    /// <summary>
    /// Клиент компании
    /// </summary>
    internal class Client : IClient
    {
        public Client(string name, IEnumerable<IProduct> products)
        {
            Products = products;
            Name = name;
        }
        /// <summary>
        /// Список продуктов, которые компания предостовляет клиенту
        /// </summary>
        public IEnumerable<IProduct> Products { get; }
        /// <summary>
        /// Наименование клиента
        /// </summary>
        public string Name { get; }
    }
}
