using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class HighIncomeRuleTest
    {
        [Theory]
        [InlineData(200001)]
        [InlineData(200010)]
        [InlineData(200100)]
        public void LineInsuranceShouldBeScoreEquals2CustomerIncomeAbove200000(int income)
        {
            //arrange
            var rule = new HighIncomeRule();
            var customer = CustomerBuilderTest.New
                                              .AddIncome(income)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int> { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(2, lineInsurance.Score);
        }

        [Theory]
        [InlineData(200000)]
        [InlineData(100000)]
        [InlineData(5000)]
        public void LineInsuranceShouldBeScoreEquals3CustomerEqualsOrBelow200000(int income)
        {
            //arrange
            var rule = new HighIncomeRule();
            var customer = CustomerBuilderTest.New
                                              .AddIncome(income)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int> { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(3, lineInsurance.Score);
        }
    }
}
