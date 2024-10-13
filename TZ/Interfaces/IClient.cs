using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Interfaces
{
    /// <summary>
    /// Клиент компании
    /// </summary>
    public interface IClient
    {
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
