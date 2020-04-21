using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class AgeRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.Age < 30)
                lineInsurance.DeductScore(2);
            else if (customer.Age > 30 && customer.Age < 40)
                lineInsurance.DeductScore(1);
        }
    }
}