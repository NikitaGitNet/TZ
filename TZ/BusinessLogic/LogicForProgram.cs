using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Enum;
using TZ.Interfaces;
using TZ.Models;

namespace TZ.BusinessLogic
{
    /// <summary>
    /// Иммитация внешней деятельности
    /// Представим, что получаем эти данные из базы, либо другого сервиса
    /// </summary>
    public static class LogicForProgram
    {
        /// <summary>
        /// Инициализируем нашу компанию
        /// Для текущего примера активно одно направление, один клиент, один продукт
        /// Для продукт сформирован штат, кроме фронтендера, его то мы и будем искать
        /// </summary>
        /// <returns></returns>
        public static ICompany InitialData()
        {
            IEnumerable<IEmployee> employees = CreateEmployees();
            IEnumerable<IProduct> products = new IProduct[] {new Product("Редан", employees, ProductType.Medium) };
            IEnumerable<IClient> clients = new IClient[]{ new Client("ИП Евгений Викторович", products) };
            IEnumerable<IDirection> directions = new IDirection[] { new Direction("Внешний рынок", clients) };
            ICompany ourCompany = new Company("ИП Валера", directions);
            
            return ourCompany;
        }
        /// <summary>
        /// Предположим у нас уже есть сотрудники на проекте - все, кроме фронта
        /// У уже имеющихся сотрудников не нужно высчитывать рейтинг совместимости, их уже взяли, значит соответсвуют 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IEmployee> CreateEmployees()
        {
            IEnumerable<IEmployee> employees = new IEmployee[] 
            { 
                // Бэк
                new Employee("Букин", "Генадий", "Валентинович", EmployeeType.BackEndDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill._Net, 12),
                        new Skill(TypeSkill.MSSQL, 12),
                        new Skill(TypeSkill.EntityFramework, 12),
                        new Skill(TypeSkill.ASPNetCore, 12),
                        new Skill(TypeSkill.WebAPI, 12)
                    }, new ISkill[0]),
                // Мобилка
                new Employee("Невский", "Александр", "Александрович", EmployeeType.MobileDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill.Flutter, 12),
                        new Skill(TypeSkill.Dart, 12)
                    }, new ISkill[0]),
                // Дизайнер
                new Employee("Бурим", "Андрей", "Александрович", EmployeeType.Designer, new ISkill[]
                    {
                        new Skill(TypeSkill.Figma, 12),
                        new Skill(TypeSkill.Photoshop, 12),
                        new Skill(TypeSkill.Bootstrap, 12),
                        new Skill(TypeSkill.CorelDrow, 12)
                    }, new ISkill[0]),
                // Девопс
                new Employee("Закиров", "Нафис", "Отвисович", EmployeeType.Devops, new ISkill[]
                    {
                        new Skill(TypeSkill.Docker, 12),
                        new Skill(TypeSkill.Linux, 12),
                        new Skill(TypeSkill.Kubernetes, 12),
                        new Skill(TypeSkill.Python, 12)
                    }, new ISkill[0]),
                // Тестер
                new Employee("Габабасыстырханов", "Ркацефет", "Жежеевич", EmployeeType.QAEngineer, new ISkill[]
                    {
                        new Skill(TypeSkill.Appium, 12),
                        new Skill(TypeSkill.Selenium, 12),
                        new Skill(TypeSkill.JUnit, 12),
                        new Skill(TypeSkill.TestNG, 12)
                    }, new ISkill[0]),
            };
            return employees;
        }
        /// <summary>
        /// Инициализируем кандидатов на должность фронтендера
        /// Все они имеют стек технологий +- подходящий нашему проекту, разный опыт работы
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IEmployee> CreateCandidates()
        { 
            IEnumerable<IEmployee> employees = new IEmployee[]
            {
                new Employee("Лобанов", "Семен", "Константинович", EmployeeType.FrontEndDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill.AngularJS, 6),
                        new Skill(TypeSkill.CSS, 5),
                        new Skill(TypeSkill.JavaScript, 5),
                        new Skill(TypeSkill.HTML, 5),
                        new Skill(TypeSkill.SASS, 4),
                        new Skill(TypeSkill.Ajax, 4),
                    }, new ISkill[0]),
                new Employee("Романенко", "Глеб", "Викторович", EmployeeType.FrontEndDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill.Blazor, 7),
                        new Skill(TypeSkill.CSS, 13),
                        new Skill(TypeSkill.JavaScript, 12),
                        new Skill(TypeSkill.HTML, 13),
                        new Skill(TypeSkill.RazorPages, 13),
                        new Skill(TypeSkill.SASS, 13),
                    }, new ISkill[0]),
                new Employee("Левин", "Борис", "Аркадьевич", EmployeeType.FrontEndDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill.ReactJS, 15),
                        new Skill(TypeSkill.CSS, 15),
                        new Skill(TypeSkill.JavaScript, 15),
                        new Skill(TypeSkill.HTML, 15),
                        new Skill(TypeSkill.VueJs, 15),
                        new Skill(TypeSkill.jQuery, 15),
                        new Skill(TypeSkill.TypeScript, 15)
                    }, new ISkill[0]),
                new Employee("Быков", "Андрей", "Евгеньевич", EmployeeType.FrontEndDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill.ReactJS, 12),
                        new Skill(TypeSkill.CSS, 12),
                        new Skill(TypeSkill.JavaScript, 12),
                        new Skill(TypeSkill.HTML, 12),
                        new Skill(TypeSkill.SASS, 12),
                        new Skill(TypeSkill.TypeScript, 12),
                    }, new ISkill[0]),
                new Employee("Ричардс", "Фил", "Джон-Бенджеминович", EmployeeType.FrontEndDeveloper, new ISkill[]
                    {
                        new Skill(TypeSkill.RazorPages, 12),
                        new Skill(TypeSkill.CSS, 12),
                        new Skill(TypeSkill.JavaScript, 5),
                        new Skill(TypeSkill.HTML, 12),
                        new Skill(TypeSkill.Ajax, 12),
                        new Skill(TypeSkill.SASS, 12),
                    }, new ISkill[0]),
            };
            return employees;
        }
    }
    
}
