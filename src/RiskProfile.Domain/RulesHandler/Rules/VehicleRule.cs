using RiskProfile.Domain.Models;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class VehicleRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.Vehicle == null)
                lineInsurance.Ineligible();
        }
    }
}