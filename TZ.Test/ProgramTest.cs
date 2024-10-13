using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.BusinessLogic;
using TZ.Enum;
using TZ.Interfaces;
using TZ.Models;

namespace TZ.Test
{
    [TestFixture()]
    public class ProgramTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Требуемый опыт работы
            int age = 12;
            // Инициализи
            IEnumerable<IEmployee> employeesss = LogicForProgram.CreateCandidates();
            IEnumerable<ISkill> skills = new ISkill[] 
            {
                new Skill(TypeSkill.ReactJS, age), 
                new Skill(TypeSkill.CSS, age), 
                new Skill(TypeSkill.JavaScript, age), 
                new Skill(TypeSkill.HTML, age),
                new Skill(TypeSkill.SASS, age)
            };
            if (employeesss.Any())
            {
                foreach (var item in employeesss)
                {
                    item.CompatibilityRating(skills);
                }
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}
