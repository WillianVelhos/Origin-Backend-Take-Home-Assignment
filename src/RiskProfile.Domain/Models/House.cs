using RiskProfile.Domain.Enums;

namespace RiskProfile.Domain.Models
{
    public class House
    {
        public House(OwnershipStatus ownershipStatus)
        {
            OwnershipStatus = ownershipStatus;
        }

        public OwnershipStatus OwnershipStatus { get; }
    }
}