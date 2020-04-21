using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class LifeLineInsuranceMarriedRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.MaritalStatus == MaritalStatus.Married)
                lineInsurance.AddScore(1);
        }
    }
}