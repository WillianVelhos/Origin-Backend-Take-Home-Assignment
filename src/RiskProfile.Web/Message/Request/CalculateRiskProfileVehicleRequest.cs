using System.ComponentModel.DataAnnotations;

namespace RiskProfile.Web.Message.Request
{
    public class CalculateRiskProfileVehicleRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "The Vehicle Year is required integer greater than 0")]
        [Display(Name = "Year")]
        public int Year { get; set; }
    }
}
