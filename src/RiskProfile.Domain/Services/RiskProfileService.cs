using RiskProfile.Domain.Models;
using System.Collections.Generic;

namespace RiskProfile.Domain.Services
{
    public class RiskProfileService
    {
        private readonly LifeInsuranceService _lifeInsuranceService;
        private readonly AutoInsuranceService _autoInsuranceService;
        private readonly DisabilityInsuranceService _disabilityInsuranceService;
        private readonly HomeInsuranceService _homeInsuranceService;

        public RiskProfileService(LifeInsuranceService lifeInsuranceService,
                                  AutoInsuranceService autoInsuranceService,
                                  DisabilityInsuranceService disabilityInsuranceService,
                                  HomeInsuranceService homeInsuranceService)
        {
            _lifeInsuranceService = lifeInsuranceService;
            _autoInsuranceService = autoInsuranceService;
            _disabilityInsuranceService = disabilityInsuranceService;
            _homeInsuranceService = homeInsuranceService;
        }

        public Models.RiskProfile CreateRiskProfile(Customer customer)
        {
            return new Models.RiskProfile(new List<LineInsurance>()
            {
                _lifeInsuranceService.CreateLineInsurance(customer),
                _autoInsuranceService.CreateLineInsurance(customer),
                _disabilityInsuranceService.CreateLineInsurance(customer),
                _homeInsuranceService.CreateLineInsurance(customer)
            });
        }
    }
}