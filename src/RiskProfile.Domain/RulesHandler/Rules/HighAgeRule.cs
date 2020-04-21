using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class HighAgeRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.Age > 60)
                lineInsurance.Ineligible();
        }
    }
}