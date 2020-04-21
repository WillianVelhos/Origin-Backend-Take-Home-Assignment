using RiskProfile.Domain.Enums;
using RiskProfile.Web.Message.Request;
using System.Collections.Generic;

namespace RiskProfile.Web.Test.Builders
{
    public class CalculateRiskProfileRequestBuilderTest
    {
        private int _age = 0;
        private int _dependents = 0;
        private CalculateRiskProfileHouseRequest _house = null;
        private int _income = 0;
        private MaritalStatus _maritalStatus = MaritalStatus.Single;
        private ICollection<int> _riskQuestions = new List<int>() { 0, 0, 0 };
        private CalculateRiskProfileVehicleRequest _vehicle = null;

        public CalculateRiskProfileRequestBuilderTest AddAge(int age)
        {
            _age = age;
            return this;
        }

        public CalculateRiskProfileRequestBuilderTest AddDependents(int dependents)
        {
            _dependents = dependents;
            return this;
        }

        public CalculateRiskProfileRequestBuilderTest AddHouse(CalculateRiskProfileHouseRequest house)
        {
            _house = house;
            return this;
        }

        public CalculateRiskProfileRequestBuilderTest AddIncome(int income)
        {
            _income = income;
            return this;
        }

        public CalculateRiskProfileRequestBuilderTest AddMaritalStatus(MaritalStatus maritalStatus)
        {
            _maritalStatus = maritalStatus;
            return this;
        }

        public CalculateRiskProfileRequestBuilderTest AddVehicle(CalculateRiskProfileVehicleRequest vehicle)
        {
            _vehicle = vehicle;
            return this;
        }

        public CalculateRiskProfileRequestBuilderTest AddRiskQuestions(ICollection<int> riskQuestions)
        {
            _riskQuestions = riskQuestions;
            return this;
        }

        public static CalculateRiskProfileRequestBuilderTest New => new CalculateRiskProfileRequestBuilderTest();

        public CalculateRiskProfileRequest Build()
        {
            return new CalculateRiskProfileRequest()
            {
                Age = _age,
                Dependents = _dependents,
                House = _house,
                Income = _income,
                MaritalStatus = _maritalStatus,
                RiskQuestions = _riskQuestions,
                Vehicle = _vehicle
            };
        }
    }
}