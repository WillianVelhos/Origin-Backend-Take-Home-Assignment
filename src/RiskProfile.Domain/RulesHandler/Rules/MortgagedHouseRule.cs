using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class MortgagedHouseRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.House?.OwnershipStatus == OwnershipStatus.Mortgaged)
                lineInsurance.AddScore(1);
        }
    }
}