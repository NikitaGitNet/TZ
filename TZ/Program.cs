using TZ.BusinessLogic;
using TZ.Interfaces;

// Получаем данные о нашей компании
ICompany ourCompany = LogicForProgram.InitialData();
IDirection? direction = ourCompany.Directions.FirstOrDefault();
if (direction != null)
{
    IClient? client = direction.Clients.FirstOrDefault();
    if (client != null)
    {
        IProduct? product = client.Products.FirstOrDefault();
        if (product != null)
        {
            IEnumerable<ISkill> skills = product.FilterOutSkills();
            // Получаем кандидатов 
            IEnumerable<IEmployee> candidates = LogicForProgram.CreateCandidates();
            // Выводим информацию о них на экран
            LogicForHR.CheckCandidatesForCompatibility(candidates, skills);
        }
        
    }
}

