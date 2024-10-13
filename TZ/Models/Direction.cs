using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Interfaces;

namespace TZ.Models
{
    /// <summary>
    /// Направление на котором компания предостовляет свои услуги
    /// </summary>
    public class Direction : IDirection
    {
        public Direction(string name, IEnumerable<IClient> clients)
        {
            Name = name;
            Clients = clients;
        }
        /// <summary>
        /// Наименование направления
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Список клиентов с которыми ведется работа на данном направлении
        /// </summary>
        public IEnumerable<IClient> Clients { get; }
    }
}
