using RiskProfile.Domain.RulesHandler.Rules;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Rules
{
    public class AgeRuleTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(29)]
        public void LineInsuranceShouldBeScoreEquals1CustomerUnder30YearsOld(int age)
        {
            //arrange
            var rule = new AgeRule();
            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
                                              .Build();
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int> { 1, 1, 1 })
                                                        .Build();
            //act
            rule.CalculateRiskScore(customer, lineInsurance);

            //assert
            Assert.Equal(1, lineInsurance.Score);
        }

        [Theory]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        public void LineInsuranceShouldBeScoreEquals2CustomerBetween30Ande40YearsOld(int age)
        {
            //arrange
            var rule = new AgeRule();
            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
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
        [InlineData(41)]
        [InlineData(50)]
        [InlineData(60)]
        public void LineInsuranceShouldBeScoreEquals3CustomerOver40YearsOld(int age)
        {
            //arrange
            var rule = new AgeRule();
            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
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
