using RiskProfile.Domain.Enums;
using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class DisabilityLineInsuranceMarriedRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeScoreEquals2CustomerWithMaritalStatusEqualsMarried()
        {
            //arrange
            var rule = new DisabilityLineInsuranceMarriedRule();
            var customer = CustomerBuilderTest.New
                                              .AddMaritalStatus(MaritalStatus.Married)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(2, lineInsurance.Score);
        }

        [Fact]
        public void LineInsuranceShouldBeScoreEquals3CustomerWithMaritalStatusEqualsSingle()
        {
            //arrange
            var rule = new DisabilityLineInsuranceMarriedRule();
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
