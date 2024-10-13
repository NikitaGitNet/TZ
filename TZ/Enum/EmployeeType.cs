using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Enum
{
    /// <summary>
    /// Тип сотрудника
    /// Рамках данного проекта должностей думаю хватит 
    /// </summary>
    public enum EmployeeType
    {
        BackEndDeveloper, // Бэкендер
        FrontEndDeveloper, // Фронтендер
        MobileDeveloper, // Чел который делает мобилку
        FullStack, // Фронт + Бэк
        Designer, // Дизайнер
        QAEngineer, // Тестировшик
        Analyst, // Аналитик, он же ПМ
        TeamLeader, // Руководитель отдела разработки
        Architect, // Архитектор, он же тех лид
        Devops // Девопс
    }
}
