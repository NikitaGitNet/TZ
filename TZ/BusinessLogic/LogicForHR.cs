using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Interfaces;

namespace TZ.BusinessLogic
{
    /// <summary>
    /// Иммитируем логику сервиса с помощью которого HR будет перебирать кандидатов
    /// </summary>
    public static class LogicForHR
    {
        /// <summary>
        /// Метод выводящий информацию о кандидатах на экран
        /// Перебираем всех, под конец выводим лучших
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="skills"></param>
        public static void CheckCandidatesForCompatibility(IEnumerable<IEmployee> candidates, IEnumerable<ISkill> skills)
        {
            // Перебираем всех кандидатов, выполняем логику по подсчету их рейтига совместимости
            foreach (IEmployee candidat in candidates)
            {
                candidat.CompatibilityRating(skills);
            }
            // Сортируем от лучших к худшим
            candidates = candidates.OrderByDescending(x => x.MainRating);
            // Выводим всех на экран
            foreach (IEmployee candidat in candidates)
            {
                Console.WriteLine($"{candidat.LastName} {candidat.FirstName} {candidat.MiddleName}");
                Console.WriteLine($"Общий рейтинг совместимости: {candidat.MainRating} баллов");
                Console.WriteLine();
                Console.WriteLine("Подробный рейтинг по каждому навыку");
                foreach (var skill in candidat.RatingPerSkill)
                {
                    Console.WriteLine($"{skill.Key.ToString()} {skill.Value} баллов");
                }
                Console.WriteLine("--------------------------------------------------");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Чтоб увидеть наиболее подходящих кандидатов нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            // Получаем наивысший рейтинг совместимости
            double topRating = candidates.MaxBy(x => x.MainRating)!.MainRating;
            // Получаем кандидатов, которые имеют этот самый рейтинг
            IEnumerable<IEmployee> employees = candidates.Where(x => x.MainRating == topRating);
            // Выводим их на экран
            Console.WriteLine("Лучшие:");
            foreach (IEmployee candidat in employees)
            {
                Console.WriteLine($"{candidat.LastName} {candidat.FirstName} {candidat.MiddleName} {candidat.MainRating} баллов");
                Console.WriteLine("--------------------------------------------------");
                Thread.Sleep(1000);
            }
        }
    }
}
