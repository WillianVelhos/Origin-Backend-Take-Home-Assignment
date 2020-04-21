using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;
using RiskProfile.Domain.RulesHandler.Rules;

namespace RiskProfile.Domain.Services
{
    public class LifeInsuranceService
    {
        public LineInsurance CreateLineInsurance(Customer customer)
        {
            var life = new LineInsurance(LineInsuranceName.Life, customer.RiskQuestions);

            CalculateScore(customer, life);

            return life;
        }

        private void CalculateScore(Customer customer, LineInsurance lineInsurance)
        {
            RulesHandler.RulesHandler.New.For(customer, lineInsurance)
                                         .Add(new HighAgeRule())
                                         .Add(new AgeRule())
                                         .Add(new HighIncomeRule())
                                         .Add(new DependentsRule())
                                         .Add(new LifeLineInsuranceMarriedRule())
                                         .Calculate();

        }
    }
}