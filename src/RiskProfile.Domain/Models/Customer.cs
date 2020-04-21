using RiskProfile.Domain.Enums;
using System.Collections.Generic;

namespace RiskProfile.Domain.Models
{
    public class Customer
    {
        public Customer(int age,
                        int dependents,
                        House house,
                        int income,
                        MaritalStatus maritalStatus,
                        ICollection<int> riskQuestions,
                        Vehicle vehicle)
        {
            Age = age;
            Dependents = dependents;
            House = house;
            Income = income;
            MaritalStatus = maritalStatus;
            RiskQuestions = riskQuestions;
            Vehicle = vehicle;
        }

        public int Age { get; }

        public int Dependents { get; }

        public House House { get; }

        public int Income { get; }

        public MaritalStatus MaritalStatus { get; }

        public ICollection<int> RiskQuestions { get; }

        public Vehicle Vehicle { get; }
    }
}