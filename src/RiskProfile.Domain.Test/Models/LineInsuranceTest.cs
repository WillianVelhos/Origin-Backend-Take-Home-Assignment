using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using Xunit;

namespace RiskProfile.Domain.Test.Models
{
    public class LineInsuranceTest
    {
        [Fact]
        public void LineInsuranceShouldBeScoreEquals1()
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 0, 0, 0 })
                                                        .Build();

            //act
            lineInsurance.AddScore(1);

            //assert
            Assert.Equal(1, lineInsurance.Score);
        }

        [Fact]
        public void LineInsuranceShouldBeScoreEquals2()
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                                        .Build();

            //act
            lineInsurance.DeductScore(1);

            //assert
            Assert.Equal(2, lineInsurance.Score);
        }

        [Fact]
        public void LineInsuranceShouldBeIneligible()
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New
                                                        .AddRiskQuestions(new List<int>() { 1, 1, 0 })
                                                        .Build();

            //act
            lineInsurance.Ineligible();

            //assert
            Assert.False(lineInsurance.Eligible);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void TheResultSouldBeEconmicWithScore0andBelow(int score)
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            lineInsurance.DeductScore(score);

            //assert
            Assert.Equal("Economic", lineInsurance.ProcessResult());
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TheResultSouldBeRegularWithScore1and2(int score)
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            lineInsurance.AddScore(score);

            //assert
            Assert.Equal("Regular", lineInsurance.ProcessResult());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TheResultSouldBeResponsibleWithScore3andAbove(int score)
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            lineInsurance.AddScore(score);

            //assert
            Assert.Equal("Responsible", lineInsurance.ProcessResult());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TheResultSouldBeIneligibleWithLineInsuranceIneligible(int score)
        {
            //arrange
            var lineInsurance = LineInsuranceBuilderTest.New.Build();

            //act
            lineInsurance.AddScore(score);
            lineInsurance.Ineligible();

            //assert
            Assert.Equal("Ineligible", lineInsurance.ProcessResult());
        }
    }
}
