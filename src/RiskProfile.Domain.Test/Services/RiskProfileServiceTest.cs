using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;
using RiskProfile.Domain.Test.Builders;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RiskProfile.Domain.Test.Services
{
    public class RiskProfileServiceTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void IfTheUserDoesntHaveIncomeOrVehiclesOrHousesSheIsIneligibleForDisabilityAndAutoAndHomeInsuranceRespectively(
            int income, Vehicle vehicle, House house)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddIncome(income)
                                              .AddVehicle(vehicle)
                                              .AddHouse(house)
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var autoLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Auto);
            var homeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Home);

            Assert.False(disabilityLineInsurance.Eligible);
            Assert.False(autoLineInsurance.Eligible);
            Assert.False(homeLineInsurance.Eligible);
        }

        [Theory]
        [InlineData(61)]
        [InlineData(70)]
        [InlineData(100)]
        public void IfTheUserIsOver60YearsOldSheIsIneligibleForDisabilityAndLifeInsurance(int age)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(2020))
                                              .AddHouse(new House(OwnershipStatus.Mortgaged))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var lifeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Life);

            Assert.False(disabilityLineInsurance.Eligible);
            Assert.False(lifeLineInsurance.Eligible);
        }

        [Theory]
        [InlineData(29)]
        [InlineData(20)]
        [InlineData(10)]
        public void IfTheUserIsUnder30YearsOldDeduct2RiskPointsFromAllLinesOfInsurance(int age)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(2000))
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var lifeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Life);
            var autoLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Auto);
            var homeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Home);

            Assert.Equal(1, disabilityLineInsurance.Score);
            Assert.Equal(1, lifeLineInsurance.Score);
            Assert.Equal(1, autoLineInsurance.Score);
            Assert.Equal(1, homeLineInsurance.Score);
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
        public void IfSheIsBetween30Aand40YearsOldDeduct1(int age)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(age)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(2000))
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var lifeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Life);
            var autoLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Auto);
            var homeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Home);

            Assert.Equal(2, disabilityLineInsurance.Score);
            Assert.Equal(2, lifeLineInsurance.Score);
            Assert.Equal(2, autoLineInsurance.Score);
            Assert.Equal(2, homeLineInsurance.Score);
        }

        [Theory]
        [InlineData(200001)]
        [InlineData(200100)]
        [InlineData(201000)]
        public void IfHerIncomeIsAbove200kDeduct1RiskPointFromAllLinesOfInsurance(int income)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(50)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(income)
                                              .AddVehicle(new Vehicle(2000))
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var lifeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Life);
            var autoLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Auto);
            var homeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Home);

            Assert.Equal(2, disabilityLineInsurance.Score);
            Assert.Equal(2, lifeLineInsurance.Score);
            Assert.Equal(2, autoLineInsurance.Score);
            Assert.Equal(2, homeLineInsurance.Score);
        }

        [Fact]
        public void IfTheUserHouseIsMortgagedAdd1RiskPointToHerHomeScoreAndAdd1RiskPointToHerDisabilityScore()
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(50)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(2000))
                                              .AddHouse(new House(OwnershipStatus.Mortgaged))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var homeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Home);

            Assert.Equal(4, disabilityLineInsurance.Score);
            Assert.Equal(4, homeLineInsurance.Score);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(10)]
        public void IfTheUserHasDependentsAdd1RiskPointToBothTheDisabilityAndLifeScores(int dependents)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(50)
                                              .AddDependents(dependents)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(2000))
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var lifeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Life);

            Assert.Equal(4, disabilityLineInsurance.Score);
            Assert.Equal(4, lifeLineInsurance.Score);
        }

        [Fact]
        public void IfTheUserIsMarriedAdd1RiskPointToTheLifeScoreAndRemove1RiskPointFromDisability()
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(50)
                                              .AddMaritalStatus(MaritalStatus.Married)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(2000))
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var disabilityLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Disability);
            var lifeLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Life);

            Assert.Equal(2, disabilityLineInsurance.Score);
            Assert.Equal(4, lifeLineInsurance.Score);
        }


        [Theory]
        [InlineData(2020)]
        [InlineData(2019)]
        [InlineData(2018)]
        [InlineData(2017)]
        [InlineData(2016)]
        [InlineData(2015)]
        public void IfTheUserVehicleWasProducedInTheLast5YearsAdd1RiskPointToThatVehicleScore(int year)
        {
            var service = RiskProfileServiceBuilderTest.New.Build();

            var customer = CustomerBuilderTest.New
                                              .AddAge(50)
                                              .AddMaritalStatus(MaritalStatus.Married)
                                              .AddRiskQuestions(new List<int>() { 1, 1, 1 })
                                              .AddIncome(1)
                                              .AddVehicle(new Vehicle(year))
                                              .AddHouse(new House(OwnershipStatus.Owned))
                                              .Build();

            var riskProfile = service.CreateRiskProfile(customer);

            var autoLineInsurance = riskProfile.LinesInusrance.First(x => x.Name == LineInsuranceName.Auto);

            Assert.Equal(4, autoLineInsurance.Score);
        }

        public static ICollection<object[]> Data =>
        new List<object[]>
        {
            new object[] { 0, new Vehicle(2020), new House(OwnershipStatus.Mortgaged) },
            new object[] { 1, null, new House(OwnershipStatus.Mortgaged) },
            new object[] { 1, new Vehicle(2020), null }
        };
    }
}
