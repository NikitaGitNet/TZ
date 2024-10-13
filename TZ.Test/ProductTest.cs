using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.BusinessLogic;
using TZ.Enum;
using TZ.Interfaces;
using TZ.Models;
using static NUnit.Framework.Internal.OSPlatform;
using ProductType = TZ.Enum.ProductType;

namespace TZ.Test
{
    [TestFixture()]
    public class ProductTest
    {
        ProductType ProductType;
        int Age = 0;
        double Budget = 0;
        double MiddlePrise;
        IEnumerable<EmployeeType>? Staff;
        IDictionary<ISkill, EmployeeType>? Skills;
        [SetUp]
        public void Setup()
        {
            ProductType = ProductType.Medium;
        }
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
                        // Кол-во людей(6) привязанных к проекту * 12 месяцев(ориентировочный цикл разработки) * 150000(Ориентировочный ценник 1 сотрудника в месяц)
                        Budget = 6 * Age * MiddlePrise;
                        break;
                    }
                case ProductType.Big:
                    {
                        break;
                    }
            }
        }
        /// <summary>
        /// Передаем
        /// </summary>
        /// <param name="skills"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        private IEnumerable<ISkill> FilterOutSkills(IDictionary<ISkill, EmployeeType> skills, IEnumerable<IEmployee> employees)
        {
            IEnumerable<ISkill> skillsLack = new ISkill[0];
            EmployeeType[] employeeTypesOur = new EmployeeType[0];
            if (employees.Any())
            {
                // Тип сотрудников который у нас есть
                employeeTypesOur = employees.Select(x => x.EmployeeType).ToArray();
            }
            if (skills.Any())
            {
                // Тип сотрудников который нам нужен
                EmployeeType[] employeeTypesNeed = skills.Values.ToArray();
                // Тип сотрудников которых нам не хватает
                EmployeeType[] employeeTypesLack = employeeTypesNeed.Except(employeeTypesOur).Distinct().ToArray();
                skillsLack = skills.Where(x => employeeTypesLack.Contains(x.Value)).Select(x => x.Key);
            }
            return skillsLack;
        }
        [Test]
        public void TestSkillsAndStaffCompletion()
        {
            CreateSkillsStaffForCurrentProduct(ProductType.Medium);
            if (Skills != null && Skills.Any() && Staff != null && Staff.Any())
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void TestBudgetCompletion()
        {
            Age = 12;
            SetBudgetForProduct(ProductType.Medium);
            if (Budget != 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void TestFilterOutSkills()
        {
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
            IEnumerable<IEmployee> employees = LogicForProgram.CreateEmployees();
            IEnumerable<ISkill> skillsLack = FilterOutSkills(Skills, employees);
            if (skillsLack.Any())
            {
                Assert.Pass();
            }
            else 
            { 
                Assert.Fail();
            }
        }
    }
}
