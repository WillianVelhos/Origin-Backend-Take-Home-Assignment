using RiskProfile.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace RiskProfile.Domain.Models
{
    public class LineInsurance
    {
        public LineInsurance(LineInsuranceName name, ICollection<int> riskQuestions)
        {
            Name = name;
            Score = riskQuestions.Sum();
            Eligible = true;
        }

        public LineInsuranceName Name { get; }

        public int Score { get; private set; }

        public bool Eligible { get; private set; }

        public void AddScore(int value) => Score += value;

        public void DeductScore(int value) => Score -= value;

        public void Ineligible() => Eligible = false;

        public string ProcessResult()
        {
            if (!Eligible)
                return LineInsuranceStatus.Ineligible.ToString();
            else if (Score <= 0)
                return LineInsuranceStatus.Economic.ToString();
            else if (Score == 1 || Score == 2)
                return LineInsuranceStatus.Regular.ToString();

            return LineInsuranceStatus.Responsible.ToString();
        }
    }
}