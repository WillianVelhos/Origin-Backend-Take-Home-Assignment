using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class IncomeRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeIneligibleCustomerEquals0Income()
        {
            //arrange
            var rule = new IncomeRule();
            var customer = CustomerBuilderTest.New
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.False(lineInsurance.Eligible);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(1000)]
        public void LineInsuranceShouldBeEligibleCustomerOver0Income(int income)
        {
            //arrange
            var rule = new IncomeRule();
            var customer = CustomerBuilderTest.New
                                              .AddIncome(income)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.True(lineInsurance.Eligible);
        }
    }
}
