using RiskProfile.Domain.Models;
using System.Collections.Generic;

namespace RiskProfile.Domain.RulesHandler
{
    public class RulesHandler
    {
        private List<IRule> _rules;
        private Customer _customer;
        private LineInsurance _lineInsurance;

        public RulesHandler()
        {
            _rules = new List<IRule>();
        }

        public static RulesHandler New => new RulesHandler();

        public RulesHandler Add(IRule rule)
        {
            _rules.Add(rule);
            return this;
        }

        public RulesHandler For(Customer customer, LineInsurance lineInsurance)
        {
            _customer = customer;
            _lineInsurance = lineInsurance;
            return this;
        }

        public void Calculate()
        {
            foreach (var rule in _rules)
            {
                if (!_lineInsurance.Eligible)
                    break;

                rule.CalculateRiskScore(_customer, _lineInsurance);
            }
        }
    }
}