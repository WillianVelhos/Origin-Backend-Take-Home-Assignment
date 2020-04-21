using System.Collections.Generic;

namespace RiskProfile.Domain.Models
{
    public class RiskProfile
    {
        public RiskProfile(ICollection<LineInsurance> linesInusrance)
        {
            LinesInusrance = linesInusrance;
        }

        public ICollection<LineInsurance> LinesInusrance { get; }
    }
}