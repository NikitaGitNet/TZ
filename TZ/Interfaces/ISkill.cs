using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Enum;

namespace TZ.Interfaces
{
    /// <summary>
    /// Навык
    /// Для упрощения дальнейших подсчетов возьмем за основу, что:
    /// - Каждый сотрудник должен владеть 5 ключевыми навыками
    /// - Для освоения навыка на +- адекватном уровне у сотрудника должнобыть за плечами хотя бы 1000 часов опыта работы с этим навыком
    /// </summary>
    public interface ISkill
    {
        /// <summary>
        /// Наименование навыка
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Кол-во владения навыком в месяцах
        /// </summary>
        public int Age { get;}
        /// <summary>
        /// Тип навыка
        /// </summary>
        public TypeSkill TypeSkill { get;}
    }
}
