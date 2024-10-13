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
    /// Навык
    /// Для упрощения дальнейших подсчетов возьмем за основу, что:
    /// - Каждый сотрудник должен владеть 5 ключевыми навыками
    /// - Для освоения навыка на +- адекватном уровне у сотрудника должнобыть за плечами хотя бы 1000 часов опыта работы с этим навыком
    /// </summary>
    public class Skill : ISkill
    {
        public Skill(TypeSkill typeSkill, int age)
        {
            TypeSkill = typeSkill;
            Age = age;
            Name = SetNameForSkill(typeSkill);
        }
        /// <summary>
        /// Наименование навыка
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Кол-во владения навыком в месяцах
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Тип навыка
        /// </summary>
        public TypeSkill TypeSkill { get;}
        private string SetNameForSkill(TypeSkill typeSkill)
        {
            string name = "";
            switch (typeSkill)
            {
                case TypeSkill.JavaScript:
                    {
                        name = "JavaScript";
                        break;
                    }
                case TypeSkill.TypeScript:
                    {
                        name = "TypeScript";
                        break;
                    }
                case TypeSkill.ReactJS:
                    {
                        name = "ReactJS";
                        break;
                    }
                case TypeSkill.AngularJS:
                    {
                        name = "AngularJS";
                        break;
                    }
                case TypeSkill.HTML:
                    {
                        name = "HTML";
                        break;
                    }
                case TypeSkill.CSS:
                    {
                        name = "CSS";
                        break;
                    }
                case TypeSkill.jQuery:
                    {
                        name = "jQuery";
                        break;
                    }
                case TypeSkill.Ajax:
                    {
                        name = "Ajax";
                        break;
                    }
                case TypeSkill.VueJs:
                    {
                        name = "VueJs";
                        break;
                    }
                case TypeSkill.RxJS:
                    {
                        name = "RxJS";
                        break;
                    }
                case TypeSkill.Cesium:
                    {
                        name = "Cesium";
                        break;
                    }
                case TypeSkill.WebpackModuleFederation:
                    {
                        name = "WebpackModuleFederation";
                        break;
                    }
                case TypeSkill.Blazor:
                    {
                        name = "Blazor";
                        break;
                    }
                case TypeSkill.RazorPages:
                    {
                        name = "RazorPages";
                        break;
                    }
                case TypeSkill.NextJs:
                    {
                        name = "NextJs";
                        break;
                    }
                case TypeSkill.SASS:
                    {
                        name = "SASS";
                        break;
                    }
                case TypeSkill._Net:
                    {
                        name = "_Net";
                        break;
                    }
                case TypeSkill.EntityFramework:
                    {
                        name = "EntityFramework";
                        break;
                    }
                case TypeSkill.MSSQL:
                    {
                        name = "MSSQL";
                        break;
                    }
                case TypeSkill.ASPNetCore:
                    {
                        name = "ASPNetCore";
                        break;
                    }
                case TypeSkill.WebAPI:
                    {
                        name = "WebAPI";
                        break;
                    }
                case TypeSkill.Flutter:
                    {
                        name = "Flutter";
                        break;
                    }
                case TypeSkill.Dart:
                    {
                        name = "Dart";
                        break;
                    }
                case TypeSkill.Linux:
                    {
                        name = "Linux";
                        break;
                    }
                case TypeSkill.Python:
                    {
                        name = "Python";
                        break;
                    }
                case TypeSkill.Docker:
                    {
                        name = "Docker";
                        break;
                    }
                case TypeSkill.Kubernetes:
                    {
                        name = "Kubernetes";
                        break;
                    }
                case TypeSkill.Photoshop:
                    {
                        name = "Photoshop";
                        break;
                    }
                case TypeSkill.Figma:
                    {
                        name = "Figma";
                        break;
                    }
                case TypeSkill.CorelDrow:
                    {
                        name = "CorelDrow";
                        break;
                    }
                case TypeSkill.Bootstrap:
                    {
                        name = "Bootstrap";
                        break;
                    }
                case TypeSkill.Selenium:
                    {
                        name = "Selenium";
                        break;
                    }
                case TypeSkill.Appium:
                    {
                        name = "Appium";
                        break;
                    }
                case TypeSkill.JUnit:
                    {
                        name = "JUnit";
                        break;
                    }
                case TypeSkill.TestNG:
                    {
                        name = "TestNG";
                        break;
                    }
            }
            return name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
