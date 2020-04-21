using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;
using System.Collections.Generic;

namespace RiskProfile.Domain.Test.Builders
{
    internal class CustomerBuilderTest
    {
        private int _age = 0;
        private int _dependents = 0;
        private House _house = null;
        private int _income = 0;
        private MaritalStatus _maritalStatus = MaritalStatus.Single;
        private ICollection<int> _riskQuestions = new List<int> { 0, 0, 0 };
        private Vehicle _vehicle = null;

        public static CustomerBuilderTest New => new CustomerBuilderTest();

        public CustomerBuilderTest AddDependents(int dependents)
        {
            _dependents = dependents;
            return this;
        }

        public CustomerBuilderTest AddRiskQuestions(ICollection<int> riskQuestions)
        {
            _riskQuestions = riskQuestions;
            return this;
        }

        public CustomerBuilderTest AddMaritalStatus(MaritalStatus maritalStatus)
        {
            _maritalStatus = maritalStatus;
            return this;
        }

        public CustomerBuilderTest AddAge(int age)
        {
            _age = age;
            return this;
        }

        public CustomerBuilderTest AddIncome(int income)
        {
            _income = income;
            return this;
        }

        public CustomerBuilderTest AddHouse(House house)
        {
            _house = house;
            return this;
        }

        public CustomerBuilderTest AddVehicle(Vehicle vehicle)
        {
            _vehicle = vehicle;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_age, _dependents, _house, _income, _maritalStatus, _riskQuestions, _vehicle);
        }
    }
}
