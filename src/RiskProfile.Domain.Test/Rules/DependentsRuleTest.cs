using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class DependentsRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeScoreEquals4CustomerWithDependents()
        {
            //arrange
            var rule = new DependentsRule();
            var customer = CustomerBuilderTest.New
                                              .AddDependents(1)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(4, lineInsurance.Score);
        }

        [Fact]
        public void LineInsuranceShouldBeScoreEquals3CustomerWithoutDependents()
        {
            //arrange
            var rule = new DependentsRule();
            var customer = CustomerBuilderTest.New
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(3, lineInsurance.Score);
        }
    }
}
