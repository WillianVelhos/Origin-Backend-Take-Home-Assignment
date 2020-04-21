using RiskProfile.Domain.Enums;
using RiskProfile.Web.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RiskProfile.Web.Message.Request
{
    public class CalculateRiskProfileRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = "The Age is required integer equal or greater than 0")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The Dependents is required integer equal or greater than 0")]
        [DisplayName("Dependents")]
        public int Dependents { get; set; }

        [Display(Name = "House")]
        public CalculateRiskProfileHouseRequest House { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The Income is required integer equal or greater than 0")]
        [DisplayName("Income")]
        public int Income { get; set; }

        [Required]
        [EnumDataType(typeof(MaritalStatus), ErrorMessage = "The Marital Status is required Enum Single = 0 and Married = 1")]
        [DisplayName("MaritalStatus")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "RiskQuestions")]
        [RiskAnswers(ErrorMessage = "The RiskQuestions is required array with 3 booleans")]
        public ICollection<int> RiskQuestions { get; set; }

        [Display(Name = "Vehicle")]
        public CalculateRiskProfileVehicleRequest Vehicle { get; set; }
    }
}
