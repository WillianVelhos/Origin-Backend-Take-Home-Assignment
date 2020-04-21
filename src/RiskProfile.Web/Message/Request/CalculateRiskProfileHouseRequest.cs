using RiskProfile.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RiskProfile.Web.Message.Request
{
    public class CalculateRiskProfileHouseRequest
    {
        [Required]
        [EnumDataType(typeof(OwnershipStatus), ErrorMessage = "The Ownership Status is required Enum Owned = 0 and Mortgaged = 1")]
        [Display(Name = "OwnershipStatus")]
        public OwnershipStatus OwnershipStatus { get; set; }
    }
}
