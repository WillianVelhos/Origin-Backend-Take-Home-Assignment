using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class DisabilityLineInsuranceMarriedRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.MaritalStatus == MaritalStatus.Married)
                lineInsurance.DeductScore(1);
        }
    }
}