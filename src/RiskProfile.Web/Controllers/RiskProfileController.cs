using Microsoft.AspNetCore.Mvc;
using RiskProfile.Domain.Services;
using RiskProfile.Web.Mapper;
using RiskProfile.Web.Message.Request;

namespace RiskProfile.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RiskProfileController : ControllerBase
    {
        private readonly RiskProfileService _riskProfileService;

        public RiskProfileController(RiskProfileService riskProfileService)
        {
            _riskProfileService = riskProfileService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate(CalculateRiskProfileRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var riskProfile = _riskProfileService.CreateRiskProfile(CostumerMapper.Mapper(request));

            return Ok(RiskProfileMapper.Mapper(riskProfile));
        }
    }
}