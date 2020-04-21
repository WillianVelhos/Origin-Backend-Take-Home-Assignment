using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler
{
    public interface IRule
    {
        void CalculateRiskScore(Customer customer, LineInsurance lineInsurance);
    }
}