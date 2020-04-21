using RiskProfile.Web.Message.Response;
using System.Linq;
using DomainModels = RiskProfile.Domain.Models;
using DomainEnums = RiskProfile.Domain.Enums;

namespace RiskProfile.Web.Mapper
{
    internal class RiskProfileMapper
    {
        internal static CalculateRiskProfileResponse Mapper(DomainModels.RiskProfile riskProfile)
        {
            return new CalculateRiskProfileResponse()
            {
                Auto = riskProfile.LinesInusrance.First(x => x.Name == DomainEnums.LineInsuranceName.Auto).ProcessResult(),
                Disability = riskProfile.LinesInusrance.First(x => x.Name == DomainEnums.LineInsuranceName.Disability).ProcessResult(),
                Life = riskProfile.LinesInusrance.First(x => x.Name == DomainEnums.LineInsuranceName.Life).ProcessResult(),
                Home = riskProfile.LinesInusrance.First(x => x.Name == DomainEnums.LineInsuranceName.Home).ProcessResult()
            };
        }
    }
}
