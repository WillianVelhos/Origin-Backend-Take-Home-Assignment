using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class DependentsRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.Dependents > 0)
                lineInsurance.AddScore(1);
        }
    }
}