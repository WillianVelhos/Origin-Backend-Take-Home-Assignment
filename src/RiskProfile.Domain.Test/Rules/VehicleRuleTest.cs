using RiskProfile.Domain.Models;
using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class VehicleRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeIneligibleCustomerEqualsNullHouse()
        {
            //arrange
            var rule = new VehicleRule();
            var customer = CustomerBuilderTest.New
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.False(lineInsurance.Eligible);
        }

        [Fact]
        public void LineInsuranceShouldBeEligibleCustomerWithHouse()
        {
            //arrange
            var rule = new VehicleRule();
            var customer = CustomerBuilderTest.New
                                              .AddVehicle(new Vehicle(2020))
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.True(lineInsurance.Eligible);
        }
    }
}
