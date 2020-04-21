using RiskProfile.Domain.Enums;
using RiskProfile.Domain.Models;
using System.Collections.Generic;

namespace RiskProfile.Domain.Test.Builders
{
    internal class LineInsuranceBuilderTest
    {
        private LineInsuranceName _name = LineInsuranceName.Life;
        private ICollection<int> _riskQuestions = new List<int>() { 0, 0, 0 };

        public static LineInsuranceBuilderTest New => new LineInsuranceBuilderTest();

        public LineInsuranceBuilderTest AddRiskQuestions(ICollection<int> riskQuestions)
        {
            _riskQuestions = riskQuestions;
            return this;
        }

        public LineInsurance Build()
        {
            return new LineInsurance(_name, _riskQuestions);
        }
    }
}
