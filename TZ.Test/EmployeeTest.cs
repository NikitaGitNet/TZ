using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Enum;
using TZ.Interfaces;
using TZ.Models;

namespace TZ.Test
{
    [TestFixture()]
    public class EmployeeTest
    {
        IEnumerable<ISkill> MainSkills;
        IDictionary<ISkill, double> RatingPerSkill;
        double MainRating;
        int Age;

        [SetUp]
        public void Setup()
        {
            Age = 0;
            MainSkills = new ISkill[]
                    {
                        new Skill(TypeSkill.AngularJS, 6),
                        new Skill(TypeSkill.CSS, 5),
                        new Skill(TypeSkill.JavaScript, 5),
                        new Skill(TypeSkill.HTML, 5),
                        new Skill(TypeSkill.SASS, 4),
                        new Skill(TypeSkill.Ajax, 4),
                    };
            RatingPerSkill = new Dictionary<ISkill, double>();
        }
        private void CompatibilityRating(IEnumerable<ISkill> skills)
        {
            foreach (var skill in skills)
            {
                ISkill? currentUserSkill = MainSkills.FirstOrDefault(x => x.TypeSkill == skill.TypeSkill);
                if (currentUserSkill != null)
                {
                    RatingPerSkill.Add(currentUserSkill, (int)Math.Round((double)currentUserSkill.Age / (double)skill.Age * 100));
                }
                else
                {
                    ISkill newUserSkill = new Skill(skill.TypeSkill, 0);
                    RatingPerSkill.Add(newUserSkill, 0);
                }
            }
            if (RatingPerSkill.Any())
            {
                foreach (var item in RatingPerSkill)
                {
                    MainRating += item.Value;
                }
            }
        }
        [Test]
        public void TestRatingPerSkill()
        {
            ISkill[] skills = new ISkill[]
                    {
                         new Skill(TypeSkill.ReactJS, Age),
                         new Skill(TypeSkill.CSS, Age),
                         new Skill(TypeSkill.JavaScript, Age),
                         new Skill(TypeSkill.HTML, Age),
                         new Skill(TypeSkill.SASS, Age),
                    };
            CompatibilityRating(skills);
            if (RatingPerSkill.Any() && MainRating != 0)
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
