using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Enum;
using TZ.Models;

namespace TZ.Interfaces
{
    /// <summary>
    /// Сотрудник/Кандидат в сотрудники компании, за раз сотрудник может работать только над одним проектом
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Имя
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// Отчество
        /// </summary>
        string MiddleName { get; }
        /// <summary>
        /// Хард скиллы
        /// </summary>
        IEnumerable<ISkill> MainSkills { get; }
        /// <summary>
        /// Софт скиллы
        /// </summary>
        IEnumerable<ISkill> OtherSkills { get; }
        /// <summary>
        /// Подробный рейтинг для каждого навыка
        /// </summary>
        IDictionary<ISkill, double> RatingPerSkill { get; }
        /// <summary>
        /// Стоимость услуг сотрудника (зарпалата)
        /// </summary>
        double Cost { get; }
        /// <summary>
        /// Рейтинг по хард скиллам
        /// </summary>
        double MainRating { get; }
        /// <summary>
        /// Рейтинг по софт скиллам
        /// </summary>
        double OtherRating { get; }
        /// <summary>
        /// Общий рейтинг сотрудника
        /// </summary>
        double CommonRating { get; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        EmployeeType EmployeeType { get;}
        /// <summary>
        /// Метод подсчета рейтинга совместимости навыков сотрудника с требованиями к должности
        /// Передаем список требуемых навыков
        /// </summary>
        /// <param name="skills"></param>
        void CompatibilityRating(IEnumerable<ISkill> skills);
    }
}
