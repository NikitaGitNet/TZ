using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Interfaces
{
    /// <summary>
    /// Направление на котором компания предостовляет свои услуги
    /// </summary>
    public interface IDirection
    {
        /// <summary>
        /// Наименование направления
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Список клиентов с которыми ведется работа на данном направлении
        /// </summary>
        IEnumerable<IClient> Clients { get; }
    }
}
