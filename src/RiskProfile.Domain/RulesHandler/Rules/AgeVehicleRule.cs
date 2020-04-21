using RiskProfile.Domain.Models;
using System;

namespace RiskProfile.Domain.RulesHandler.Rules
{
    public class AgeVehicleRule : IRule
    {
        public void CalculateRiskScore(Customer customer, LineInsurance lineInsurance)
        {
            if (customer.Vehicle?.Year >= (DateTime.Now.Year - 5))
                lineInsurance.AddScore(1);
        }
    }
}