using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class HighAgeRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeIneligibleCustomerOver60YearsOld()
        {
            //arrange
            var rule = new HighAgeRule();
            var lineInsurance = LineInsuranceBuilderTest.New.Build();
            var customer = CustomerBuilderTest.New
                                              .AddAge(61)
                                              .Build();
            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.False(lineInsurance.Eligible);
        }

        [Theory]
        [InlineData(60)]
        [InlineData(59)]
        public void LineInsuranceShouldBeEligibleCustomereEqualOrLess60YearsOld(int age)
        {
            //arrange
            var rule = new HighAgeRule();
            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.True(lineInsurance.Eligible);
        }
    }
}
