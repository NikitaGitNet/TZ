using System.Collections;
using System.Collections.Generic;
using TZ.Enum;
using TZ.Interfaces;

namespace TZ.Models
{
    /// <summary>
    /// Продукт который разрабатывает/реализует компания, на каждом направлении их может быть несколько
    /// </summary>
    public class Product : IProduct
    {
        public Product(string name, IEnumerable<IEmployee> employees, ProductType productType)
        {
            Name = name;
            Employees = employees;
            CreateSkillsStaffForCurrentProduct(productType);
        }
        /// <summary>
        /// Список сотрудников занимающихся текущим проектом
        /// </summary>
        public IEnumerable<IEmployee> Employees { get; set; }
        /// <summary>
        /// Стек технологий текущего проекта
        /// </summary>
        public IDictionary<ISkill, EmployeeType> Skills { get; private set; } = null!;
        public IEnumerable<EmployeeType> Staff { get; set; } = null!;
        /// <summary>
        /// Бюджет проекта
        /// </summary>
        public double Budget { get; private set; }
        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Ориентировочный опыт работы с каждой технологией, которой должны владеть сотрудники на проекте
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// Зарплата сотрудников на проекте
        /// </summary>
        public int MiddlePrise { get; private set; }
        /// <summary>
        /// Тип проекта: маленький, средний, большой
        /// </summary>
        public ProductType ProductType { get; }
        /// <summary>
        /// Передаем тип проекта, на основании этого получаем стек технологий необходимый для его реализации и типы сотрудников, которые требуются на проект
        /// </summary>
        /// <param name="productType"></param>
        private void CreateSkillsStaffForCurrentProduct(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Small:
                    {
                        break;
                    }
                case ProductType.Medium:
                    {
                        Age = 12;
                        // В рамках этого примера не будем брать тимлида как отдельного работника. Предположим что он у нас уже есть в качестве еденицы не привязанной к отдельному проекту
                        Staff = new EmployeeType[] 
                        {
                            EmployeeType.FrontEndDeveloper,
                            EmployeeType.BackEndDeveloper,
                            EmployeeType.MobileDeveloper,
                            EmployeeType.Designer,
                            EmployeeType.Devops,
                            EmployeeType.QAEngineer
                        };
                        Skills = new Dictionary<ISkill, EmployeeType> 
                        {
                            { new Skill(TypeSkill.ReactJS, Age), EmployeeType.FrontEndDeveloper}, 
                            { new Skill(TypeSkill.CSS, Age),  EmployeeType.FrontEndDeveloper},
                            { new Skill(TypeSkill.JavaScript, Age), EmployeeType.FrontEndDeveloper },
                            { new Skill(TypeSkill.HTML, Age), EmployeeType.FrontEndDeveloper }, 
                            { new Skill(TypeSkill.SASS, Age), EmployeeType.FrontEndDeveloper }, // Фронт

                            { new Skill(TypeSkill._Net, Age), EmployeeType.BackEndDeveloper },
                            { new Skill(TypeSkill.MSSQL, Age), EmployeeType.BackEndDeveloper },
                            { new Skill(TypeSkill.EntityFramework, Age), EmployeeType.BackEndDeveloper },
                            { new Skill(TypeSkill.ASPNetCore, Age), EmployeeType.BackEndDeveloper },
                            { new Skill(TypeSkill.WebAPI, Age), EmployeeType.BackEndDeveloper }, // Бэк

                            { new Skill(TypeSkill.Flutter, Age), EmployeeType.MobileDeveloper },
                            { new Skill(TypeSkill.Dart, Age), EmployeeType.MobileDeveloper }, // Мобилка

                            { new Skill(TypeSkill.Figma, Age), EmployeeType.Designer },
                            { new Skill(TypeSkill.Photoshop, Age), EmployeeType.Designer },
                            { new Skill(TypeSkill.Bootstrap, Age), EmployeeType.Designer },
                            { new Skill(TypeSkill.CorelDrow, Age), EmployeeType.Designer }, // Дизайн

                            { new Skill(TypeSkill.Docker, Age), EmployeeType.Devops},
                            { new Skill(TypeSkill.Linux, Age), EmployeeType.Devops},
                            { new Skill(TypeSkill.Kubernetes, Age), EmployeeType.Devops },
                            { new Skill(TypeSkill.Python, Age), EmployeeType.Devops }, // Девопс

                            { new Skill(TypeSkill.Appium, Age), EmployeeType.QAEngineer },
                            { new Skill(TypeSkill.Selenium, Age), EmployeeType.QAEngineer },
                            { new Skill(TypeSkill.JUnit, Age), EmployeeType.QAEngineer },
                            { new Skill(TypeSkill.TestNG, Age), EmployeeType.QAEngineer } // Тестер
                        };
                        break;
                    }
                case ProductType.Big:
                    {
                        break;
                    }
            }
        }
        /// <summary>
        /// Метод подсчета ориентировочного бюджета проекта
        /// </summary>
        /// <param name="productType"></param>
        private void SetBudgetForProduct(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Small:
                    {
                        break;
                    }
                case ProductType.Medium:
                    {
                        MiddlePrise = 150000;
                        // Высчитываем ориентировочный бюджет проекта исходя из следующей формулы:
                        // Кол-во людей привязанных к проекту * 12 месяцев(ориентировочный цикл разработки) * 150000(Ориентировочный ценник 1 сотрудника в месяц)
                        Budget = Staff.Count() * 12 * MiddlePrise ;
                        break;
                    }
                case ProductType.Big:
                    {
                        break;
                    }
            }
        }
        /// <summary>
        /// Метод для получения навыков которыми должены владеть сотрудники, которых не хватает на проекте
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISkill> FilterOutSkills()
        {
            // Навыки владельцев которых мы еще не нашли
            IEnumerable<ISkill> skillsLack = new ISkill[0];
            // Типы сотрудников, которые у нас уже есть
            EmployeeType[] employeeTypesOur = new EmployeeType[0];
            if (Employees.Any())
            {
                employeeTypesOur = Employees.Select(x => x.EmployeeType).ToArray();
            }
            // Все навыки проекта
            if (Skills.Any())
            {
                // Типы всех сотрудников на проекте
                EmployeeType[] employeeTypesNeed = Skills.Values.ToArray();
                // Тип сотрудников которых нам не хватает
                EmployeeType[] employeeTypesLack = employeeTypesNeed.Except(employeeTypesOur).Distinct().ToArray();
                skillsLack = Skills.Where(x => employeeTypesLack.Contains(x.Value)).Select(x => x.Key);
            }
            return skillsLack;
        }
    }
}
