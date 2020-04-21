using RiskProfile.Domain.Models;
using System.Linq;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class HouseRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.House == null)
                lineInsurance.Ineligible();
        }
    }
}