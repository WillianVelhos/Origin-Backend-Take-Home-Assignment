using RiskProfile.Domain.Models;
using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class AgeVehicleRuleTest
    {
        [Theory]
        [InlineData(2020)]
        [InlineData(2019)]
        [InlineData(2018)]
        [InlineData(2017)]
        [InlineData(2016)]
        [InlineData(2015)]
        public void LineInsuranceShouldBeScoreEquals4CustomerWithVehicleProducedLast5Years(int year)
        {
            //arrange
            var rule = new AgeVehicleRule();
            var customer = CustomerBuilderTest.New
                                              .AddVehicle(new Vehicle(year))
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(4, lineInsurance.Score);
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(2010)]
        [InlineData(2014)]
        public void LineInsuranceShouldBeScoreEquals3CustomerWithVehicleNotProducedLast5Years(int year)
        {
            //arrange
            var rule = new AgeVehicleRule();
            var customer = CustomerBuilderTest.New
                                              .AddVehicle(new Vehicle(year))
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
