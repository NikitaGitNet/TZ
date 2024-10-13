using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Enum;
using TZ.Interfaces;

namespace TZ.Models
{
    /// <summary>
    /// Сотрудник/Кандидат в сотрудники компании, за раз сотрудник может работать только над одним проектом
    /// </summary>
    public class Employee : IEmployee
    {
        public Employee(string lastName, string firstName, string middleName, EmployeeType employeeType, IEnumerable<ISkill> mainSkills, IEnumerable<ISkill> otherSkills)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            EmployeeType = employeeType;
            MainSkills = mainSkills;
            OtherSkills = otherSkills;
            RatingPerSkill = new Dictionary<ISkill, double>();
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get;}
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; }
        /// <summary>
        /// Хард скиллы
        /// </summary>
        public IEnumerable<ISkill> MainSkills { get; set; }
        /// <summary>
        /// Софт скиллы
        /// </summary>
        public IEnumerable<ISkill> OtherSkills { get; set; }
        /// <summary>
        /// Подробный рейтинг для каждого навыка
        /// </summary>
        public IDictionary<ISkill, double> RatingPerSkill { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Рейтинг по хард скиллам
        /// </summary>
        public double MainRating { get; set; }
        /// <summary>
        /// Рейтинг по софт скиллам
        /// </summary>
        public double OtherRating { get; set; }
        /// <summary>
        /// Общий рейтинг сотрудника
        /// </summary>
        public double CommonRating { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public EmployeeType EmployeeType { get; }
        /// <summary>
        /// Метод подсчета рейтинга совместимости навыков сотрудника с требованиями к должности
        /// Передаем список требуемых навыков
        /// </summary>
        /// <param name="skills"></param>
        public void CompatibilityRating(IEnumerable<ISkill> skills)
        {
            // Проходим по требуемым навыкам
            foreach (var skill in skills)
            {
                // Если сотрудник имеет такой навык
                ISkill? currentUserSkill = MainSkills.FirstOrDefault(x => x.TypeSkill == skill.TypeSkill);
                if (currentUserSkill != null)
                {
                    // Считаем рейтинг по формуле: опыт работы сотрудника / на требуемый опыт работы * 100
                    // Получаем балл совместимости
                    RatingPerSkill.Add(currentUserSkill, (int)Math.Round((double)currentUserSkill.Age / (double)skill.Age * 100));
                }
                else
                {
                    // Если сотрудник не имеет навыка, создаем ему навык, ставим 0 баллов
                    ISkill newUserSkill = new Skill(skill.TypeSkill, 0);
                    RatingPerSkill.Add(newUserSkill, 0);
                }
            }
            // Считаем общее кол-во баллов
            if (RatingPerSkill.Any())
            {
                foreach (var item in RatingPerSkill)
                {
                    MainRating += item.Value;
                }
            }
        }
    }
}
