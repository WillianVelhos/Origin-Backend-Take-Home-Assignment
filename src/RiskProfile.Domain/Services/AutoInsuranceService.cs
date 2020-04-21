using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;
using RiskProfile.Domain.RulesHandler.Rules;

namespace RiskProfile.Domain.Services
{
    public class AutoInsuranceService
    {
        public LineInsurance CreateLineInsurance(Customer customer)
        {
            var life = new LineInsurance(LineInsuranceName.Auto, customer.RiskQuestions);

            CalculateScore(customer, life);

            return life;
        }

        private void CalculateScore(Customer customer, LineInsurance lineInsurance)
        {
            RulesHandler.RulesHandler.New.For(customer, lineInsurance)
                                         .Add(new IncomeRule())
                                         .Add(new VehicleRule())
                                         .Add(new HouseRule())
                                         .Add(new AgeRule())
                                         .Add(new HighIncomeRule())
                                         .Add(new AgeVehicleRule())
                                         .Calculate();
        }
    }
}