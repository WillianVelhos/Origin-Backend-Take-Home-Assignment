using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;
using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class MortgagedHouseRuleTest
    {
        [Fact]
        public void LineInsuranceShouldBeScoreEquals3CustomerWithoutHouse()
        {
            //arrange
            var rule = new MortgagedHouseRule();
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

        [Fact]
        public void LineInsuranceShouldBeScoreEquals3CustomerWithOwnedHouse()
        {
            //arrange
            var rule = new MortgagedHouseRule();
            var customer = CustomerBuilderTest.New
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(3, lineInsurance.Score);
        }

        [Fact]
        public void LineInsuranceShouldBeScoreEquals4CustomerWithMortgagedHouse()
        {
            //arrange
            var rule = new MortgagedHouseRule();
            var customer = CustomerBuilderTest.New
                                              .AddHouse(new House(OwnershipStatus.Mortgaged))
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(4, lineInsurance.Score);
        }
    }
}
