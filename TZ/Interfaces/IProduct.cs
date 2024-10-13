using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Enum;

namespace TZ.Interfaces
{
    /// <summary>
    /// Продук который разрабатывает/реализует компания, на каждом направлении их может быть несколько
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Список сотрудников занимающихся текущим проектом
        /// </summary>
        IEnumerable<IEmployee> Employees { get; }
        /// <summary>
        /// Стек технологий текущего проекта
        /// </summary>
        IDictionary<ISkill, EmployeeType> Skills {get;}
        /// <summary>
        /// Штат сотрудников на проект
        /// </summary>
        IEnumerable<EmployeeType> Staff { get; }
        /// <summary>
        /// Бюджет проекта
        /// </summary>
        double Budget { get; }
        /// <summary>
        /// Название проекта
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Ориентировочный опыт работы с каждой технологией, которой должны владеть сотрудники на проекте
        /// </summary>
        public int Age { get; }
        /// <summary>
        /// Зарплата сотрудников на проекте
        /// </summary>
        public int MiddlePrise { get; }
        ProductType ProductType { get; }
        /// <summary>
        /// Метод для получения навыков которыми должены владеть сотрудники, которых не хватает на проекте
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISkill> FilterOutSkills();
    }
}
