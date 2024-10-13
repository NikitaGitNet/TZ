using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Interfaces
{
    /// <summary>
    /// Компания
    /// В данном случае наша
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// Направления на которые компания предостовляет свои услуги
        /// </summary>
        IEnumerable<IDirection> Directions { get; }
        /// <summary>
        /// Название компании
        /// </summary>
        string Name { get; }
    }
}
