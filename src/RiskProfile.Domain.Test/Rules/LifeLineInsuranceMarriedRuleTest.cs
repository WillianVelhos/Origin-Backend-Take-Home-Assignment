using RiskProfile.Domain.Enums;
using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class LifeLineInsuranceMarriedRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeScoreEquals4CustomerWithMaritalStatusEqualsMarried()
        {
            //arrange
            var rule = new LifeLineInsuranceMarriedRule();
            var customer = CustomerBuilderTest.New
                                              .AddMaritalStatus(MaritalStatus.Married)
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
        public void LineInsuranceShouldBeScoreEquals3CustomerWithMaritalStatusEqualsSingle()
        {
            //arrange
            var rule = new LifeLineInsuranceMarriedRule();
            var customer = CustomerBuilderTest.New
                                              .AddMaritalStatus(MaritalStatus.Single)
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
