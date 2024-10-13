using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Interfaces;

namespace TZ.Models
{
    /// <summary>
    /// Компания
    /// В данном случае наша
    /// </summary>
    public class Company : ICompany
    {
        public Company(string name, IEnumerable<IDirection> directions)
        {
            Directions = directions;
            Name = name;
        }
        /// <summary>
        /// Направления на которые компания предостовляет свои услуги
        /// </summary>
        public IEnumerable<IDirection> Directions { get; }
        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; }
    }
}
