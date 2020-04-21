using RiskProfile.Domain.Services;

namespace RiskProfile.Domain.Test.Builders
{
    public class RiskProfileServiceBuilderTest
    {
        public static RiskProfileServiceBuilderTest New => new RiskProfileServiceBuilderTest();

        public RiskProfileService Build()
        {
            return new RiskProfileService(new LifeInsuranceService(), new AutoInsuranceService(), new DisabilityInsuranceService(), new HomeInsuranceService());
        }
    }
}
